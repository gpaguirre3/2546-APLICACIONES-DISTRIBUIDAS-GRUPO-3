package espe.edu.ec.ProductManagement.Exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.NOT_FOUND)
public class ProducNotFound extends RuntimeException {
    public ProducNotFound(String message) {
        super(message);
    }
}
