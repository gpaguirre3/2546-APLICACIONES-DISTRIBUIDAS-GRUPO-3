// CursoServiceImpl.java
package com.espe.micro_cursos.services;

import com.espe.micro_cursos.clients.UsuarioClientRest;
import com.espe.micro_cursos.model.Usuario;
import com.espe.micro_cursos.model.entity.Curso;
import com.espe.micro_cursos.model.entity.CursoUsuario;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import com.espe.micro_cursos.repositories.CursoRepository;
import java.util.List;
import java.util.Optional;

@Service
public class CursoServiceImpl implements CursoService {

    //Autowire sirve para inyectar dependencias
    @Autowired
    private CursoRepository repository;

    @Autowired
    private UsuarioClientRest clientRest;

    @Override
    public List<Curso> findAll() {
        return (List<Curso>) repository.findAll();
    }

    @Override
    public Optional<Curso> findById(Long id) {
        return repository.findById(id);
    }

    @Override
    public Curso save(Curso curso) {
        return repository.save(curso);
    }

    @Override
    public void deleteById(Long id) {
        repository.deleteById(id);
    }

    //Override sirve para sobreescribir un metodo de la clase padre
    //Este metodo sirve para añadir un usuario a un curso
    @Override
    public Optional<Usuario> addUser(Usuario usuario, Long id) {
        //Optional: es un contenedor que puede o no contener un valor no nulo
        // Creo un objeto de tipo Optional y le paso el valor que me devuelve el metodo findById Curso
        Optional<Curso> optional = repository.findById(id);
        System.out.println(optional);
        //Verifico si el objeto optional tiene un valor
        if (optional.isPresent()) {
            // Si el objeto optional tiene un valor, obtengo el valor y lo guardo en la variable curso
            Usuario usaurioTemp = clientRest.findById(usuario.getId());
            //Obtengo el valor del optional
            Curso curso = optional.get();
            //Creo un objeto de tipo CursoUsuario
            CursoUsuario cursoUsuario = new CursoUsuario();
            //Seteo el id del usuario
            cursoUsuario.setUsuarioId(usaurioTemp.getId());

            //Añado el cursoUsuario al curso
            curso.addCursoUsuario(cursoUsuario);
            //Guardo el curso
            repository.save(curso);
            //Retorno el usuario
            return Optional.of(usaurioTemp);
        }
        //Retorno un valor vacio
        return Optional.empty();
    }


   @Override
public void removeUser(Long id, Long idUsuario) {
    Optional<Curso> optional = repository.findById(id);
    if (optional.isPresent()) {
        Curso curso = optional.get();
        Optional<CursoUsuario> cursoUsuarioOptional = curso.getCursoUsuarios().stream()
                .filter(cursoUsuario -> cursoUsuario.getUsuarioId().equals(idUsuario))
                .findFirst();
        if (cursoUsuarioOptional.isPresent()) {
            curso.removeCursoUsuario(cursoUsuarioOptional.get());
            repository.save(curso);
        }
    }
}


}