/* eslint-disable @typescript-eslint/no-explicit-any */

import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'http://localhost:8003/api', // Cambia esto a la URL de tu servidor
  headers: {
    'Content-Type': 'application/json',
  },
});

export const getAll = async (endpoint: string) => {
  try {
    const response = await apiClient.get(endpoint);
    return response.data;
  } catch (error) {
    console.error(`Error fetching data from ${endpoint}:`, error);
    throw error;
  }
};

export const getById = async (endpoint: string, id: number) => {
  try {
    const response = await apiClient.get(`${endpoint}/${id}`);
    return response.data;
  } catch (error) {
    console.error(`Error fetching data from ${endpoint} with id ${id}:`, error);
    throw error;
  }
};

export const create = async (endpoint: string, data: any) => {
  try {
    const response = await apiClient.post(endpoint, data);
    return response.data;
  } catch (error) {
    console.error(`Error creating data at ${endpoint}:`, error);
    throw error;
  }
};

export const update = async (endpoint: string, id: number, data: any) => {
  try {
    const response = await apiClient.put(`${endpoint}/${id}`, data);
    return response.data;
  } catch (error) {
    console.error(`Error updating data at ${endpoint} with id ${id}:`, error);
    throw error;
  }
};

export const remove = async (endpoint: string, id: number) => {
  try {
    await apiClient.delete(`${endpoint}/${id}`);
  } catch (error) {
    console.error(`Error deleting data at ${endpoint} with id ${id}:`, error);
    throw error;
  }
};

export const addUser = async (endpoint: string, id: number, user: any) => {
  try {
    const response = await apiClient.post(endpoint, user);
    return response.data;
  } catch (error) {
    console.error(`Error adding user to ${endpoint} with id ${id}:`, error);
    throw error;
  }
};

/* eslint-enable @typescript-eslint/no-explicit-any */