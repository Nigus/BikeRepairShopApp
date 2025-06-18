import {useParams, useNavigate } from 'react-router-dom';
import BookingEditForm from './BookingEditForm';
export default function BookingEditFormWrapper() {
    const { bookingId } = useParams();
    const navigate = useNavigate();

    const handleClose = () => {
        navigate('/'); 
    };

    const handleUpdated = () => {
    
    };

    return (
        <BookingEditForm
            bookingId={bookingId}
            onClose={handleClose}
            onBookingUpdated={handleUpdated}
        />
    );
}