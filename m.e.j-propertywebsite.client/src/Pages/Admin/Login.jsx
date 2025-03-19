import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import "../Css/Login.css";
import Header from '../../Componets/Headers/Header';

function Login() {
	const [username, setUsername] = useState('');
	const [password, setPassword] = useState('');
	const [error, setError] = useState('');
	const navigate = useNavigate();

	const handleSubmit = async (e) => {
		e.preventDefault();
		setError('');

		try {
			const response = await fetch('https://localhost:7230/api/login/login', {
				method: 'POST',
				headers: {
					'Content-Type': 'application/json',
				},
				body: JSON.stringify({ UserName: username, Password: password }),
			});

			if (!response.ok) {
				throw new Error('Forkert brugernavn eller adgangskode');
			}

			const data = await response.json();
			localStorage.setItem('token', data.token);
			localStorage.setItem('isAuthenticated', 'true');
			navigate('/admin');
		} catch (err) {
			setError(err.message);
		}
	};

	return (

		<div className="login-page">
			<div className="login-container">
				<h1>Login</h1>
				{error && <p className="error">{error}</p>}
				<form onSubmit={handleSubmit}>
					<div className="input-group">
						<label>Brugernavn</label>
						<input type="text" value={username} onChange={(e) => setUsername(e.target.value)} required />
					</div>
					<div className="input-group">
						<label>Adgangskode</label>
						<input type="password" value={password} onChange={(e) => setPassword(e.target.value)} required />
					</div>
					<button type="submit" className="login-btn">Login</button>
				</form>
			</div>
		</div>
	);
}

export default Login;
