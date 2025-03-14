import './Css/FrontPage.css';
import React, { useEffect, useRef, useState } from 'react';
import Menu from '../Componets/Menu';
import Button from '../Componets/Button';
import CounterPropertyCard from '../Componets/Cards/CounterPropertyCard';

function FrontPage() {

	const imageRef = useRef(null);
	const [isVisible, setIsVisible] = useState(false);

	useEffect(() => {
		const observer = new IntersectionObserver(
			([entry]) => {
				if (entry.isIntersecting) {
					setIsVisible(true);
					observer.disconnect(); // Stop observing after it appears
				}
			},
			{ threshold: 0.3 } // Trigger when 30% of the image is visible
		);

		if (imageRef.current) {
			observer.observe(imageRef.current);
		}

		return () => {
			if (imageRef.current) {
				observer.unobserve(imageRef.current);
			}
		};
	}, []);

	return (
		<div>
			<Menu />
		
			<div className="front-page-content">
				<img className="main-background" src="src\assets\newbackground.png" alt="M.E.J Logo" />
				<div className="titel-text">
					<h1>Mejbolig Aps</h1>
				</div>

				<div className="sub-button">
					<Button text="Find din bolig!" to="/availableRentals" />
				</div>
			</div>

			<div className="card">
				<CounterPropertyCard />
			</div>

			<br />

			<div className="second-content">
				<div className="second-content-text">
					<h1 className="title" >Velkommen til Mejbolig</h1>
					<p className="text">Velkommen til vores skønne kvarter!
						Her finder du et trygt og levende fællesskab med naturskønne omgivelser, gode naboer og moderne faciliteter.
						Uanset om du allerede bor her eller overvejer at flytte hertil, kan du på denne side finde information om kvarterets fællesskab, aktiviteter og praktiske oplysninger.</p>
						<Button text="Om os" to="/About" />
				</div>
				<img
					ref={imageRef}
					className={`second-content-image ${isVisible ? 'show' : ''}`}
					src="src/assets/mejbolig_indoors.jpg"
					alt="bolig indendørs"
				/>
			</div>

			<br />
			<div className="second-content flipped">
				<img ref={imageRef} className={`second-content-image ${isVisible ? 'show' : ''}`} src="src/assets/mejbolig_indoors.jpg" alt="bolig indendørs" />

				<div className="second-content-text">
					<h1 className="title">Velkommen til Mejbolig</h1>
					<p className="text">Velkommen til vores skønne kvarter!...</p>
					<Button text="Om os" to="/About" />
				</div>
			</div>



		

		</div>
	);
}

export default FrontPage;