import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { fetchBookings, addBooking } from '../services/api';

export const getBookings = createAsyncThunk('bookings/getBookings', async () => {
  const response = await fetchBookings();
  console.log(response.data);
  return response.data.$values;
});

export const createBooking = createAsyncThunk('bookings/createBooking', async (booking) => {
  const response = await addBooking(booking);
  return response.data.$values;
});

const bookingsSlice = createSlice({
  name: 'bookings',
  initialState: {
    bookings: [],
    status: 'idle',
  },
  reducers: {
    bookingUpdated(state, action) {
        const index = state.findIndex(b => b.id === action.payload.id);
        if (index !== -1) {
          state[index] = action.payload;
        }
    }
  },
  extraReducers: (builder) => {
    builder
      .addCase(getBookings.fulfilled, (state, action) => {
        state.bookings = action.payload;
        state.status = 'succeeded';
      })
      .addCase(createBooking.fulfilled, (state, action) => {
        state.bookings.push(action.payload);
      });
  },
});

export const { bookingUpdated } = bookingsSlice.actions;
export default bookingsSlice.reducer;
