import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:55215/api',
});

export const fetchBookings = () => api.get('/booking');
export const addBooking = (data) => api.post('/booking', data);
export const fetchBooking = (id) => api.get(`/booking/${id}`);
export const updateBooking = (id, data) => api.put(`/booking/${id}`, data);
