package ec.edu.espe.cimed.appointmentservice.dto;

import com.fasterxml.jackson.annotation.JsonAlias;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor

public class DoctorDto {
    @JsonAlias("id")
    private Long id;
    @JsonAlias("name")
    private String name;
    @JsonAlias("lastname")
    private String lastName;
    @JsonAlias("speciality")
    private String speciality;
}
