/* eslint-disable @typescript-eslint/no-unused-vars */

"use client";

import { useEffect, useState } from 'react';
import { useRouter, useParams } from 'next/navigation';
import NavBar from "@/app/components/NavBar";
import Footer from "@/app/components/Footer";
import { FaUserGraduate } from 'react-icons/fa';
import { Curso, getCourseById, addUserToCourse, removeUserFromCourse } from '@/app/pages/course/courseApi';
import { Estudiante, getAllStudents } from '@/app/pages/course/[id]/studentsApi';
import Button from "@/app/components/Button";

export default function StudentList() {
  const [course, setCourse] = useState<Curso | null>(null);
  const [students, setStudents] = useState<Estudiante[]>([]);
  const [unregisteredStudents, setUnregisteredStudents] = useState<Estudiante[]>([]);
  const [selectedStudentId, setSelectedStudentId] = useState<number | null>(null);
  const [showForm, setShowForm] = useState(false);
  const router = useRouter();
  const { id } = useParams();

  useEffect(() => {
    const fetchCourse = async () => {
      try {
        if (typeof id === 'string') {
          const courseData: Curso = await getCourseById(parseInt(id));
          setCourse(courseData);

          // Obtener todos los estudiantes
          const allStudents: Estudiante[] = await getAllStudents();

          // Filtrar estudiantes que están registrados en el curso
          const registeredStudents = allStudents.filter(student =>
            courseData.cursoUsuarios.some(user => user.usuarioId === student.id)
          );

          // Filtrar estudiantes que no están registrados en el curso
          const unregisteredStudents = allStudents.filter(student =>
            !courseData.cursoUsuarios.some(user => user.usuarioId === student.id)
          );

          setStudents(registeredStudents);
          setUnregisteredStudents(unregisteredStudents);
        }
      } catch (error) {
        console.error('Error fetching course or students:', error);
      }
    };

    fetchCourse();
  }, [id]);

  const handleAddStudent = async () => {
    try {
      if (course && selectedStudentId !== null) {
        const selectedStudent = unregisteredStudents.find(student => student.id === selectedStudentId);
        console.log(selectedStudent);
        if (selectedStudent) {
          const courseStudent = { id: selectedStudent.id, usuario_id: selectedStudent.id };
          await addUserToCourse(course.id, courseStudent);
          setStudents([...students, selectedStudent]);
          setUnregisteredStudents(unregisteredStudents.filter(student => student.id !== selectedStudentId));
          setSelectedStudentId(null);
          setShowForm(false);
        }
      }
    } catch (error) {
      console.error('Error adding student:', error);
    }
  };

  const handleRemoveStudent = async (studentId: number) => {
    try {
      if (course) {
        await removeUserFromCourse(course.id, studentId);
        setStudents(students.filter(student => student.id !== studentId));
        const removedStudent = students.find(student => student.id === studentId);
        if (removedStudent) {
          setUnregisteredStudents([...unregisteredStudents, removedStudent]);
        }
      }
    } catch (error) {
      console.error('Error removing student:', error);
    }
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col">
      <NavBar />
      <main className="container mx-auto flex-grow py-8">
        <h1 className="text-3xl font-bold text-black mb-8 text-center">Listado de Estudiantes</h1>
        <div className="flex justify-center mb-8">
          <Button onClick={() => setShowForm(!showForm)} className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-3 px-6 rounded-lg">
            {showForm ? 'Cerrar Formulario' : 'Añadir Estudiante'}
          </Button>
        </div>
        {showForm && (
          <div className="bg-white p-8 rounded-lg shadow-md max-w-lg mx-auto mb-8 text-black">
            <h2 className="text-2xl font-bold mb-4">Matricular Estudiante</h2>
            <div className="grid grid-cols-1 gap-4">
              <select
                value={selectedStudentId ?? ''}
                onChange={(e) => setSelectedStudentId(parseInt(e.target.value))}
                className="border p-3 rounded-lg w-full"
              >
                <option value="" disabled>Selecciona un estudiante</option>
                {unregisteredStudents.map((student) => (
                  <option key={student.id} value={student.id}>
                    {student.nombre} {student.apellido} - {student.email}
                  </option>
                ))}
              </select>
              <Button onClick={handleAddStudent} className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-3 px-6 rounded-lg mt-4">Añadir Estudiante</Button>
            </div>
          </div>
        )}
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
                <Button onClick={() => handleRemoveStudent(student.id)} className="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded-lg mt-4">Eliminar</Button>
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