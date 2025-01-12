package espe.edu.ec.micro_cursos.service;

import espe.edu.ec.micro_cursos.model.entity.Course;
import espe.edu.ec.micro_cursos.model.entity.Student;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import espe.edu.ec.micro_cursos.repository.StudentRepository;
import espe.edu.ec.micro_cursos.repository.CourseRepository;

@Service
public class IRegistrationService implements RegistrationService {

    @Autowired
    private StudentRepository studentRepository;

    @Autowired
    private CourseRepository courseRepository;

    public Student registerCourse(Long studentId, Long courseId) {
        Student student = studentRepository.findById(studentId).orElseThrow(() -> new RuntimeException("Student not found"));
        Course course = courseRepository.findById(courseId).orElseThrow(() -> new RuntimeException("Course not found"));
        student.getCourses().add(course);
        return studentRepository.save(student);
    }
}
