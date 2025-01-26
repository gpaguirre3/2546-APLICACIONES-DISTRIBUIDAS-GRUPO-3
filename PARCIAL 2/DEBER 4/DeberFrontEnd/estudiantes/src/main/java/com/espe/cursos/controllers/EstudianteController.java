package com.espe.cursos.controllers;

import com.espe.cursos.models.entities.Estudiante;
import com.espe.cursos.services.EstudianteService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@CrossOrigin(origins = "http://localhost:3000, http://localhost:8003")

@RequestMapping("/api/estudiantes")
public class EstudianteController {

    @Autowired
    private EstudianteService service;

    // Crear un nuevo estudiante
    @PostMapping
    public ResponseEntity<?> crear(@RequestBody Estudiante estudiante) {
        return ResponseEntity.status(HttpStatus.CREATED).body(service.save(estudiante));
    }

    // Obtener todos los estudiantes
    @GetMapping
    public ResponseEntity<List<Estudiante>> obtenerTodos() {
        List<Estudiante> estudiantes = service.findAll();
        return ResponseEntity.ok(estudiantes);
    }

    // Obtener un estudiante por su ID
    @GetMapping("/{id}")
    public ResponseEntity<?> obtenerPorId(@PathVariable Long id) {
        Optional<Estudiante> estudiante = service.findById(id);
        return estudiante.map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.status(HttpStatus.NOT_FOUND).build());
    }

    // Eliminar un estudiante por su ID
    @DeleteMapping("/{id}")
    public ResponseEntity<?> eliminar(@PathVariable Long id) {
        Optional<Estudiante> estudiante = service.findById(id);
        if (estudiante.isPresent()) {
            service.deleteById(id);
            return ResponseEntity.status(HttpStatus.NO_CONTENT).build(); // No content
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Estudiante no encontrado");
        }
    }

    @PutMapping("/{id}")
    public ResponseEntity<?> editar(@RequestBody Estudiante estudiante, @PathVariable Long id) {
        Optional<Estudiante> estudianteOptional = service.findById(id);
        if (estudianteOptional.isPresent()) {
            service.edit(estudiante, id);
            return ResponseEntity.ok().body(estudianteOptional.get());
        }
        return ResponseEntity.notFound().build();
    }


}
