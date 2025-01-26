  import { getAll, getById, create, update, remove } from '@/api/serviceApi';
  import axios from 'axios';

  const baseEndpoint1 = 'http://localhost:8003/api/cursos';


  const apiClient = axios.create({
    baseURL: baseEndpoint1, // Cambia esto a la URL de tu servidor
    headers: {
      'Content-Type': 'application/json',
    },
  });

  export interface Curso {
    id: number;
    nombre: string;
    descripcion: string;
    creditos: number;
    description: string;
    cursoUsuarios: { usuarioId: number }[];
  }

  export interface CursoPost {
    nombre: string;
    descripcion: string;
    creditos: number;
    description: string;
    cursoUsuarios: { usuarioId: number }[];
  }

  export interface Student {
    name: string;
    email: string;
  }

  export interface CourseStudent {
    id: number;
    usuario_id: number;
  }

  const baseEndpoint = '/cursos';

  export const getCourses = async (): Promise<Curso[]> => {
    return await getAll(baseEndpoint) as Curso[];
  };

  export const getCourseById = async (id: number): Promise<Curso> => {
    return await getById(baseEndpoint, id) as Curso;
  };

  export const createCourse = async (course: CursoPost): Promise<CursoPost> => {
    const endpoint = `${baseEndpoint}/add`;
    return await create(endpoint, course) as CursoPost;
  };

  export const updateCourse = async (id: number, course: Curso): Promise<Curso> => {
    return await update(baseEndpoint, id, course) as Curso;
  };

  export const deleteCourse = async (id: number): Promise<void> => {
    await remove(baseEndpoint, id);
  };


  export const addUserToCourse = async (id: number, user: CourseStudent): Promise<CourseStudent> => {
    try {
      const endpoint = `${baseEndpoint1}/agregar_usuario/${id}`;
      const response = await apiClient.post(endpoint, user);
      return response.data as CourseStudent;
    } catch (error) {
      console.error('Error adding user to course:', error);
      throw error;
    }
  };

  export const removeUserFromCourse = async (courseId: number, userId: number): Promise<void> => {
    try {
      const endpoint = `${baseEndpoint1}/eliminar_usuario/${courseId}/${userId}`;
      await apiClient.delete(endpoint);
    } catch (error) {
      console.error('Error removing user from course:', error);
      throw error;
    }
  };