import { createContext, useState, useContext } from 'react';

interface Booking {
    id: number;
    customerName: string;
    movieName: string;
}

interface ReservationContextType {
    bookings: Booking[];
    setBookings: React.Dispatch<React.SetStateAction<Booking[]>>;
}

export const ReservationContext = createContext<ReservationContextType | undefined>(undefined);

export const useReservation = () => {
    const context = useContext(ReservationContext);
    if (!context) {
        throw new Error("useReservation must be used within a ReservationProvider");
    }
    return context;
};

export const ReservationProvider: React.FC = ({ children }) => {
    const [bookings, setBookings] = useState<Booking[]>([]);

    return (
        <ReservationContext.Provider value={{ bookings, setBookings }}>
            {children}
        </ReservationContext.Provider>
    );
};
