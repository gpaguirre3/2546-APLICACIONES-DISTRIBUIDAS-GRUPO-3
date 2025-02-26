package ec.edu.espe.cimed.appointmentservice.repository;

import ec.edu.espe.cimed.appointmentservice.model.Appointment;
import org.springframework.data.jpa.repository.JpaRepository;

public interface AppointmentRepository extends JpaRepository<Appointment, Long> {
}
