package com.espe.oauth.seguridad;


import com.espe.oauth.config.RsaKeysConfig;
import com.espe.oauth.excepciones.AppException;
import io.jsonwebtoken.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.HttpStatus;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.oauth2.jwt.Jwt;
import org.springframework.security.oauth2.jwt.JwtClaimsSet;
import org.springframework.security.oauth2.jwt.JwtDecoder;
import org.springframework.security.oauth2.jwt.JwtEncoder;
import org.springframework.security.oauth2.jwt.JwtEncoderParameters;
import org.springframework.security.oauth2.jwt.*;
import org.springframework.stereotype.Component;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.security.PublicKey;
import java.security.cert.CertificateException;
import java.security.cert.CertificateFactory;
import java.security.cert.X509Certificate;
import java.util.Date;
import java.util.stream.Collectors;

@Component
public class JwtTokenProvider {

    @Value("${app.jwt-secret}")
    private String jwtSecret;
    @Value("${rsa.public-key}")
    private String publicllave;

    @Value("${app.jwt-expiration-milliseconds}")
    private int jwtExpirationInMs;
    @Autowired
    private JwtEncoder jwtEncoder;
    @Autowired
    private RsaKeysConfig rsaKeysConfig;
    @Autowired
    private JwtDecoder jwtDecoder;

    public String generarToken(Authentication authentication) {
        String subject = authentication.getName();
        String scope = authentication.getAuthorities().stream().map(GrantedAuthority::getAuthority).collect(Collectors.joining(" "));
        Date fechaActual = new Date();
        Date fechaExpiracion = new Date(fechaActual.getTime() + jwtExpirationInMs);
        return jwtEncoder.encode(JwtEncoderParameters.from(JwtClaimsSet.builder()
                .subject(subject)
                .issuer("security-service")
                .issuedAt(new Date().toInstant())
                .expiresAt(fechaExpiracion.toInstant())
                .claim("scope", scope)
                .build())).getTokenValue();
    }

    public boolean validarToken(String token) {
        Jwt decodeJWT = null;
        try {
            // Cargar la clave pública RSA
            //PublicKey publicKey = rsaKeysConfig.publicKey();

            // Verificar el token utilizando la clave pública
            //Jwts.parser()
                    //.setSigningKey(publicKey)  // Usamos la clave pública para verificar la firma
                    //.parseClaimsJws(token);  // Intentamos parsear el JWT
            decodeJWT =  jwtDecoder.decode(token);
            return true;  // El token es válido
        } catch (SignatureException ex) {
            throw new AppException(HttpStatus.BAD_REQUEST,"Firma JWT no valida");
        } catch (MalformedJwtException ex) {
            //throw new MalformedJwtException("Token inválido pero xq no imprime en postman");
            throw new AppException(HttpStatus.BAD_REQUEST,"Token JWT no valida");
        } catch (ExpiredJwtException ex) {
            throw new AppException(HttpStatus.BAD_REQUEST,"Token JWT caducado");
        } catch (UnsupportedJwtException ex) {
            throw new AppException(HttpStatus.BAD_REQUEST,"Token JWT no compatible");
        } catch (IllegalArgumentException ex) {
            throw new AppException(HttpStatus.BAD_REQUEST,"La cadena claims JWT esta vacia");
        }
    }


    public String obtenerUsernameDelJWT(String token) {
        PublicKey publicKey = rsaKeysConfig.publicKey();
        Jws<Claims> jwsClaims = Jwts.parser().setSigningKey(publicKey)  // Usamos la clave pública para verificar la firma
                .parseClaimsJws(token);
        Claims claims = jwsClaims.getBody();  // Obtén el cuerpo de las reclamaciones
        return claims.getSubject();
    }


}

