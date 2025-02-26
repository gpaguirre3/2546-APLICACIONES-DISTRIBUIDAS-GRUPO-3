package ec.edu.espe.cimed.appointmentservice.service.Impl;

import ec.edu.espe.cimed.appointmentservice.dto.AppointmentDto;
import ec.edu.espe.cimed.appointmentservice.dto.DoctorDto;
import ec.edu.espe.cimed.appointmentservice.dto.UserDto;
import ec.edu.espe.cimed.appointmentservice.infrastructure.CimedDoctorClient;
import ec.edu.espe.cimed.appointmentservice.infrastructure.CimedUserClient;
import ec.edu.espe.cimed.appointmentservice.model.Appointment;
import ec.edu.espe.cimed.appointmentservice.repository.AppointmentRepository;
import ec.edu.espe.cimed.appointmentservice.service.AppointmentService;
import lombok.AllArgsConstructor;
import org.modelmapper.ModelMapper;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@Service
@AllArgsConstructor
public class AppointmentServiceImpl implements AppointmentService {

    private final AppointmentRepository appointmentRepository;
    private final ModelMapper modelMapper;
    private final CimedUserClient cimedUserClient;
    private final CimedDoctorClient cimedDoctorClient;

    @Override
    public List<AppointmentDto> getAllAppointments() {
        List<UserDto> users = cimedUserClient.getAllUsers();
        List<DoctorDto> doctors = cimedDoctorClient.getAllDoctors();
        List<Appointment> appointments = appointmentRepository.findAll();
        return appointments.stream()
                .map(appointment -> {
                    // Mapear la entidad Appointment a AppointmentDto
                    AppointmentDto appointmentDto = modelMapper.map(appointment, AppointmentDto.class);

                    // Asignar el objeto UserDto completo al AppointmentDto
                    getUserById(appointment.getIdPatient(), users).ifPresent(appointmentDto::setUser);

                    // Asignar el objeto DoctorDto completo al AppointmentDto
                    getDoctorById(appointment.getIdDoctor(), doctors).ifPresent(appointmentDto::setDoctor);

                    return appointmentDto;
                })
                .collect(Collectors.toList());
    }

    @Override
    public AppointmentDto getAppointmentById(Long id) {
        // Buscar la cita en el repositorio por su ID
        Appointment appointment = appointmentRepository.findById(id)
                .orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND, "Appointment not found"));

        // Mapear la entidad Appointment a AppointmentDto
        AppointmentDto appointmentDto = modelMapper.map(appointment, AppointmentDto.class);

        // Obtener todos los usuarios y doctores desde los servicios correspondientes
        List<UserDto> users = cimedUserClient.getAllUsers();
        List<DoctorDto> doctors = cimedDoctorClient.getAllDoctors();

        // Asignar el objeto UserDto completo al AppointmentDto
        getUserById(appointment.getIdPatient(), users).ifPresent(appointmentDto::setUser);

        // Asignar el objeto DoctorDto completo al AppointmentDto
        getDoctorById(appointment.getIdDoctor(), doctors).ifPresent(appointmentDto::setDoctor);

        return appointmentDto;
    }

    @Override
    public AppointmentDto createAppointment(AppointmentDto appointmentDto) {
        List<UserDto> users = cimedUserClient.getAllUsers();
        List<DoctorDto> doctors = cimedDoctorClient.getAllDoctors();

        Optional<UserDto> userDto = getUserById(appointmentDto.getIdPatient(), users);
        if (userDto.isEmpty()){
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "User not found");
        }
        Optional<DoctorDto> doctorDto = getDoctorById(appointmentDto.getIdDoctor(), doctors);
        if (doctorDto.isEmpty()){
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Doctor not found");
        }

        Appointment entity = Appointment.builder()
                .idPatient(appointmentDto.getIdPatient())
                .idDoctor(appointmentDto.getIdDoctor())
                .date(appointmentDto.getDate())
                .time(appointmentDto.getTime())
                .build();

        return modelMapper.map(appointmentRepository.save(entity), AppointmentDto.class);
    }

    @Override
    public AppointmentDto updateAppointment(Long id, AppointmentDto appointmentDto) {
        Appointment entity = appointmentRepository.findById(id)
                .orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND, "Appointment not found"));
        entity.setIdPatient(appointmentDto.getIdPatient());
        entity.setIdDoctor(appointmentDto.getIdDoctor());
        entity.setDate(appointmentDto.getDate());
        entity.setTime(appointmentDto.getTime());
        if(appointmentDto.getStatus() != null){
            entity.setStatus(appointmentDto.getStatus());
        }
        return modelMapper.map(appointmentRepository.save(entity), AppointmentDto.class);
    }

    @Override
    public void deleteAppointment(Long id) {
        appointmentRepository.deleteById(id);
    }

    private Optional<UserDto> getUserById(Long id, List<UserDto> users) {
        return users.stream()
                .filter(user -> user.getId().equals(id))
                .findFirst();
    }

    private Optional<DoctorDto> getDoctorById(Long id, List<DoctorDto> doctors) {
        return doctors.stream()
                .filter(doctor -> doctor.getId().equals(id))
                .findFirst();
    }
}
