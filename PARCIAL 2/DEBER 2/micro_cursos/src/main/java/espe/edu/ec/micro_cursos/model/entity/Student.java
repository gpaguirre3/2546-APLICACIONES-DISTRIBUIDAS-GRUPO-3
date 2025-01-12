package espe.edu.ec.micro_cursos.model.entity;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import jakarta.persistence.*;
import lombok.*;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@Entity
@Data
@AllArgsConstructor
@NoArgsConstructor
@Builder
@ToString
@Table(name = "students")

public class Student {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column (nullable = false)
    private String name;

    @Column (nullable = false)
    private String lastName;

    @Column (nullable = false)
    private String email;

    @Column (nullable = false)
    private String phone;

    @Temporal(TemporalType.DATE)
    @JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "dd-MM-yyyy") // Formato para JSON
    @Column(nullable = false)
    private Date birthday;

    @Temporal(TemporalType.DATE) // Guarda solo la fecha en la base de datos
    @JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd") // Formato de salida JSON
    @Column(nullable = false, updatable = false)
    private Date createdAt;

    @ManyToMany
    @JoinTable(name = "students_courses",
            joinColumns = @JoinColumn(name = "student_id"),
            inverseJoinColumns = @JoinColumn(name = "course_id"))
    //@JsonManagedReference
    private List<Course> courses;

    @PrePersist
    protected void onCreate() {
        this.createdAt = new Date();
    }
}
