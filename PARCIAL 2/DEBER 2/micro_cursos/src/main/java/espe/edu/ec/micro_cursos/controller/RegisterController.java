package espe.edu.ec.micro_cursos.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import espe.edu.ec.micro_cursos.service.RegistrationService;

@RestController
@RequestMapping("/api/register")
public class RegisterController {

    @Autowired
    private RegistrationService registerService;

    @PostMapping("/student/{studentId}/course/{courseId}")
    public ResponseEntity<?> registerCourse(@PathVariable Long studentId, @PathVariable Long courseId) {
        return ResponseEntity.status(HttpStatus.CREATED).body(registerService.registerCourse(studentId, courseId));
    }
}
