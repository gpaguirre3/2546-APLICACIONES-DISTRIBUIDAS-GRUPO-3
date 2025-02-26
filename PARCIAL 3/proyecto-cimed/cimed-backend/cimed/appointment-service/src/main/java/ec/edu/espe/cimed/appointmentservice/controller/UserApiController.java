package ec.edu.espe.cimed.appointmentservice.controller;

import ec.edu.espe.cimed.appointmentservice.dto.UserDto;
import ec.edu.espe.cimed.appointmentservice.infrastructure.CimedUserClient;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequiredArgsConstructor
@RequestMapping("/users")
public class UserApiController {

    private final CimedUserClient cimedUserClient;

    @GetMapping
    public List<UserDto> getAllUsers() {
        return cimedUserClient.getAllUsers();
    }
}
