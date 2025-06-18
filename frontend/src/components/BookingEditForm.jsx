import { useState, useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { bookingUpdated } from '../features/bookingsSlice';
import ServiceTypeSelector from './ServiceTypeSelector';
import axios from 'axios';
import { fetchBooking } from '../services/api';

export default function BookingEditForm({ bookingId, onClose, onBookingUpdated }) {
  const dispatch = useDispatch();

  const [booking, setBooking] = useState(null);
  const [bikeBrandId, setBikeBrandId] = useState('');
  const [serviceType, setServiceType] = useState('');
    console.log(bookingId);
    //   useEffect(() => {
    //     axios.get(`/api/bookings/${bookingId}`)
    //       .then(res => {
    //         setBooking(res.data);
    //         if (res.data.repairOrders.length > 0) {
    //           setBikeBrandId(res.data.repairOrders[0].bikeBrandId);
    //           setServiceType(res.data.repairOrders[0].serviceType);
    //         }
    //       })
    //       .catch(err => {
    //         console.error("Failed to load booking", err);
    //       });
    //   }, [bookingId]);
   
    useEffect(() => {
        fetchBooking(bookingId)
        .then(res => {
            setBooking(res.data);
            if (res.data.repairOrders.length > 0) {
            setBikeBrandId(res.data.repairOrders[0].bikeBrandId);
            setServiceType(res.data.repairOrders[0].serviceType);
            }
        })
        .catch(err => {
            console.error("Failed to load booking", err);
        });
  }, [bookingId]);

  const handleSubmit = (e) => {
    e.preventDefault();

    const updatedBooking = {
      id: bookingId,
      customerId: Number(booking.customerId),
      bookingDate: booking.bookingDate,
      expectedDueDate: booking.expectedDueDate,
      notes: booking.notes,
      repairOrders: [
        {
          bikeBrandId: Number(bikeBrandId),
          serviceType: Number(serviceType)
        }
      ]
    };

    dispatch(bookingUpdated(updatedBooking))
      .then(() => {
        if (onBookingUpdated) onBookingUpdated();
        onClose();
      });
  };

  if (!booking) return <div>Loading booking...</div>;

  return (
    <form onSubmit={handleSubmit} className="space-y-4 p-4 bg-white rounded shadow">
      <h2 className="text-lg font-semibold">Edit Booking</h2>

      <input
        type="number"
        value={booking.customerId}
        onChange={e => setBooking({ ...booking, customerId: e.target.value })}
        placeholder="Customer ID"
        required
        className="w-full border rounded p-2"
      />

      <input
        type="datetime-local"
        value={booking.bookingDate}
        onChange={e => setBooking({ ...booking, bookingDate: e.target.value })}
        required
        className="w-full border rounded p-2"
      />

      <input
        type="datetime-local"
        value={booking.expectedDueDate}
        onChange={e => setBooking({ ...booking, expectedDueDate: e.target.value })}
        required
        className="w-full border rounded p-2"
      />

      <textarea
        value={booking.notes || ''}
        onChange={e => setBooking({ ...booking, notes: e.target.value })}
        placeholder="Notes"
        className="w-full border rounded p-2"
      />

      <input
        type="number"
        value={bikeBrandId}
        onChange={e => setBikeBrandId(e.target.value)}
        placeholder="Bike Brand ID"
        required
        className="w-full border rounded p-2"
      />

      <ServiceTypeSelector value={serviceType} onChange={setServiceType} />

      <div className="flex justify-end gap-3">
        <button type="button" onClick={onClose} className="px-4 py-2 rounded bg-gray-200 hover:bg-gray-300">
          Cancel
        </button>
        <button type="submit" className="px-4 py-2 rounded bg-blue-600 text-white hover:bg-blue-700">
          Save Changes
        </button>
      </div>
    </form>
  );
}
