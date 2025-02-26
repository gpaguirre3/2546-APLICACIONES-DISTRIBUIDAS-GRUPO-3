package ec.edu.espe.cimed.patientservice.repository;

import ec.edu.espe.cimed.patientservice.model.User;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface UserRepository extends JpaRepository<User, Long> {
    List<User> findByUsername(String username);
}
