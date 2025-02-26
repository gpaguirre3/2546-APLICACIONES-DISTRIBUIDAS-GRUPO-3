package ec.edu.espe.cimed.patientservice.dto;
import ec.edu.espe.cimed.patientservice.model.UserRole;
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
public class UserDto {
    private Long id;
    private String name;
    private String lastname;
    private String email;
    private String username;
    private String password;
    @Enumerated(EnumType.STRING)
    private UserRole role;
    private String phone;
    private String address;
    private LocalDate birthdate;
    private LocalDateTime createdAt;
}
