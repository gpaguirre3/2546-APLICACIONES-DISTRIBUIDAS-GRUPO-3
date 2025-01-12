package espe.edu.ec.micro_cursos.repository;

import espe.edu.ec.micro_cursos.model.entity.Course;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

public interface CourseRepository extends CrudRepository<Course, Long> {
}
