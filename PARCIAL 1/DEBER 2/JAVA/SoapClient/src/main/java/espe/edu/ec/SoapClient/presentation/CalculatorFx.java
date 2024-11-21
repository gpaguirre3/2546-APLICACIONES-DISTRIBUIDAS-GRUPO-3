package espe.edu.ec.SoapClient.presentation;

import espe.edu.ec.SoapClient.SoapClientApplication;
import javafx.application.Application;
import javafx.application.Platform;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.stage.Stage;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.context.ConfigurableApplicationContext;

import java.io.IOException;


public class CalculatorFx extends Application {

    private ConfigurableApplicationContext aplicationContex;

//    public static void main(String[] args) {
//        launch(args);
//    }

    public void init() {
        this.aplicationContex = new SpringApplicationBuilder(SoapClientApplication.class).run();
    }

    @Override
    public void start(Stage stage) throws IOException {
        FXMLLoader loader = new FXMLLoader(SoapClientApplication
                .class.getResource("/templates/index.fxml"));
        loader.setControllerFactory(aplicationContex::getBean);
        Scene scene = new Scene(loader.load());
        stage.setScene(scene);
        stage.show();
    }

    @Override
    public void stop() {
        aplicationContex.close();
        Platform.exit();
    }
}
