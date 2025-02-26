package ec.edu.espe.cimed.appointmentservice.infrastructure;

import ec.edu.espe.cimed.appointmentservice.dto.DoctorDto;
import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.GetMapping;

import java.util.List;

@FeignClient(name = "cimed-doctor", url = "${app.feign.client.cimed-doctor.url}")

public interface CimedDoctorClient {

    @GetMapping("/doctors")
    List<DoctorDto> getAllDoctors();
}
