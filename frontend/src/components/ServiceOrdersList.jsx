import { useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { getBookings } from '../features/bookingsSlice';
import { Link } from 'react-router-dom';


export default function ServiceOrdersList() {
    const dispatch = useDispatch();
    const { bookings, status } = useSelector(state => state.bookings);
  
    useEffect(() => {
      dispatch(getBookings());
    }, [dispatch]);
  
    return (
      <div>
        <h2>Service Orders</h2>
        {status === 'idle' || status === 'loading' ? (
          <p>Loading...</p>
        ) : (
          bookings.map(order => (
            <p key={order.id}> {console.log('order ID'+order.id)}
              Booking #{order.id} - Customer {order.customerId} - Date: {order.bookingDate}{' '}
              <Link to={`/edit/${order.id}`}>Edit</Link>
            </p>
          ))
        )}
      </div>
    );
  }
