package espe.edu.ec.micro_cursos.service;

import espe.edu.ec.micro_cursos.model.entity.Course;

import java.util.List;
import java.util.Optional;

public interface CourseService {
    public List<Course> findAll();
    Optional <Course> findById(Long id);
    public Course save(Course course);
    public void deleteById(Long id);
}
