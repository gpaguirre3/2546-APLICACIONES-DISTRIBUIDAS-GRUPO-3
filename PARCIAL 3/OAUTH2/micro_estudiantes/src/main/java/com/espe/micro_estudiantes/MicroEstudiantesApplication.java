package com.espe.micro_estudiantes;

import com.espe.micro_estudiantes.config.RsaKeysConfig;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.context.properties.EnableConfigurationProperties;

@SpringBootApplication
@EnableConfigurationProperties(RsaKeysConfig.class)
public class MicroEstudiantesApplication {

	public static void main(String[] args) {
		SpringApplication.run(MicroEstudiantesApplication.class, args);
	}

}
