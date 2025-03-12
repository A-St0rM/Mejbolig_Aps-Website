import { useEffect, useState } from 'react';
import { Routes, Route, Navigate } from 'react-router-dom';
import FrontPage from './pages/FrontPage';
import About from './pages/About';
import Contact from './pages/Contact';
import AvailableRentals from './pages/AvailableRentals';
import Login from './pages/Login';
import AdminFrontPage from './pages/AdminFrontPage';

function PrivateRoute({ children }) {
	const token = localStorage.getItem('token');

	if (!token) {
		return <Navigate to="/login" />;
	}

	try {
		const payload = JSON.parse(atob(token.split('.')[1]));
		const isTokenExpired = payload.exp * 1000 < Date.now();

		if (isTokenExpired) {
			localStorage.removeItem('token');
			localStorage.removeItem('isAuthenticated');
			return <Navigate to="/login" />;
		}

		return children;

	} catch (err) {
		localStorage.removeItem('token');
		localStorage.removeItem('isAuthenticated');
		return <Navigate to="/login" />;
	}
}

function App() {
	return (
		<div>
			<Routes>
				<Route path="/" element={<FrontPage />} />
				<Route path="/about" element={<About />} />
				<Route path="/contact" element={<Contact />} />
				<Route path="/availableRentals" element={<AvailableRentals />} />
				<Route path="/login" element={<Login />} />
				<Route path="/admin" element={<PrivateRoute><AdminFrontPage /></PrivateRoute>} />
			</Routes>
		</div>
	);
}

export default App;
