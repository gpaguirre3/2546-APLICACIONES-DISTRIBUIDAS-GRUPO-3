"use client";

import { useEffect, useState } from 'react';
import { useRouter, useParams } from 'next/navigation';
import { getCourseById, updateCourse, Curso } from '@/app/pages/course/courseApi';
import NavBar from "@/app/components/NavBar";
import Footer from "@/app/components/Footer";
import Button from "@/app/components/Button";

export default function EditCourse() {
  const [editingCourse, setEditingCourse] = useState<Curso | null>(null);
  const [errors, setErrors] = useState<{ [key: string]: string }>({});
  const router = useRouter();
  const { id } = useParams();

  useEffect(() => {
    const fetchCourse = async () => {
      try {
        if (typeof id === 'string') {
          const course = await getCourseById(parseInt(id));
          setEditingCourse(course);
        }
      } catch (error) {
        console.error('Error fetching course:', error);
      }
    };

    fetchCourse();
  }, [id]);

  const validate = () => {
    const newErrors: { [key: string]: string } = {};
    const namePattern = /^[a-zA-Z0-9\sáéíóúÁÉÍÓÚñÑ]+$/; // Permite letras, números, espacios y tildes

    if (!editingCourse?.nombre) {
      newErrors.nombre = 'El nombre es requerido';
    } else if (!namePattern.test(editingCourse.nombre)) {
      newErrors.nombre = 'El nombre contiene caracteres inválidos';
    }

    if (!editingCourse?.descripcion) {
      newErrors.descripcion = 'La descripción es requerida';
    } else if (!namePattern.test(editingCourse.descripcion)) {
      newErrors.descripcion = 'La descripción contiene caracteres inválidos';
    }

    if (editingCourse?.creditos !== undefined && editingCourse.creditos <= 0) {
      newErrors.creditos = 'Los créditos deben ser mayores que 0';
    }

    if (!editingCourse?.description) {
      newErrors.description = 'La descripción es requerida';
    } else if (!namePattern.test(editingCourse.description)) {
      newErrors.description = 'La descripción contiene caracteres inválidos';
    }

    return newErrors;
  };

  const handleUpdateCourse = async () => {
    const validationErrors = validate();
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      return;
    }

    if (editingCourse) {
      try {
        await updateCourse(editingCourse.id, editingCourse);
        router.push('/pages/course'); // Redirige a la página de cursos después de actualizar el curso
      } catch (error) {
        console.error('Error updating course:', error);
      }
    }
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col">
      <NavBar />
      <main className="container mx-auto flex-grow py-8 text-black">
        <div className="bg-white p-8 rounded-lg shadow-md max-w-lg mx-auto">
          <h2 className="text-3xl font-bold mb-6 text-center">Editar Curso</h2>
          {editingCourse && (
            <div className="grid grid-cols-1 gap-4">
              <input
                type="text"
                placeholder="Nombre"
                value={editingCourse.nombre}
                onChange={(e) => setEditingCourse({ ...editingCourse, nombre: e.target.value })}
                className="border p-3 rounded-lg w-full"
              />
              {errors.nombre && <p className="text-red-500">{errors.nombre}</p>}
              <input
                type="text"
                placeholder="Descripción"
                value={editingCourse.descripcion}
                onChange={(e) => setEditingCourse({ ...editingCourse, descripcion: e.target.value })}
                className="border p-3 rounded-lg w-full"
              />
              {errors.descripcion && <p className="text-red-500">{errors.descripcion}</p>}
              <input
                type="number"
                placeholder="Créditos"
                value={editingCourse.creditos || ''}
                onChange={(e) => setEditingCourse({ ...editingCourse, creditos: parseInt(e.target.value) || 0 })}
                className="border p-3 rounded-lg w-full"
              />
              {errors.creditos && <p className="text-red-500">{errors.creditos}</p>}
              <input
                type="text"
                placeholder="Description"
                value={editingCourse.description}
                onChange={(e) => setEditingCourse({ ...editingCourse, description: e.target.value })}
                className="border p-3 rounded-lg w-full"
              />
              {errors.description && <p className="text-red-500">{errors.description}</p>}
              <Button onClick={handleUpdateCourse} className="bg-green-500 hover:bg-green-700 text-white font-bold py-3 px-6 rounded-lg mt-4">Actualizar Curso</Button>
            </div>
          )}
        </div>
      </main>
      <Footer />
    </div>
  );
}