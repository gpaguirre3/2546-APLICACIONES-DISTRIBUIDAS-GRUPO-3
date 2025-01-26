"use client";

import { useState } from 'react';
import { useRouter } from 'next/navigation';
import NavBar from "@/app/components/NavBar";
import Footer from "@/app/components/Footer";
import { FaUserPlus } from 'react-icons/fa';
import { Estudiante, createStudent } from '@/app/pages/course/[id]/studentsApi';
import Button from "@/app/components/Button";

export default function AddStudent() {
  const [newStudent, setNewStudent] = useState<Estudiante>({
    id: 0,
    nombre: '',
    apellido: '',
    email: '',
    fechaNacimiento: '',
    telefono: '',
    creadoEn: ''
  });
  const [errors, setErrors] = useState<{ [key: string]: string }>({});
  const router = useRouter();

  const validate = () => {
    const newErrors: { [key: string]: string } = {};
    const namePattern = /^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ]+$/; // Permite letras, espacios y tildes
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Patrón básico para validar emails
    const phonePattern = /^[0-9]+$/; // Permite solo números

    if (!newStudent.nombre) {
      newErrors.nombre = 'El nombre es requerido';
    } else if (!namePattern.test(newStudent.nombre)) {
      newErrors.nombre = 'El nombre contiene caracteres inválidos';
    }

    if (!newStudent.apellido) {
      newErrors.apellido = 'El apellido es requerido';
    } else if (!namePattern.test(newStudent.apellido)) {
      newErrors.apellido = 'El apellido contiene caracteres inválidos';
    }

    if (!newStudent.email) {
      newErrors.email = 'El email es requerido';
    } else if (!emailPattern.test(newStudent.email)) {
      newErrors.email = 'El email no es válido';
    }

    if (!newStudent.fechaNacimiento) {
      newErrors.fechaNacimiento = 'La fecha de nacimiento es requerida';
    }

    if (!newStudent.telefono) {
      newErrors.telefono = 'El teléfono es requerido';
    } else if (!phonePattern.test(newStudent.telefono)) {
      newErrors.telefono = 'El teléfono contiene caracteres inválidos';
    }

    return newErrors;
  };

  const handleAddStudent = async () => {
    const validationErrors = validate();
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      return;
    }

    try {
      await createStudent(newStudent);
      setNewStudent({
        id: 0,
        nombre: '',
        apellido: '',
        email: '',
        fechaNacimiento: '',
        telefono: '',
        creadoEn: ''
      });
      router.push('/pages/course'); // Redirige a la página de cursos después de añadir el estudiante
    } catch (error) {
      console.error('Error adding student:', error);
    }
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col">
      <NavBar />
      <main className="container mx-auto flex-grow py-8">
        <div className="bg-white p-8 rounded-lg shadow-md max-w-lg mx-auto mb-8 text-black">
          <h2 className="text-3xl font-bold mb-6 text-center">Añadir Estudiante</h2>
          <div className="grid grid-cols-1 gap-4">
            <input
              type="text"
              placeholder="Nombre"
              value={newStudent.nombre}
              onChange={(e) => setNewStudent({ ...newStudent, nombre: e.target.value })}
              className="border p-3 rounded-lg w-full"
            />
            {errors.nombre && <p className="text-red-500">{errors.nombre}</p>}
            <input
              type="text"
              placeholder="Apellido"
              value={newStudent.apellido}
              onChange={(e) => setNewStudent({ ...newStudent, apellido: e.target.value })}
              className="border p-3 rounded-lg w-full"
            />
            {errors.apellido && <p className="text-red-500">{errors.apellido}</p>}
            <input
              type="email"
              placeholder="Email"
              value={newStudent.email}
              onChange={(e) => setNewStudent({ ...newStudent, email: e.target.value })}
              className="border p-3 rounded-lg w-full"
            />
            {errors.email && <p className="text-red-500">{errors.email}</p>}
            <input
              type="date"
              placeholder="Fecha de Nacimiento"
              value={newStudent.fechaNacimiento}
              onChange={(e) => setNewStudent({ ...newStudent, fechaNacimiento: e.target.value })}
              className="border p-3 rounded-lg w-full"
            />
            {errors.fechaNacimiento && <p className="text-red-500">{errors.fechaNacimiento}</p>}
            <input
              type="text"
              placeholder="Teléfono"
              value={newStudent.telefono}
              onChange={(e) => setNewStudent({ ...newStudent, telefono: e.target.value })}
              className="border p-3 rounded-lg w-full"
            />
            {errors.telefono && <p className="text-red-500">{errors.telefono}</p>}
            <Button onClick={handleAddStudent} className="bg-blue-500 hover:bg-blue-700 text-white font-bold  rounded-lg flex items-center">
              <FaUserPlus className="mr-2" /> Añadir Estudiante
            </Button>
          </div>
        </div>
      </main>
      <Footer />
    </div>
  );
}