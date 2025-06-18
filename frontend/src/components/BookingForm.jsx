import { useState } from 'react';
import { useDispatch } from 'react-redux';
import { createBooking } from '../features/bookingsSlice';
import ServiceTypeSelector from './ServiceTypeSelector';

export default function BookingForm() {
  const dispatch = useDispatch();
  const [customerId, setCustomerId] = useState('');
  const [bikeBrandId, setBikeBrandId] = useState('');
  const [serviceType, setServiceType] = useState('');
  const [bookingDate, setBookingDate] = useState('');
  const [notes, SetBookingNote] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
  
    const booking = {
      customerId: Number(customerId),
      bookingDate,
      expectedDueDate: bookingDate,
      notes: notes,
      repairOrders: [
        {
          bikeBrandId: Number(bikeBrandId),
          serviceType: Number(serviceType)
        }
      ]
    };
  
    dispatch(createBooking(booking));
  };
  

  return (
    <form onSubmit={handleSubmit}>
      <input type="number" value={customerId} onChange={e => setCustomerId(e.target.value)} placeholder="Customer ID" required />
      <input type="number" value={bikeBrandId} onChange={e => setBikeBrandId(e.target.value)} placeholder="Bike Brand ID" required />
      <ServiceTypeSelector value={serviceType} onChange={setServiceType} />
      <input type="date" value={bookingDate} onChange={e => setBookingDate(e.target.value)} required />
      <input type="text" value={notes} onChange={e=> SetBookingNote(e.target.value)} placeholder='Notes'/>
      <button type="submit">Create Booking</button>
    </form>
  );
}
