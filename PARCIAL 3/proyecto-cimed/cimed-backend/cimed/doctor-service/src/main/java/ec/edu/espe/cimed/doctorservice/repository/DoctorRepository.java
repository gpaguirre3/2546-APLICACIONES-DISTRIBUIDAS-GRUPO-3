package ec.edu.espe.cimed.doctorservice.repository;

import ec.edu.espe.cimed.doctorservice.model.Doctor;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface DoctorRepository extends JpaRepository<Doctor, Long> {
    List<Doctor> findByName(String name);
}
