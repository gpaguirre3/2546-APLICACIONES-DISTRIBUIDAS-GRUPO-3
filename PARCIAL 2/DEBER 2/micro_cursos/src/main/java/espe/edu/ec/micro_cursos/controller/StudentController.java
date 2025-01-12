package espe.edu.ec.micro_cursos.controller;

import espe.edu.ec.micro_cursos.model.entity.Course;
import espe.edu.ec.micro_cursos.model.entity.Student;
import org.springframework.beans.factory.annotation.Autowired;
import espe.edu.ec.micro_cursos.service.StudentService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/students")
public class StudentController {

    @Autowired
    private StudentService studentService;

    @PostMapping
    public ResponseEntity<?> saveStudent(@RequestBody Student student) {
        return ResponseEntity.status(HttpStatus.CREATED).body(studentService.save(student));
    }

    @GetMapping
    public ResponseEntity<?> getStudent() {
        return ResponseEntity.status(HttpStatus.OK).body(studentService.findAll());
    }

    @GetMapping("/{id}")
    public ResponseEntity<?> getStudentById(@PathVariable Long id) {
        Optional<Student> studentOptional = studentService.findById(id);
        if (studentOptional.isPresent()){
            return ResponseEntity.status(HttpStatus.OK).body(studentOptional.get());
        }
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Student not found");
    }

    @PutMapping("/{id}")
    public ResponseEntity<?> updateStudent(@PathVariable Long id, @RequestBody Student student) {
        Optional<Student> studentOptional = studentService.findById(id);
        if (studentOptional.isPresent()){
            Student studentUpdate = studentOptional.get();
            studentUpdate.setName(student.getName());
            studentUpdate.setLastName(student.getLastName());
            studentUpdate.setEmail(student.getEmail());
            studentUpdate.setPhone(student.getPhone());
            studentUpdate.setBirthday(student.getBirthday());
            return ResponseEntity.status(HttpStatus.CREATED).body(studentService.save(studentUpdate));
        }else
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Student not found");
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<?> deleteStudent(@PathVariable Long id) {
        Optional<Student> studentOptional = studentService.findById(id);
        if (studentOptional.isPresent()){
            studentService.deleteById(id);
            return ResponseEntity.noContent().build();
        }else
            return ResponseEntity.notFound().build();
    }

}
