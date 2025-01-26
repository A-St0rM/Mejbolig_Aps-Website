import React from 'react';
import './Css/Login.css';
import Menu from '../Componets/Menu';

function Login() {
	return (
		<div>
			<Menu />
			<div className="login-container">
				<h1>Login</h1>
				<form>
					<label>
						Brugernavn:
						<input type="text" name="username" />
					</label>
					<label>
						Adgangskode:
						<input type="password" name="password" />
					</label>
					<button type="submit">Login</button>
				</form>
			</div>
		</div>
	);
}

export default Login;