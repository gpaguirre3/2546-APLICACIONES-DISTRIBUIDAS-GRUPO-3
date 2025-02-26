package ec.edu.espe.cimed.doctorservice.model;

import jakarta.persistence.*;
import lombok.*;
import org.springframework.data.annotation.CreatedDate;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.Date;

@Data
@Getter
@Setter
@Builder
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "doctors")
@EntityListeners(AuditingEntityListener.class)

public class Doctor {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String name;

    private String lastname;

    @Column(unique = true)
    private String email;

    private String phone;

    private String speciality;

    @Enumerated(EnumType.STRING)
    @Builder.Default
    private DoctorAvailability availability = DoctorAvailability.AVAILABLE;

    @CreatedDate
    private LocalDateTime createdAt;
}
