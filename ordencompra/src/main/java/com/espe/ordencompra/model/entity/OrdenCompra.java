package com.espe.ordencompra.model.entity;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.NotNull;
import java.util.Date;

@Entity
@Table(name = "OrdenCompra", uniqueConstraints = {
        @UniqueConstraint(columnNames = {"numeroOrden"})
})
public class OrdenCompra {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;



    @NotEmpty
    @Column(nullable = false)
    private String proveedor;

    @NotEmpty
    @Column(nullable = false)
    private String descripcion;

    @NotNull
    @Column(nullable = false)
    private int cantidad;

    @NotNull
    @Temporal(TemporalType.DATE)
    @Column(nullable = false)
    private Date fechaOrden;

    // Getters y Setters
    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }



    public String getProveedor() {
        return proveedor;
    }

    public void setProveedor(String proveedor) {
        this.proveedor = proveedor;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public int getCantidad() {
        return cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }

    public Date getFechaOrden() {
        return fechaOrden;
    }

    public void setFechaOrden(Date fechaOrden) {
        this.fechaOrden = fechaOrden;
    }
}
