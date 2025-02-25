package com.espe.oauth.seguridad;

import com.espe.oauth.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import java.util.*;
import java.util.stream.Collectors;

@Service
public class CustomUserDetailsService implements UserDetailsService{
    @Autowired
    private UserRepository userRepositorio;

    //carga un user por el nombre o email
    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        com.espe.oauth.model.User user = userRepositorio.findByUsername(username)
                .orElseThrow(() -> new UsernameNotFoundException("Usuario no encontrado con ese username : " + username));

        return new User(user.getUsername(), user.getPassword(), List.of(new SimpleGrantedAuthority(user.getRole())));
    }
}
