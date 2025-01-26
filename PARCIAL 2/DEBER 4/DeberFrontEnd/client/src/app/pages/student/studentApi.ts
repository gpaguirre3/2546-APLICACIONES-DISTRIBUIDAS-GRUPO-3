import axios from 'axios';
import { format } from 'date-fns';

const apiClient = axios.create({
  baseURL: 'http://localhost:8002/api/estudiantes',
  headers: {
    'Content-Type': 'application/json',
  },
});

export interface Estudiante {
  id: number;
  nombre: string;
  apellido: string;
  email: string;
  fechaNacimiento: string; // Usamos string para simplificar el manejo de fechas
  telefono: string;
  creadoEn: string;
}

export const createStudent = async (student: Estudiante): Promise<Estudiante> => {
  try {
    // Formatear la fecha de nacimiento antes de enviar al backend
    const formattedStudent = {
      ...student,
      fechaNacimiento: format(new Date(student.fechaNacimiento), "yyyy-MM-dd'T'HH:mm:ss"),
    };
    const response = await apiClient.post('', formattedStudent);
    return response.data as Estudiante;
  } catch (error) {
    console.error('Error creating student:', error);
    throw error;
  }
};

export const getAllStudents = async (): Promise<Estudiante[]> => {
  try {
    const response = await apiClient.get('');
    return response.data as Estudiante[];
  } catch (error) {
    console.error('Error fetching students:', error);
    throw error;
  }
};

export const getStudentById = async (id: number): Promise<Estudiante> => {
  try {
    const response = await apiClient.get(`/${id}`);
    return response.data as Estudiante;
  } catch (error) {
    console.error('Error fetching student:', error);
    throw error;
  }
};

export const updateStudent = async (id: number, student: Estudiante): Promise<Estudiante> => {
    try {
        const response = await apiClient.put(`/${id}`, student);
        return response.data as Estudiante;
    } catch (error) {
        console.error('Error updating student:', error);
        throw error;
    }
};

export const deleteStudentById = async (id: number): Promise<void> => {
  try {
    await apiClient.delete(`/${id}`);
  } catch (error) {
    console.error('Error deleting student:', error);
    throw error;
  }
};