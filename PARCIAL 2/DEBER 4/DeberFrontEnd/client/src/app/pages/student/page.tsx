/* eslint-disable @typescript-eslint/no-unused-vars */

"use client";

import { useEffect, useState } from 'react';
import { useRouter, useParams } from 'next/navigation';
import NavBar from "@/app/components/NavBar";
import Footer from "@/app/components/Footer";
import { FaUserGraduate } from 'react-icons/fa';
import { Estudiante, getAllStudents, deleteStudentById } from '@/app/pages/student/studentApi';
import Button from "@/app/components/Button";

export default function StudentList() {
  const [students, setStudents] = useState<Estudiante[]>([]);
  const router = useRouter();

  useEffect(() => {
    const fetchStudents = async () => {
      try {
        const allStudents: Estudiante[] = await getAllStudents();
        setStudents(allStudents);
      } catch (error) {
        console.error('Error fetching students:', error);
      }
    };

    fetchStudents();
  }, []);

  const handleView = (id: number) => {
    router.push(`/pages/student/view/${id}`);
  };

  const handleEdit = (id: number) => {
    router.push(`/pages/student/edit/${id}`);
  };

  const handleDelete = async (id: number) => {
    try {
      await deleteStudentById(id);
      setStudents(students.filter(student => student.id !== id));
    } catch (error) {
      console.error('Error deleting student:', error);
    }
  }
  
  return (
    <div className="min-h-screen bg-gray-100 flex flex-col">
      <NavBar />
      <main className="container mx-auto flex-grow py-8">
        <h1 className="text-3xl font-bold text-black mb-8 text-center">Listado de Estudiantes</h1>
        {students.length === 0 ? (
          <p className="text-center text-gray-600">No hay estudiantes registrados.</p>
        ) : (
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
            {students.map((student) => (
              <div key={student.id} className="bg-white border border-gray-300 rounded-lg shadow-md p-6 transform transition duration-500 hover:scale-105">
                <div className="flex justify-center items-center h-20 bg-gray-200 rounded-t-lg mb-4">
                  <FaUserGraduate className="text-gray-800 text-6xl" />
                </div>
                <h2 className="text-2xl text-black font-bold mb-2">{student.nombre} {student.apellido}</h2>
                <p className="text-gray-600 mb-4">{student.email}</p>
                <p className="text-gray-600 mb-4">{student.telefono}</p>
                <div className="flex justify-around mt-4">
                  <Button onClick={() => handleView(student.id)} className="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-lg">Ver</Button>
                  <Button onClick={() => handleEdit(student.id)} className="bg-yellow-500 hover:bg-yellow-700 text-white font-bold py-2 px-4 rounded-lg">Editar</Button>
                  <Button onClick={() => handleDelete(student.id)} className="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded-lg">Eliminar</Button>
                </div>
              </div>
            ))}
          </div>
        )}
      </main>
      <Footer />
    </div>
  );
}

/* eslint-enable @typescript-eslint/no-unused-vars */