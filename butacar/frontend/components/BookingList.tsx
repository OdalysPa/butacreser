import React, { useContext } from 'react';
import { ReservationContext } from '../context/ReservationContext';

const BookingList = () => {
    const { bookings } = useContext(ReservationContext);

    return (
        <div>
            <h1>Booking List</h1>
            {bookings.map((booking) => (
                <div key={booking.id}>
                    <p>Customer: {booking.customerName}</p>
                    <p>Movie: {booking.movieName}</p>
                </div>
            ))}
        </div>
    );
};

export default BookingList;
