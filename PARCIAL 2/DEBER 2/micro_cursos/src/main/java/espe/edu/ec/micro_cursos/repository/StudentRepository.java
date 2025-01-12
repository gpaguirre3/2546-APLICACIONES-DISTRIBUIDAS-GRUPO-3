package espe.edu.ec.micro_cursos.repository;

import espe.edu.ec.micro_cursos.model.entity.Student;
import org.springframework.data.repository.CrudRepository;

public interface StudentRepository extends CrudRepository<Student, Long> {
}
