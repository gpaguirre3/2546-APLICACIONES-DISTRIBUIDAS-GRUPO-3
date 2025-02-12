package com.espe.ordencompra.services;

import com.espe.ordencompra.model.entity.OrdenCompra;
import com.espe.ordencompra.repository.OrdenCompraRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class OrdenCompraServiceImpl implements OrdenCompraServices {
    @Autowired
    private OrdenCompraRepository ordenCompraRepository;

    @Override
    public List<OrdenCompra> findAll() {
        return (List<OrdenCompra>) ordenCompraRepository.findAll();
    }

    @Override
    public Optional<OrdenCompra> findById(Long id) {
        return ordenCompraRepository.findById(id);
    }

    @Override
    public OrdenCompra save(OrdenCompra ordenCompra) {
        return ordenCompraRepository.save(ordenCompra);
    }

    @Override
    public void deleteById(Long id) {
        ordenCompraRepository.deleteById(id);
    }
}
