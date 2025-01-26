"use client";

import Link from 'next/link';

export default function NavBar() {
  return (
    <nav className="bg-white border-b-2 border-gray-300 text-gray-800 p-4 shadow-md">
      <div className="container mx-auto flex justify-between items-center">
        <h1 className="text-3xl font-bold tracking-wide">Gestión de Cursos</h1>
        <div className="space-x-6">
          <Link href="/" className="px-4 py-2 hover:bg-gray-200 rounded-lg transition duration-300">Inicio</Link>
          <Link href="/pages/course" className="px-4 py-2 hover:bg-gray-200 rounded-lg transition duration-300">Cursos</Link>
          <Link href="/pages/student" className="px-4 py-2 hover:bg-gray-200 rounded-lg transition duration-300">Estudiantes</Link>
        </div>
      </div>
    </nav>
  );
}