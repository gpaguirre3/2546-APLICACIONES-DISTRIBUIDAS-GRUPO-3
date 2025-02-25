package com.espe.oauth.controller;

import com.espe.oauth.seguridad.JwtTokenProvider;
import com.espe.oauth.model.User;
import com.espe.oauth.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.oauth2.jwt.JwtEncoder;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.Map;

@RestController
@RequestMapping("/auth")
public class AuthController {

    @Autowired
    private JwtEncoder jwtEncoder;

    @Autowired
    private AuthenticationManager authenticationManager;

    @Autowired
    private UserService userService;
    @Autowired
    private JwtTokenProvider jwtTokenProvider;

    @PostMapping("/register")
    public ResponseEntity<String> register(@RequestParam String username, @RequestParam String password) {
        User user = userService.registerUser(username, password);
        return new ResponseEntity<>("Usuario registrado con éxito: " + user.getUsername(), HttpStatus.CREATED);
    }

    @PostMapping("/iniciarSesion")
    public ResponseEntity<Map<String, String>> generarToken(@RequestParam String username, @RequestParam String password) {
        Authentication authentication = authenticationManager.authenticate(
                new UsernamePasswordAuthenticationToken(username, password)
        );
        Map<String, String> idToken = new HashMap<>();
        String jwtAccessToken = jwtTokenProvider.generarToken(authentication);
        idToken.put("accessToken", jwtAccessToken);
        return new ResponseEntity<>(idToken, HttpStatus.OK);
    }

}
