import './Css/FrontPage.css'
import React from 'react';
import Menu from '../Componets/Menu';

function FrontPage() {
	return (
		<div>
			<Menu />
			<div className="front-page-container">
				<p class="font-bold underline">Front Page</p>
			</div>
		</div>
	);
}

export default FrontPage;