package com.espe.oauth;

import com.espe.oauth.config.RsaKeysConfig;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.context.properties.EnableConfigurationProperties;
import org.springframework.context.annotation.Bean;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;

@SpringBootApplication
//habilita la carga de propiedades de claves RSA
@EnableConfigurationProperties(RsaKeysConfig.class)
public class OauthApplication {

	public static void main(String[] args) {SpringApplication.run(OauthApplication.class, args);}
	@Bean
	public PasswordEncoder passwordEncoder(){
		return new BCryptPasswordEncoder();
	}

}
