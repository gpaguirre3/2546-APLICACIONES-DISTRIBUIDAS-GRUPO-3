package com.espe.ordencompra.controller;

import com.espe.ordencompra.model.entity.OrdenCompra;
import com.espe.ordencompra.services.OrdenCompraServices;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;

@RestController
@RequestMapping("/api/ordenes-compra")
public class OrdenCompraController {
    @Autowired
    private OrdenCompraServices ordenCompraServices;

    @PostMapping
    public ResponseEntity<?> crear(@Valid @RequestBody OrdenCompra ordenCompra, BindingResult result) {
        if (validar(result) != null) {
            return validar(result);
        }
        return ResponseEntity.status(HttpStatus.CREATED).body(ordenCompraServices.save(ordenCompra));
    }

    @GetMapping
    public List<OrdenCompra> listar() {
        return ordenCompraServices.findAll();
    }

    @GetMapping("/{id}")
    public ResponseEntity<?> buscarPorId(@PathVariable Long id) {
        Optional<OrdenCompra> ordenCompraOptional = ordenCompraServices.findById(id);
        if (ordenCompraOptional.isPresent()) {
            return ResponseEntity.ok().body(ordenCompraOptional.get());
        }
        return ResponseEntity.notFound().build();
    }

    @PutMapping("/{id}")
    public ResponseEntity<?> editar(@Valid @RequestBody OrdenCompra ordenCompra, @PathVariable Long id, BindingResult result) {
        if (validar(result) != null) {
            return validar(result);
        }
        Optional<OrdenCompra> ordenCompraOptional = ordenCompraServices.findById(id);
        if (ordenCompraOptional.isPresent()) {
            OrdenCompra ordenCompraDB = ordenCompraOptional.get();
            ordenCompraDB.setProveedor(ordenCompra.getProveedor());
            ordenCompraDB.setDescripcion(ordenCompra.getDescripcion());
            ordenCompraDB.setCantidad(ordenCompra.getCantidad());
            ordenCompraDB.setFechaOrden(ordenCompra.getFechaOrden());
            return ResponseEntity.status(HttpStatus.CREATED).body(ordenCompraServices.save(ordenCompraDB));
        }
        return ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<?> eliminar(@PathVariable Long id) {
        Optional<OrdenCompra> ordenCompraOptional = ordenCompraServices.findById(id);
        if (ordenCompraOptional.isPresent()) {
            ordenCompraServices.deleteById(id);
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }

    public ResponseEntity<?> validar(BindingResult result) {
        if (result.hasErrors()) {
            Map<String, String> errores = new HashMap<>();
            result.getFieldErrors().forEach(
                    err -> errores.put(
                            err.getField(), err.getDefaultMessage()
                    )
            );
            return ResponseEntity.badRequest().body(errores);
        }
        return null;
    }
}
