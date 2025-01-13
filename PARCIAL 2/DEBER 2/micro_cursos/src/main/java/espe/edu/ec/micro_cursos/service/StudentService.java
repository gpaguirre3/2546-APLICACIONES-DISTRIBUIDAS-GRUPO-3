package espe.edu.ec.micro_cursos.service;

import espe.edu.ec.micro_cursos.model.entity.Student;

import java.util.List;
import java.util.Optional;

public interface StudentService {

    public List<Student> findAll();
    Optional<Student> findById(Long id);
    public Student save(Student student);
    public void deleteById(Long id);
}
