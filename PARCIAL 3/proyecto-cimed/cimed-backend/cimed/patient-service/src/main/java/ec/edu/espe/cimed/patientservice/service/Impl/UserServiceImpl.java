package ec.edu.espe.cimed.patientservice.service.Impl;

import ec.edu.espe.cimed.patientservice.dto.UserDto;
import ec.edu.espe.cimed.patientservice.model.User;
import ec.edu.espe.cimed.patientservice.repository.UserRepository;
import ec.edu.espe.cimed.patientservice.service.UserService;
import lombok.AllArgsConstructor;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@AllArgsConstructor
public class UserServiceImpl implements UserService {

    private final UserRepository userRepository;
    private final ModelMapper modelMapper;

    @Override
    public List<UserDto> getAllUsers() {
        List<User> users = userRepository.findAll();
        List<UserDto> userDtos = users.stream()
                .map(user -> modelMapper.map(user, UserDto.class))
                .toList();
        return userDtos;
    }

    @Override
    public UserDto getUserById(Long id) {
        return userRepository.findById(id)
                .map(user -> modelMapper.map(user, UserDto.class))
                .orElse(null);
    }

    @Override
    public List<User> findByUsername(String username) {
        List<User> users = userRepository.findByUsername(username);
        List<UserDto> userDtos = users.stream()
                .map(user -> modelMapper.map(user, UserDto.class))
                .toList();
        return users;

    }

    @Override
    public UserDto createUser(UserDto userDto) {
        User entity = User.builder()
                .name(userDto.getName())
                .lastname(userDto.getLastname())
                .email(userDto.getEmail())
                .username(userDto.getUsername())
                .password(userDto.getPassword())
                .phone(userDto.getPhone())
                .address(userDto.getAddress())
                .birthdate(userDto.getBirthdate())
                .build();
        return modelMapper.map(userRepository.save(entity), UserDto.class);
    }

    @Override
    public UserDto updateUser(Long id, UserDto userDto) {
        User entity = userRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("User not found"));
        entity.setName(userDto.getName());
        entity.setLastname(userDto.getLastname());
        entity.setEmail(userDto.getEmail());
        entity.setUsername(userDto.getUsername());
        entity.setPassword(userDto.getPassword());
        entity.setPhone(userDto.getPhone());
        entity.setAddress(userDto.getAddress());
        entity.setBirthdate(userDto.getBirthdate());
        if(userDto.getRole() != null) {
            entity.setRole(userDto.getRole());
        }

        return modelMapper.map(userRepository.save(entity), UserDto.class);
    }

    @Override
    public void deleteUser(Long id) {
        userRepository.deleteById(id);
    }
}
