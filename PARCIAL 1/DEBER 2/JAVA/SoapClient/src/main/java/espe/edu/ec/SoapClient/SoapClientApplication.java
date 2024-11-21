package espe.edu.ec.SoapClient;

import espe.edu.ec.SoapClient.presentation.CalculatorFx;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import javafx.application.Application;



@SpringBootApplication
public class SoapClientApplication {

	public static void main(String[] args) {

//		SpringApplication.run(SoapClientApplication.class, args);
		Application.launch(CalculatorFx.class, args);
	}


}
