package ec.edu.espe.cimed.doctorservice.dto;

import ec.edu.espe.cimed.doctorservice.model.DoctorAvailability;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import lombok.*;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.Date;

@Data
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Builder

public class DoctorDto {

    private Long id;
    private String name;
    private String lastname;
    private String email;
    private String phone;
    private String speciality;
    @Enumerated(EnumType.STRING)
    private DoctorAvailability availability;
    private LocalDateTime createdAt;
}
