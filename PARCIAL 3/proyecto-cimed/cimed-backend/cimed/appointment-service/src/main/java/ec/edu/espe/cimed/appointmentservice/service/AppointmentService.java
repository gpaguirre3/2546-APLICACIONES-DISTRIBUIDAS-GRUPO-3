package ec.edu.espe.cimed.appointmentservice.service;

import ec.edu.espe.cimed.appointmentservice.dto.AppointmentDto;

import java.util.List;

public interface AppointmentService {
    List<AppointmentDto> getAllAppointments();
    AppointmentDto getAppointmentById(Long id);
    AppointmentDto createAppointment(AppointmentDto appointmentDto);
    AppointmentDto updateAppointment(Long id,AppointmentDto appointmentDto);
    void deleteAppointment(Long id);

}
