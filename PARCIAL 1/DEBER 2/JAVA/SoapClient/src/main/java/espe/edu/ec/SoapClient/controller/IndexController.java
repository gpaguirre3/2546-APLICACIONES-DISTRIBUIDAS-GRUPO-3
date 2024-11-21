package espe.edu.ec.SoapClient.controller;

import espe.edu.ec.SoapClient.client.SoapClient;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.net.URL;
import java.util.ResourceBundle;

@Component
public class IndexController implements Initializable {
    @Override
    public void initialize(URL location, ResourceBundle resources) {

    }

    @Autowired
    private SoapClient soapClient;

    @FXML
    private TextField numberA;

    @FXML
    private TextField numberB;

    @FXML
    private Label result;

    @FXML
    public void handleAdd(){
        int a = Integer.parseInt(numberA.getText());
        int b = Integer.parseInt(numberB.getText());
        int response = soapClient.getAddResponse(a, b).getAddResult();
        result.setText(String.valueOf(response));
    }

    @FXML
    public void handleSubtract(){
        int a = Integer.parseInt(numberA.getText());
        int b = Integer.parseInt(numberB.getText());
        int response = soapClient.getSubtractResponse(a, b).getSubtractResult();
        result.setText(String.valueOf(response));
    }

    @FXML
    public void handleMultiply(){
        int a = Integer.parseInt(numberA.getText());
        int b = Integer.parseInt(numberB.getText());
        int response = soapClient.getMultiplyResponse(a, b).getMultiplyResult();
        result.setText(String.valueOf(response));
    }

    @FXML
    public void handleDivide(){
        int a = Integer.parseInt(numberA.getText());
        int b = Integer.parseInt(numberB.getText());
        int response = soapClient.getDivideResponse(a, b).getDivideResult();
        result.setText(String.valueOf(response));
    }
}
