package com.espe.micro_cursos.clients;


import com.espe.micro_cursos.model.Usuario;
import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;

//@FeignClient(name = "micro-cursos", url = "http://localhost:8002/api/estudiantes/")
@FeignClient(name = "cursos", url = "http://cursos:8002/api/estudiantes/")
public interface UsuarioClientRest {

    //Metodo para buscar un usuario por su id
    //PathVariable: se usa para indicar que el valor de la variable se obtiene de la url
    @GetMapping("/{id}")
    Usuario findById(@PathVariable Long id);

}
