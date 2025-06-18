import { Routes, Route, Link } from 'react-router-dom';
import Home from './pages/home';
import NewBooking from './pages/booking';
import BookingEditFormWrapper from './components/BookingEditFormWrapper';


function App() {
    return (
      <div>
        <nav>
          <Link to="/">Orders</Link> | <Link to="/book">New Booking</Link>
        </nav>
  
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/book" element={<NewBooking />} />
          {/* Add edit route with bookingId param */}
          <Route path="/edit/:bookingId" element={<BookingEditFormWrapper />} />
        </Routes>
      </div>
    );
  }

export default App;
