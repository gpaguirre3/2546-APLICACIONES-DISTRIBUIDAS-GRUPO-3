package com.espe.micro_estudiantes.controller;

import com.espe.micro_estudiantes.model.entity.Estudiante;
import com.espe.micro_estudiantes.services.EstudianteService;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;

@RestController
@RequestMapping("/api/estudiantes")
@CrossOrigin(origins = "http://localhost:3000")
public class EstudianteController {

    @Autowired
    private EstudianteService estudianteService;

    @PostMapping
    public ResponseEntity<?> crear(@Valid @RequestBody Estudiante estudiante, BindingResult result) {
        if (validar(result) != null) {
            return validar(result);
        }
        return ResponseEntity.status(HttpStatus.CREATED).body(estudianteService.save(estudiante));
    }

    @GetMapping
    @PreAuthorize("hasAuthority('SCOPE_USER')")
    public List<Estudiante> listar() {
        return estudianteService.findAll();
    }

    @GetMapping("/{id}")
    @PreAuthorize("hasAuthority('SCOPE_USER')")
    public ResponseEntity<?> buscarPorId(@PathVariable Long id) {
        Optional<Estudiante> estudianteOptional = estudianteService.findById(id);
        if (estudianteOptional.isPresent()) {
            return ResponseEntity.ok().body(estudianteOptional.get());
        }
        return ResponseEntity.notFound().build();
    }

    @PutMapping("/{id}")
    @PreAuthorize("hasAuthority('SCOPE_USER')")
    public ResponseEntity<?> editar(@RequestBody Estudiante estudiante, @PathVariable Long id) {
        Optional<Estudiante> estudianteOptional = estudianteService.findById(id);
        if (estudianteOptional.isPresent()) {
            Estudiante estudianteDB = estudianteOptional.get();
            estudianteDB.setNombre(estudiante.getNombre());
            estudianteDB.setApellido(estudiante.getApellido());
            estudianteDB.setEmail(estudiante.getEmail());
            estudianteDB.setFechaNacimiento(estudiante.getFechaNacimiento());
            estudianteDB.setTelefono(estudiante.getTelefono());
            return ResponseEntity.status(HttpStatus.CREATED).body(estudianteService.save(estudianteDB));
        }
        return ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    @PreAuthorize("hasAuthority('SCOPE_USER')")
    public ResponseEntity<?> eliminar(@PathVariable Long id) {
        Optional<Estudiante> estudianteOptional = estudianteService.findById(id);
        if (estudianteOptional.isPresent()) {
            estudianteService.deleteById(id);
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }

    public ResponseEntity<?> validar(BindingResult result) {
        if (result.hasErrors()) {
            Map<String, String> errores = new HashMap<>();
            result.getFieldErrors().forEach(
                    err -> errores.put(
                            err.getField(), err.getDefaultMessage()
                    )
            );
            return ResponseEntity.badRequest().body(errores);
        }
        return null;
    }
}
