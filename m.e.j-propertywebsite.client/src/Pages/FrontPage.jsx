import './Css/FrontPage.css'
import React from 'react';
import Menu from '../Componets/Menu';

function FrontPage() {
	return (
		<div>
			<Menu />
			
			<div className="front-page-content">
				<img className="main-background" src="src\assets\newbackground.png" alt="M.E.J Logo" />
				<div className="titel-text">
					<h1>Mejbolig Aps</h1>
				</div>
			</div>
		</div>
	);
}

export default FrontPage;