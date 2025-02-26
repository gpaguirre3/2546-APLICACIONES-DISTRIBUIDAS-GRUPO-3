package ec.edu.espe.cimed.appointmentservice.dto;

import ec.edu.espe.cimed.appointmentservice.model.AppointmentStatus;
import lombok.*;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.util.Date;

@Data
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class AppointmentDto {
    private Long id;
    private Long idPatient;
    private Long idDoctor;
    private LocalDate date;
    private LocalTime time;
    private AppointmentStatus status;
    private UserDto user;
    private DoctorDto doctor;
}
