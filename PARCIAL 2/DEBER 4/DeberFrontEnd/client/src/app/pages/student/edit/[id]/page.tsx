"use client";

import { useEffect, useState } from 'react';
import { useRouter, useParams } from 'next/navigation';
import NavBar from "@/app/components/NavBar";
import Footer from "@/app/components/Footer";
import { Estudiante, getStudentById, updateStudent } from '@/app/pages/student/studentApi';
import Button from "@/app/components/Button";

export default function EditStudent() {
  const [student, setStudent] = useState<Estudiante | null>(null);
  const [nombre, setNombre] = useState('');
  const [apellido, setApellido] = useState('');
  const [email, setEmail] = useState('');
  const [telefono, setTelefono] = useState('');
  const [errors, setErrors] = useState<{ [key: string]: string }>({});
  const router = useRouter();
  const { id } = useParams();

  useEffect(() => {
    const fetchStudent = async () => {
      try {
        if (typeof id === 'string') {
          const studentData: Estudiante = await getStudentById(parseInt(id));
          setStudent(studentData);
          setNombre(studentData.nombre);
          setApellido(studentData.apellido);
          setEmail(studentData.email);
          setTelefono(studentData.telefono);
        }
      } catch (error) {
        console.error('Error fetching student:', error);
      }
    };

    fetchStudent();
  }, [id]);

  const validate = () => {
    const newErrors: { [key: string]: string } = {};
    const namePattern = /^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ]+$/; // Permite letras, espacios y tildes
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Patrón básico para validar emails
    const phonePattern = /^[0-9]+$/; // Permite solo números

    if (!nombre) {
      newErrors.nombre = 'El nombre es requerido';
    } else if (!namePattern.test(nombre)) {
      newErrors.nombre = 'El nombre contiene caracteres inválidos';
    }

    if (!apellido) {
      newErrors.apellido = 'El apellido es requerido';
    } else if (!namePattern.test(apellido)) {
      newErrors.apellido = 'El apellido contiene caracteres inválidos';
    }

    if (!email) {
      newErrors.email = 'El email es requerido';
    } else if (!emailPattern.test(email)) {
      newErrors.email = 'El email no es válido';
    }

    if (!telefono) {
      newErrors.telefono = 'El teléfono es requerido';
    } else if (!phonePattern.test(telefono)) {
      newErrors.telefono = 'El teléfono contiene caracteres inválidos';
    }

    return newErrors;
  };

  const handleUpdate = async () => {
    const validationErrors = validate();
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      return;
    }

    try {
      if (student) {
        const updatedStudent: Estudiante = { ...student, nombre, apellido, email, telefono };
        await updateStudent(student.id, updatedStudent);
        router.push('/pages/student'); // Redirige a la página de estudiantes después de actualizar el estudiante
      }
    } catch (error) {
      console.error('Error updating student:', error);
    }
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col">
      <NavBar />
      <main className="container mx-auto flex-grow py-8">
        <h1 className="text-3xl font-bold text-black mb-8 text-center">Editar Estudiante</h1>
        {student ? (
          <div className="bg-white p-8 rounded-lg shadow-md max-w-lg mx-auto mb-8 text-black">
            <div className="grid grid-cols-1 gap-4">
              <input
                type="text"
                value={nombre}
                onChange={(e) => setNombre(e.target.value)}
                placeholder="Nombre"
                className="border p-3 rounded-lg w-full"
              />
              {errors.nombre && <p className="text-red-500">{errors.nombre}</p>}
              <input
                type="text"
                value={apellido}
                onChange={(e) => setApellido(e.target.value)}
                placeholder="Apellido"
                className="border p-3 rounded-lg w-full"
              />
              {errors.apellido && <p className="text-red-500">{errors.apellido}</p>}
              <input
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                placeholder="Email"
                className="border p-3 rounded-lg w-full"
              />
              {errors.email && <p className="text-red-500">{errors.email}</p>}
              <input
                type="text"
                value={telefono}
                onChange={(e) => setTelefono(e.target.value)}
                placeholder="Teléfono"
                className="border p-3 rounded-lg w-full"
              />
              {errors.telefono && <p className="text-red-500">{errors.telefono}</p>}
              <Button onClick={handleUpdate} className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-3 px-6 rounded-lg mt-4">Actualizar</Button>
            </div>
          </div>
        ) : (
          <p className="text-center text-gray-600">Cargando datos del estudiante...</p>
        )}
      </main>
      <Footer />
    </div>
  );
}