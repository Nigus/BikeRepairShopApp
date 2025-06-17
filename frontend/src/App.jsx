import { useEffect, useState } from 'react';
import axios from 'axios';

function App() {
    const [customers, setCustomers] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:5000/api/customers')
            .then(response => setCustomers(response.data));
    }, []);

    return (
        <div>
            <h1>Bike Repair Shop - Customers</h1>
            <ul>
                {customers.map(c => (
                    <li key={c.id}>{c.name} - {c.phone}</li>
                ))}
            </ul>
        </div>
    );
}

export default App;
