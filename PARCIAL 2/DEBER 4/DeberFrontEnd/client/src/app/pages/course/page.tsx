"use client";

import { useEffect, useState } from 'react';
import { useRouter } from 'next/navigation';
import { getCourses, deleteCourse, Curso } from '@/app/pages/course/courseApi';
import NavBar from "@/app/components/NavBar";
import Footer from "@/app/components/Footer";
import { FaBook, FaPlus, FaEdit, FaUserPlus, FaTrash } from 'react-icons/fa';
import Button from "@/app/components/Button";

export default function Home() {
  const [courses, setCourses] = useState<Curso[]>([]);
  const router = useRouter();

  useEffect(() => {
    const fetchCourses = async () => {
      try {
        const data: Curso[] = await getCourses();
        setCourses(data);
      } catch (error) {
        console.error('Error fetching courses:', error);
      }
    };

    fetchCourses();
  }, []);

  const handleDeleteCourse = async (id: number) => {
    try {
      await deleteCourse(id);
      setCourses(courses.filter(course => course.id !== id));
    } catch (error) {
      console.error('Error deleting course:', error);
    }
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col">
      <NavBar />
      <main className="container mx-auto flex-grow py-8">
        <div className="flex justify-between items-center mb-8">
          <h2 className="text-2xl font-bold text-black">Cursos</h2>
          <div className="flex space-x-4">
            <Button onClick={() => router.push('/pages/course/add')} className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded flex items-center">
              <FaPlus className="mr-2" /> Agregar Curso
            </Button>
            <Button onClick={() => router.push('/pages/course/add-student')} className="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded flex items-center">
              <FaUserPlus className="mr-2" /> Añadir Estudiante
            </Button>
          </div>
        </div>

        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
          {courses.map((course) => {
            const Icon = FaBook; // Puedes ajustar esto según tus necesidades
            return (
              <div key={course.id} className="bg-white border border-gray-300 rounded-lg shadow-md transform transition duration-500 hover:scale-105">
                <div className="flex justify-center items-center h-40 bg-gray-200 rounded-t-lg">
                  <Icon className="text-gray-800 text-6xl" />
                </div>
                <div className="p-6">
                  <h2 className="text-2xl text-gray-950 font-bold mb-2">{course.nombre}</h2>
                  <p className="text-gray-700 mb-4">{course.descripcion}</p>
                  <div className="flex space-x-4">
                    <Button onClick={() => router.push(`/pages/course/edit/${course.id}`)} className="bg-yellow-500 hover:bg-yellow-700 text-white font-bold py-2 px-4 rounded flex items-center">
                      <FaEdit className="mr-2" /> Editar
                    </Button>
                    <Button onClick={() => router.push(`/pages/course/${course.id}`)} className="bg-gray-800 hover:bg-gray-900 text-white font-bold py-2 px-4 rounded">Ver Curso</Button>
                    <Button onClick={() => handleDeleteCourse(course.id)} className="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded flex items-center">
                      <FaTrash className="mr-2" /> Borrar
                    </Button>
                  </div>
                </div>
              </div>
            );
          })}
        </div>
      </main>
      <Footer />
    </div>
  );
}