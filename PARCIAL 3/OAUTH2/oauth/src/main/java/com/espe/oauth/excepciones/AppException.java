package com.espe.oauth.excepciones;
import org.springframework.http.HttpStatus;

public class AppException extends RuntimeException {

    private static final long serialVersionUID = 1L;

    private HttpStatus estado;
    private String mensaje;

    public AppException(HttpStatus estado, String mensaje) {
        super(mensaje);
        this.estado = estado;
        //this.estado=HttpStatus.BAD_REQUEST;
        this.mensaje = mensaje;
    }



    public HttpStatus getEstado() {
        return estado;
    }

    public void setEstado(HttpStatus estado) {
        this.estado = estado;
    }

    public String getMensaje() {
        return mensaje;
    }

    public void setMensaje(String mensaje) {
        this.mensaje = mensaje;
    }

}
