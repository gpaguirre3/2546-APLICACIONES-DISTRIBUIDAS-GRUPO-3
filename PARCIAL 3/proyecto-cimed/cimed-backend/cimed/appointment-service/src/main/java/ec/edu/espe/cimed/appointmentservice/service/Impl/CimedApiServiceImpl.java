package ec.edu.espe.cimed.appointmentservice.service.Impl;

import ec.edu.espe.cimed.appointmentservice.dto.DoctorDto;
import ec.edu.espe.cimed.appointmentservice.dto.UserDto;
import ec.edu.espe.cimed.appointmentservice.infrastructure.CimedDoctorClient;
import ec.edu.espe.cimed.appointmentservice.infrastructure.CimedUserClient;
import ec.edu.espe.cimed.appointmentservice.service.CimedApiService;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@RequiredArgsConstructor
public class CimedApiServiceImpl implements CimedApiService {

    private final CimedDoctorClient cimedDoctorClient;
    private final CimedUserClient cimedUserClient;

    @Override
    public List<DoctorDto> getAllDoctors() {
        return cimedDoctorClient.getAllDoctors();
    }

    @Override
    public List<UserDto> getAllUsers() {
        return cimedUserClient.getAllUsers();
    }
}
