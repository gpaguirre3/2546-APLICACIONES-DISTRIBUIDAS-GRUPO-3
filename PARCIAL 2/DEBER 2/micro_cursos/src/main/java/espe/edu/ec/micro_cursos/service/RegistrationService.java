package espe.edu.ec.micro_cursos.service;

import espe.edu.ec.micro_cursos.model.entity.Student;

public interface RegistrationService {
    public Student registerCourse(Long studentId, Long courseId);
}
