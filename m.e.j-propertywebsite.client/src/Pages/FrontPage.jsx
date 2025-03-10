import './Css/FrontPage.css'
import React from 'react';
import Menu from '../Componets/Menu';
import Button from '../Componets/Button';
import CounterPropertyCard from '../Componets/Cards/CounterPropertyCard';

function FrontPage() {
	return (
		<div>
			<Menu />
		
			<div className="front-page-content">
				<img className="main-background" src="src\assets\newbackground.png" alt="M.E.J Logo" />
				<div className="titel-text">
					<h1>Mejbolig Aps</h1>
				</div>

				<div className="sub-button">
					<Button />
				</div>
			</div>

			<div className="card">
				<CounterPropertyCard />
			</div>

		

		</div>
	);
}

export default FrontPage;