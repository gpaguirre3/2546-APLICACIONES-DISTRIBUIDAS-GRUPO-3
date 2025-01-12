package espe.edu.ec.micro_cursos.model.entity;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotEmpty;
import lombok.Builder;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.ToString;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@Entity
@Data
@AllArgsConstructor
@NoArgsConstructor
@Builder
@ToString
@Table(name = "courses")

public class Course {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column (nullable = false)
    private String name;

    @Column (nullable = false)
    private String description;

    @Column (nullable = false)
    private int credits;

    @Temporal(TemporalType.DATE) // Guarda solo la fecha en la base de datos
    @JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd") // Formato de salida JSON
    @Column(nullable = false, updatable = false)
    private Date createdAt;

    @ManyToMany(mappedBy = "courses")
    @JsonIgnore
    //@JsonBackReference
    private List<Student> students;

    @PrePersist
    protected void onCreate() {
        this.createdAt = new Date();
    }
}
