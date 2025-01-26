package com.espe.micro_cursos.controllers;

import com.espe.micro_cursos.model.Usuario;
import com.espe.micro_cursos.model.entity.Curso;
import com.espe.micro_cursos.services.CursoService;
import feign.FeignException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Collections;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/cursos")
public class CursoController {

    @Autowired
    private CursoService service;

    // Método POST para crear un nuevo curso
    @PostMapping("/add")
    public ResponseEntity<?> crear(@RequestBody Curso curso){
        // Guardar el curso y devolver respuesta con el curso creado
        return ResponseEntity.status(HttpStatus.CREATED).body(service.save(curso));
    }

    // Método GET para listar todos los cursos
    @GetMapping
    public List<Curso> listar() {
        return service.findAll();
    }

    // Método GET para obtener un curso por su ID
    @GetMapping("/{id}")
    public ResponseEntity<?> buscarPorId(@PathVariable Long id){
        Optional<Curso> cursoOptional = service.findById(id);
        if (cursoOptional.isPresent()){
            return ResponseEntity.ok().body(cursoOptional.get());
        }
        return ResponseEntity.notFound().build();
    }

    // Método PUT para editar un curso existente
    @PutMapping("/{id}")
    public ResponseEntity<?> editar(@RequestBody Curso curso, @PathVariable Long id){
        Optional<Curso> cursoOptional = service.findById(id);
        if (cursoOptional.isPresent()){
            Curso cursoDB = cursoOptional.get();
            // Actualizar los campos del curso
            cursoDB.setNombre(curso.getNombre());
            cursoDB.setDescripcion(curso.getDescripcion());
            cursoDB.setCreditos(curso.getCreditos());
            // Guardar el curso actualizado y devolverlo
            return ResponseEntity.ok().body(service.save(cursoDB));
        }
        return ResponseEntity.notFound().build();  // Si el curso no existe
    }

    // Método DELETE para eliminar un curso por su ID
    @DeleteMapping("/{id}")
    public ResponseEntity<?> eliminar(@PathVariable Long id){
        service.deleteById(id);
        return ResponseEntity.noContent().build();
    }


    // Agregar un usuario a un curso
    // POST /api/cursos/agregar_usuario/{id}
    @PostMapping("agregar_usuario/{id}")
    public ResponseEntity<?> agregarUsuario(@RequestBody Usuario usuario, @PathVariable Long id) {
        Optional<Usuario> optional;
        try {
            optional = service.addUser(usuario, id);
        } catch (FeignException ex) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(Collections.singletonMap("Error", "Usuario no encontrado: " + ex.getMessage()));
        }
        if (optional.isPresent()) {
            return ResponseEntity.status(HttpStatus.CREATED).body(optional.get());
        }
        return ResponseEntity.notFound().build();
    }

    // Eliminar un usuario de un curso
    // DELETE /api/cursos/eliminar_usuario/{cursoId}/{usuarioId}
    @DeleteMapping("eliminar_usuario/{cursoId}/{usuarioId}")
    public ResponseEntity<?> eliminarUsuario(@PathVariable Long cursoId, @PathVariable Long usuarioId) {
        try {
            service.removeUser(cursoId, usuarioId);
            return ResponseEntity.noContent().build();
        } catch (FeignException ex) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(Collections.singletonMap("Error", "Usuario o curso no encontrado: " + ex.getMessage()));
        }
    }

}
