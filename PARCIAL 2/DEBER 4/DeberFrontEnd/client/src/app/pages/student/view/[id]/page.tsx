"use client";

import { useEffect, useState } from 'react';
import { useRouter, useParams } from 'next/navigation';
import NavBar from "@/app/components/NavBar";
import Footer from "@/app/components/Footer";
import { Estudiante, getStudentById } from '@/app/pages/student/studentApi';
import { FaUserGraduate } from 'react-icons/fa';
import Button from "@/app/components/Button";

export default function ViewStudent() {
  const [student, setStudent] = useState<Estudiante | null>(null);
  const router = useRouter();
  const { id } = useParams();

  useEffect(() => {
    const fetchStudent = async () => {
      try {
        if (typeof id === 'string') {
          const studentData: Estudiante = await getStudentById(parseInt(id));
          setStudent(studentData);
        }
      } catch (error) {
        console.error('Error fetching student:', error);
      }
    };

    fetchStudent();
  }, [id]);

  const handleBack = () => {
    router.push('/pages/student');
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col">
      <NavBar />
      <main className="container mx-auto flex-grow py-8">
        <h1 className="text-3xl font-bold text-black mb-8 text-center">Ver Estudiante</h1>
        {student ? (
          <div className="bg-white p-8 rounded-lg shadow-md max-w-lg mx-auto mb-8 text-black">
            <div className="flex justify-center items-center h-20 bg-gray-200 rounded-t-lg mb-4">
              <FaUserGraduate className="text-gray-800 text-6xl" />
            </div>
            <h2 className="text-2xl text-black font-bold mb-2">{student.nombre} {student.apellido}</h2>
            <p className="text-gray-600 mb-4"><strong>Email:</strong> {student.email}</p>
            <p className="text-gray-600 mb-4"><strong>Teléfono:</strong> {student.telefono}</p>
            <Button onClick={handleBack} className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-lg mt-4">Volver</Button>
          </div>
        ) : (
          <p className="text-center text-gray-600">Cargando datos del estudiante...</p>
        )}
      </main>
      <Footer />
    </div>
  );
}