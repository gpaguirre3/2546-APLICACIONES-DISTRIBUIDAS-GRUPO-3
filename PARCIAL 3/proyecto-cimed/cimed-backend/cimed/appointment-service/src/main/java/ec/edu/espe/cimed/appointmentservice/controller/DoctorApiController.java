package ec.edu.espe.cimed.appointmentservice.controller;

import ec.edu.espe.cimed.appointmentservice.dto.DoctorDto;
import ec.edu.espe.cimed.appointmentservice.infrastructure.CimedDoctorClient;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequiredArgsConstructor
@RequestMapping("/doctors")
public class DoctorApiController {

    private final CimedDoctorClient cimedDoctorClient;

    @GetMapping
    public List<DoctorDto> getAllDoctors() {
        return cimedDoctorClient.getAllDoctors();
    }
}
