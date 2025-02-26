package ec.edu.espe.cimed.appointmentservice.dto;

import com.fasterxml.jackson.annotation.JsonAlias;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class UserDto {
    @JsonAlias("id")
    private Long id;
    @JsonAlias("name")
    private String name;
    @JsonAlias("lastname")
    private String lastName;
    @JsonAlias("email")
    private String email;
    @JsonAlias("phone")
    private String phone;
    @JsonAlias("address")
    private String address;
}
