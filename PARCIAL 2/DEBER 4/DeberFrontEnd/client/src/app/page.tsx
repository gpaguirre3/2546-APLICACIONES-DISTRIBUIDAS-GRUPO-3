"use client";

import { useRouter } from 'next/navigation';
import Button from "./components/Button";

export default function Home() {
  const router = useRouter();

  return (
    <div
      className="min-h-screen flex flex-col items-center justify-center p-8 sm:p-10 font-[family-name:var(--font-geist-sans)] text-white overflow-hidden"
      style={{ backgroundImage: 'url(/landing.jpeg)', backgroundSize: 'cover', backgroundPosition: 'center', backgroundRepeat: 'no-repeat' }}
    >
      <section id="hero" className="text-center bg-black bg-opacity-75 p-6 rounded-xl max-w-2xl shadow-lg transform transition duration-500 hover:scale-105">
        <h1 className="text-4xl font-bold mb-4">Bienvenido a la Gestión de Cursos</h1>
        <p className="text-lg mb-8">Administra y organiza tus cursos de manera eficiente.</p>
        <Button onClick={() => router.push('/pages/course')} className="rounded-xl bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 transition duration-300">Ingresar</Button>
      </section>

      <section id="courses" className="w-full bg-black bg-opacity-75 p-8 rounded-xl mt-7 max-w-4xl shadow-lg">
        <h2 className="text-3xl font-bold mb-6 text-center">Accede a Nuestros Cursos</h2>
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
          <div className="border p-3 rounded-xl shadow bg-white text-black transform transition duration-500 hover:scale-105">
            <h3 className="text-2xl font-bold mb-1 text-center">Dato 1</h3>
            <p className="text-lg">Explora los fundamentos y conceptos avanzados.</p>
          </div>
          <div className="border p-4 rounded-xl shadow bg-white text-black transform transition duration-500 hover:scale-105">
            <h3 className="text-2xl font-bold mb-1 text-center">Dato 2</h3>
            <p className="text-lg">Mejora tus habilidades con nuestras lecciones interactivas.</p>
          </div>
          <div className="border p-4 rounded-xl shadow bg-white text-black transform transition duration-500 hover:scale-105">
            <h3 className="text-2xl font-bold mb-1 text-center">Dato 3</h3>
            <p className="text-lg">Aprende de los expertos en la industria.</p>
          </div>
        </div>
      </section>
    </div>
  );
}
