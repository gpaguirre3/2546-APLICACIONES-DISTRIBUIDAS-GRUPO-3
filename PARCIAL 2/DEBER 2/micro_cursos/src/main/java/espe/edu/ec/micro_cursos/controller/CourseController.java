package espe.edu.ec.micro_cursos.controller;

import espe.edu.ec.micro_cursos.model.entity.Course;
import espe.edu.ec.micro_cursos.service.CourseService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Optional;

@RestController
@RequestMapping("/api/course")
public class CourseController {

    @Autowired
    private CourseService courseService;

    @PostMapping
    public ResponseEntity<?> saveCourse(@RequestBody Course course) {
        return ResponseEntity.status(HttpStatus.CREATED).body(courseService.save(course));
    }

    @GetMapping
    public ResponseEntity<?> getCourses() {
        return ResponseEntity.status(HttpStatus.OK).body(courseService.findAll());
    }

    @GetMapping("/{id}")
    public ResponseEntity<?> getCourseById(@PathVariable Long id) {
        Optional<Course> courseOptional = courseService.findById(id);
        if (courseOptional.isPresent()){
            return ResponseEntity.status(HttpStatus.OK).body(courseOptional.get());
        }
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Course not found");
    }

    @PutMapping("/{id}")
    public ResponseEntity<?> updateCourse(@PathVariable Long id, @RequestBody Course course) {
        Optional<Course> courseOptional = courseService.findById(id);
        if (courseOptional.isPresent()){
            Course courseUpdate = courseOptional.get();
            courseUpdate.setName(course.getName());
            courseUpdate.setDescription(course.getDescription());
            courseUpdate.setCredits(course.getCredits());
            return ResponseEntity.status(HttpStatus.CREATED).body(courseService.save(courseUpdate));
        }else
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Course not found");
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<?> deleteCourse(@PathVariable Long id) {
        Optional<Course> courseOptional = courseService.findById(id);
        if (courseOptional.isPresent()){
            courseService.deleteById(id);
            return ResponseEntity.noContent().build();
        }else
            return ResponseEntity.notFound().build();
    }
}
