package ec.edu.espe.cimed.appointmentservice.service;

import ec.edu.espe.cimed.appointmentservice.dto.DoctorDto;
import ec.edu.espe.cimed.appointmentservice.dto.UserDto;

import java.util.List;

public interface CimedApiService {
    List<DoctorDto> getAllDoctors();
    List<UserDto> getAllUsers();
}
