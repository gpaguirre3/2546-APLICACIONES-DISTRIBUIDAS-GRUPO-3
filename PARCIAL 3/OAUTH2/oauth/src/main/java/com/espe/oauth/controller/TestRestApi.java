package com.espe.oauth.controller;

import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Map;

@RestController
public class TestRestApi {

    @GetMapping("/dataTest")
    //@PreAuthorize("hasAuthority('SCOPE_USER')")
    public Map<String,Object> dataTest(Authentication authentication){
        return Map.of(
                "message","Data Test",
                "username",authentication.getName(),
                "authorities",authentication.getAuthorities()
        );
    }
    @GetMapping("/nuevaruta")
    @PreAuthorize("hasAuthority('SCOPE_USER')")
    public Map<String,Object> nuevaruta(String data){
        return Map.of("dataSaved",data);
    }

    @PostMapping("/saveData")
    @PreAuthorize("hasAuthority('SCOPE_ADMIN')")
    public Map<String,Object> saveData(String data){
        return Map.of("dataSaved",data);
    }
}