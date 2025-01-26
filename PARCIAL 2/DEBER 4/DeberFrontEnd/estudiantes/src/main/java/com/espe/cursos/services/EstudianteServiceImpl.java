package com.espe.cursos.services;

import com.espe.cursos.models.entities.Estudiante;
import com.espe.cursos.repositories.EstudianteRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class EstudianteServiceImpl implements EstudianteService {

    @Autowired
    private EstudianteRepository repository;

    @Override
    public List<Estudiante> findAll() {
        return (List<Estudiante>) repository.findAll();
    }

    @Override
    public Optional<Estudiante> findById(Long id) {
        return repository.findById(id);
    }

    @Override
    public Estudiante save(Estudiante estudiante) {
        return repository.save(estudiante);
    }

    @Override
public void edit(Estudiante estudiante, Long id) {
    Optional<Estudiante> optional = repository.findById(id);
    if (optional.isPresent()) {
        Estudiante estudianteDB = optional.get();
        estudianteDB.setNombre(estudiante.getNombre());
        estudianteDB.setApellido(estudiante.getApellido());
        estudianteDB.setEmail(estudiante.getEmail());
        estudianteDB.setTelefono(estudiante.getTelefono());
        repository.save(estudianteDB);
    }
}

    @Override
    public void deleteById(Long id) {
        repository.deleteById(id);
    }
}
