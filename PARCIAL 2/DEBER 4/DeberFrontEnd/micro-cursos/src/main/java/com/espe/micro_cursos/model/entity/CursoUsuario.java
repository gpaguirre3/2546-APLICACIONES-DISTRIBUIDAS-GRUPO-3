package com.espe.micro_cursos.model.entity;

import jakarta.persistence.*;

@Entity
@Table(name = "cursos_usuario")
public class CursoUsuario {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;


    @Column(name = "usuario_id")
    private Long usuarioId;


    public Long getUsuarioId() {
        return usuarioId;
    }

    //esto sirve para que el objeto sea comparado con otro
    //para saber si son iguales
    //se sobreescribe el metodo equals
    //se compara el objeto con otro objeto
    //se compara si el objeto es igual a si mismo
    //se compara si el objeto es nulo o no es de la misma clase
    //se castea el objeto a CursoUsuario
    //se retorna si el usuarioId es igual al usuarioId del objeto casteado
    @Override
    public boolean equals(Object obj) {
        //si el objeto es igual a si mismo
        if(this == obj){
            //retorna verdadero
            return true;
        }
        //si el objeto es nulo o no es de la misma clase
        if(!(obj instanceof CursoUsuario)){
            //retorna falso
            return false;
        }
        //casteado es un objeto de la clase CursoUsuario
        //se castea el objeto a CursoUsuario
        CursoUsuario cu = (CursoUsuario) obj;

        //retorna si el usuarioId es igual al usuarioId del objeto casteado
        return this.usuarioId != null && this.usuarioId.equals(cu.getUsuarioId());
    }

    public void setUsuarioId(Long usuarioId) {
        this.usuarioId = usuarioId;
    }
}
