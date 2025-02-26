package ec.edu.espe.cimed.patientservice.model;

import com.fasterxml.jackson.annotation.JsonFormat;
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
@Table(name = "users")
@EntityListeners(AuditingEntityListener.class)

public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String name;

    private String lastname;

    @Column(unique = true)
    private String email;

    private String username;

    private String password;

    @Enumerated(EnumType.STRING)
    @Builder.Default
    private UserRole role = UserRole.PATIENT;

    private String phone;

    private String address;

    @Temporal(TemporalType.DATE)
    @JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "dd-MM-yyyy") // Formato para JSON
    @Column(nullable = false)
    private LocalDate birthdate;

    @CreatedDate
    private LocalDateTime createdAt;
}
