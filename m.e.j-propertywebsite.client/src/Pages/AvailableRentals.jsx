import React from 'react';
import Menu from '../Componets/Menu';
import './Css/AvailableRentals.css';

function AvailableRentals() {
	return (
		<div>
			<Menu />
			<div className="available-rentals-container">
				<h1>Available Rentals</h1>
			</div>
		</div>
	);
}

export default AvailableRentals;