package com.espe.ordencompra.services;

import com.espe.ordencompra.model.entity.OrdenCompra;

import java.util.List;
import java.util.Optional;

public interface OrdenCompraServices {
    List<OrdenCompra> findAll();
    Optional<OrdenCompra> findById(Long id);
    OrdenCompra save(OrdenCompra ordenCompra);
    void deleteById(Long id);
}
