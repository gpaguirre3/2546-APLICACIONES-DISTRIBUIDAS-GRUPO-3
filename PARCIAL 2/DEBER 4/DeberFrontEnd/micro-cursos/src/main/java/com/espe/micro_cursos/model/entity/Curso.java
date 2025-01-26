package com.espe.micro_cursos.model.entity;

import com.espe.micro_cursos.model.Usuario;
import jakarta.persistence.*;

import java.util.*;

@Entity
@Table(name="Cursos")
public class Curso {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false)
    private String nombre;

    @Column(nullable = false)
    private String descripcion;

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    @Column(nullable = false)
    private String description;

    @Column(nullable = false)
    private int creditos;

    //relacion uno a muchos
    //un curso puede tener muchos usuarios
    //un usuario puede tener muchos cursos
    //se crea una lista de CursoUsuario
    @OneToMany(cascade = CascadeType.ALL, orphanRemoval = true)
    //se crea una columna curso_id
    //siver para relacionar la tabla cursos con la tabla cursos_usuario
    @JoinColumn(name = "curso_id")
    private List<CursoUsuario> cursoUsuarios;


    //se crea una lista de usuarios
    // Transient significa que no se va a guardar en la base de datos
    @Transient
    private List<Usuario> usuarios;

    //constructor
    public Curso() {
        cursoUsuarios = new ArrayList<>();
    }

    //getters y setters
    public List<CursoUsuario> getCursoUsuarios() {
        return cursoUsuarios;
    }

    public void setCursoUsuarios(List<CursoUsuario> cursoUsuarios) {
        this.cursoUsuarios = cursoUsuarios;
    }


    public void addCursoUsuario(CursoUsuario cursoUsuario){
        cursoUsuarios.add(cursoUsuario);
    }

    public void removeCursoUsuario(CursoUsuario cursoUsuario){
        cursoUsuarios.remove(cursoUsuario);
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public int getCreditos() {
        return creditos;
    }

    public void setCreditos(int creditos) {
        this.creditos = creditos;
    }


}