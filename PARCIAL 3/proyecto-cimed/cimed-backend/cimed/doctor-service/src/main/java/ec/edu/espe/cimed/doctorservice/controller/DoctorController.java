package ec.edu.espe.cimed.doctorservice.controller;

import ec.edu.espe.cimed.doctorservice.dto.DoctorDto;
import ec.edu.espe.cimed.doctorservice.model.Doctor;
import ec.edu.espe.cimed.doctorservice.service.DoctorService;
import lombok.AllArgsConstructor;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@AllArgsConstructor
@RequestMapping("/doctors")
public class DoctorController {
    private final DoctorService doctorService;

    @GetMapping
    public List<DoctorDto> getAllDoctors() {
        return doctorService.getAllDoctors();
    }

    @GetMapping("/{id}")
    public DoctorDto getDoctorById(@PathVariable Long id) {
        return doctorService.getDoctorById(id);
    }

    @GetMapping("/name/{name}")
    public List<Doctor> findByUsername(@PathVariable String name) {
        return doctorService.findByName(name);
    }

    @PostMapping
    public DoctorDto createDoctor(@RequestBody DoctorDto doctorDto) {
        return doctorService.createDoctor(doctorDto);
    }

    @PutMapping("/{id}")
    public DoctorDto updateDoctor(@PathVariable Long id, @RequestBody DoctorDto doctorDto) {
        return doctorService.updateDoctor(id, doctorDto);
    }

    @DeleteMapping("/{id}")
    public void deleteDoctor(@PathVariable Long id) {
        doctorService.deleteDoctor(id);
    }
}
