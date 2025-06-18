export default function ServiceTypeSelector({ value, onChange }) {
    const services = [
      { value: 0, label: 'Wheel Adjustment' },
      { value: 1, label: 'Chain Replacement' },
      { value: 2, label: 'Brake Maintenance' },
    ];
  
    return (
      <select value={value} onChange={e => onChange(Number(e.target.value))}>
        <option value="">Select Service Type</option>
        {services.map(s => (
          <option key={s.value} value={s.value}>{s.label}</option>
        ))}
      </select>
    );
  }
  