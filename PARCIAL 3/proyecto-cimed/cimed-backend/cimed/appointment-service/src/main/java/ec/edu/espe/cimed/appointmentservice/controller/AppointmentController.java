package ec.edu.espe.cimed.appointmentservice.controller;

import ec.edu.espe.cimed.appointmentservice.dto.AppointmentDto;
import ec.edu.espe.cimed.appointmentservice.service.AppointmentService;
import lombok.AllArgsConstructor;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@AllArgsConstructor
@RequestMapping("/appointments")

public class AppointmentController {
    private final AppointmentService appointmentService;

    @GetMapping
    public List<AppointmentDto> getAllAppointments() {
        return appointmentService.getAllAppointments();
    }

    @GetMapping("/{id}")
    public AppointmentDto getAppointmentById(@PathVariable Long id) {
        return appointmentService.getAppointmentById(id);
    }

    @PostMapping
    public AppointmentDto createAppointment(@RequestBody AppointmentDto appointmentDto) {
        return appointmentService.createAppointment(appointmentDto);
    }

    @PutMapping("/{id}")
    public AppointmentDto updateAppointment(@PathVariable Long id, @RequestBody AppointmentDto appointmentDto) {
        return appointmentService.updateAppointment(id, appointmentDto);
    }

    @DeleteMapping("/{id}")
    public void deleteAppointment(@PathVariable Long id) {
        appointmentService.deleteAppointment(id);
    }
}
