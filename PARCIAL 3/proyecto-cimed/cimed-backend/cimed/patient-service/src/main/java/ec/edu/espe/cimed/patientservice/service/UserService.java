package ec.edu.espe.cimed.patientservice.service;

import ec.edu.espe.cimed.patientservice.dto.UserDto;
import ec.edu.espe.cimed.patientservice.model.User;

import java.util.List;

public interface UserService {
    List<UserDto> getAllUsers();
    UserDto getUserById(Long id);
    List<User> findByUsername(String username);
    UserDto createUser(UserDto userDto);
    UserDto updateUser(Long id,UserDto userDto);
    void deleteUser(Long id);
}
