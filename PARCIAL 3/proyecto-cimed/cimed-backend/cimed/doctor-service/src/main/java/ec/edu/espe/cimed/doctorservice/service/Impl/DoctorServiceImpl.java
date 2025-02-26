package ec.edu.espe.cimed.doctorservice.service.Impl;

import ec.edu.espe.cimed.doctorservice.dto.DoctorDto;
import ec.edu.espe.cimed.doctorservice.model.Doctor;
import ec.edu.espe.cimed.doctorservice.repository.DoctorRepository;
import ec.edu.espe.cimed.doctorservice.service.DoctorService;
import lombok.AllArgsConstructor;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@AllArgsConstructor
public class DoctorServiceImpl implements DoctorService {

    private final DoctorRepository doctorRepository;
    private final ModelMapper modelMapper;

    @Override
    public List<DoctorDto> getAllDoctors() {
        List<Doctor> doctors = doctorRepository.findAll();
        List<DoctorDto> doctorDtos = doctors.stream()
                .map(doctor -> modelMapper.map(doctor, DoctorDto.class))
                .toList();
        return doctorDtos;
    }

    @Override
    public DoctorDto getDoctorById(Long id) {
        return doctorRepository.findById(id)
                .map(doctor -> modelMapper.map(doctor, DoctorDto.class))
                .orElse(null);
    }

    @Override
    public List<Doctor> findByName(String name) {
        List<Doctor> doctors = doctorRepository.findByName(name);
        List<DoctorDto> doctorDtos = doctors.stream()
                .map(doctor -> modelMapper.map(doctor, DoctorDto.class))
                .toList();
        return doctors;
    }

    @Override
    public DoctorDto createDoctor(DoctorDto doctorDto) {
        Doctor entity = Doctor.builder()
                .name(doctorDto.getName())
                .lastname(doctorDto.getLastname())
                .email(doctorDto.getEmail())
                .phone(doctorDto.getPhone())
                .speciality(doctorDto.getSpeciality())
                .build();
        return modelMapper.map(doctorRepository.save(entity), DoctorDto.class);
    }

    @Override
    public DoctorDto updateDoctor(Long id, DoctorDto doctorDto) {
        Doctor entity = doctorRepository.findById(id)
                .orElseThrow(() -> new IllegalArgumentException("Doctor not found"));
        entity.setName(doctorDto.getName());
        entity.setLastname(doctorDto.getLastname());
        entity.setEmail(doctorDto.getEmail());
        entity.setPhone(doctorDto.getPhone());
        entity.setSpeciality(doctorDto.getSpeciality());
        if (doctorDto.getAvailability() != null) {
            entity.setAvailability(doctorDto.getAvailability());
        }
        return modelMapper.map(doctorRepository.save(entity), DoctorDto.class);
    }

    @Override
    public void deleteDoctor(Long id) {
        doctorRepository.deleteById(id);
    }
}
