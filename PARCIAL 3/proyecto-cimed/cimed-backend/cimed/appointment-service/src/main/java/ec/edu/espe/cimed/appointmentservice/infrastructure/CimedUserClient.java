package ec.edu.espe.cimed.appointmentservice.infrastructure;

import ec.edu.espe.cimed.appointmentservice.dto.UserDto;
import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.GetMapping;

import java.util.List;

@FeignClient(name = "cimed-user", url = "${app.feign.client.cimed-user.url}")

public interface CimedUserClient {

    @GetMapping("/users")
    List<UserDto> getAllUsers();
}
