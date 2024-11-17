package espe.edu.ec.SoapClient;

import espe.edu.ec.SoapClient.client.SoapClient;
import espe.edu.ec.SoapClient.wsdl.AddResponse;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

@SpringBootApplication
public class SoapClientApplication {

//	private static final Logger LOGGER = LoggerFactory.getLogger(SoapClientApplication.class);

	public static void main(String[] args) {
		SpringApplication.run(SoapClientApplication.class, args);
	}

//	@Bean
//	CommandLineRunner init(SoapClient soapClient){
//		return args -> {
//
//			AddResponse addResponse = soapClient.getAddResponse(10, 20);
//
//			LOGGER.info("Add Response: {} ", addResponse.getAddResult());
//		};
//	}
}
