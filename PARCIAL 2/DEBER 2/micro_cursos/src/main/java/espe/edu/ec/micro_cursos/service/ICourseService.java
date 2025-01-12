package espe.edu.ec.micro_cursos.service;

import espe.edu.ec.micro_cursos.model.entity.Course;
import espe.edu.ec.micro_cursos.repository.CourseRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;


@Service
public class ICourseService implements CourseService {

    @Autowired
    private CourseRepository courseRepository;


    @Override
    public List<Course> findAll() {
        return (List<Course>) courseRepository.findAll();
    }

    @Override
    public Optional<Course> findById(Long id) {
        return courseRepository.findById(id);
    }

    @Override
    public Course save(Course course) {
        return courseRepository.save(course);
    }

    @Override
    public void deleteById(Long id) {
        courseRepository.deleteById(id);

    }
}
