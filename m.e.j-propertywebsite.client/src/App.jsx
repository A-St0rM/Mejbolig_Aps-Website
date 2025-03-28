import { Routes, Route, Navigate } from 'react-router-dom';
import PropTypes from 'prop-types';
import FrontPage from './Pages/User/FrontPage';
import About from './Pages/User/About';
import Contact from './Pages/User/Contact';
import AvailableRentals from './Pages/User/AvailableRentals';
import Login from './Pages/Admin/Login';
import AdminFrontPage from './Pages/Admin/AdminFrontPage';
import InformationForTenants from './Pages/User/InformationForTenants';

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

PrivateRoute.propTypes = {
	children: PropTypes.node.isRequired,
};

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
				<Route path="/InformationForTenants" element={<InformationForTenants />} />
			</Routes>
		</div>
	);
}

export default App;
