package ec.edu.espe.cimed.doctorservice.service;

import ec.edu.espe.cimed.doctorservice.dto.DoctorDto;
import ec.edu.espe.cimed.doctorservice.model.Doctor;

import java.util.List;

public interface DoctorService {
    List<DoctorDto> getAllDoctors();
    DoctorDto getDoctorById(Long id);
    List<Doctor> findByName(String name);
    DoctorDto createDoctor(DoctorDto doctorDto);
    DoctorDto updateDoctor(Long id,DoctorDto doctorDto);
    void deleteDoctor(Long id);
}
