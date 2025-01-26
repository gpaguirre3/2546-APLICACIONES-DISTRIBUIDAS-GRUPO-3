package com.espe.cursos.services;

import com.espe.cursos.models.entities.Estudiante;

import java.util.List;
import java.util.Optional;

public interface EstudianteService {

    List<Estudiante> findAll();
    Optional<Estudiante> findById(Long id);
    Estudiante save(Estudiante estudiante);
    void edit(Estudiante estudiante, Long id);
    void deleteById(Long id);

}
