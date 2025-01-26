"use client";

import { useState } from 'react';
import { useRouter } from 'next/navigation';
import { createCourse, CursoPost } from '@/app/pages/course/courseApi';
import NavBar from "@/app/components/NavBar";
import Footer from "@/app/components/Footer";
import Button from "@/app/components/Button";

export default function AddCourse() {
  const [newCourse, setNewCourse] = useState<CursoPost>({
    nombre: '',
    descripcion: '',
    creditos: 0,
    description: '',
    cursoUsuarios: []
  });
  const [errors, setErrors] = useState<{ [key: string]: string }>({});
  const router = useRouter();

  const validate = () => {
    const newErrors: { [key: string]: string } = {};
    const namePattern = /^[a-zA-Z0-9\sáéíóúÁÉÍÓÚñÑ]+$/; // Permite letras, números, espacios y tildes

    if (!newCourse.nombre) {
      newErrors.nombre = 'El nombre es requerido';
    } else if (!namePattern.test(newCourse.nombre)) {
      newErrors.nombre = 'El nombre contiene caracteres inválidos';
    }

    if (!newCourse.descripcion) {
      newErrors.descripcion = 'La descripción es requerida';
    } else if (!namePattern.test(newCourse.descripcion)) {
      newErrors.descripcion = 'La descripción contiene caracteres inválidos';
    }

    if (newCourse.creditos <= 0) {
      newErrors.creditos = 'Los créditos deben ser mayores que 0';
    }

    if (!newCourse.description) {
      newErrors.description = 'La descripción es requerida';
    } else if (!namePattern.test(newCourse.description)) {
      newErrors.description = 'La descripción contiene caracteres inválidos';
    }

    return newErrors;
  };

  const handleCreateCourse = async () => {
    const validationErrors = validate();
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      return;
    }

    try {
      await createCourse(newCourse);
      router.push('/pages/course'); // Redirige a la página de cursos después de crear el curso
    } catch (error) {
      console.error('Error creating course:', error);
    }
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col">
      <NavBar />
      <main className="container mx-auto flex-grow py-8 text-black">
        <div className="bg-white p-8 rounded-lg shadow-md max-w-lg mx-auto">
          <h2 className="text-3xl font-bold mb-6 text-center">Crear Nuevo Curso</h2>
          <div className="grid grid-cols-1 gap-4">
            <input
              type="text"
              placeholder="Nombre"
              value={newCourse.nombre}
              onChange={(e) => setNewCourse({ ...newCourse, nombre: e.target.value })}
              className="border p-3 rounded-lg w-full"
            />
            {errors.nombre && <p className="text-red-500">{errors.nombre}</p>}
            <input
              type="text"
              placeholder="Descripción"
              value={newCourse.descripcion}
              onChange={(e) => setNewCourse({ ...newCourse, descripcion: e.target.value })}
              className="border p-3 rounded-lg w-full"
            />
            {errors.descripcion && <p className="text-red-500">{errors.descripcion}</p>}
            <input
              type="number"
              placeholder="Créditos"
              value={newCourse.creditos || ''}
              onChange={(e) => setNewCourse({ ...newCourse, creditos: parseInt(e.target.value) || 0 })}
              className="border p-3 rounded-lg w-full"
            />
            {errors.creditos && <p className="text-red-500">{errors.creditos}</p>}
            <input
              type="text"
              placeholder="Description"
              value={newCourse.description}
              onChange={(e) => setNewCourse({ ...newCourse, description: e.target.value })}
              className="border p-3 rounded-lg w-full"
            />
            {errors.description && <p className="text-red-500">{errors.description}</p>}
            <Button onClick={handleCreateCourse} className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-3 px-6 rounded-lg mt-4">Crear Curso</Button>
          </div>
        </div>
      </main>
      <Footer />
    </div>
  );
}