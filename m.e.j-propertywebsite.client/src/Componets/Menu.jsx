import React from "react";
import { Link, useLocation } from 'react-router-dom';
import "./Menu.css";

function Menu() {
    const location = useLocation();

    return (
        <nav className="unique-menu-container">
            <ul className="unique-menu-list">
                <li className={`unique-menu-item ${location.pathname === '/' ? 'active' : ''}`}>
                    <Link to="/">Forside</Link>
                </li>
                <li className={`unique-menu-item ${location.pathname === '/availableRentals' ? 'active' : ''}`}>
                    <Link to="/availableRentals">Ledige Lejemål</Link>
                </li>
                <li className={`unique-menu-item ${location.pathname === '/about' ? 'active' : ''}`}>
                    <Link to="/about">Om os</Link>
                </li>
                <li className={`unique-menu-item ${location.pathname === '/contact' ? 'active' : ''}`}>
                    <Link to="/contact">Kontakt</Link>
                </li>
                <li className={`unique-menu-item ${location.pathname === '/login' ? 'active' : ''}`}>
                    <Link to="/login">Login</Link>
                </li>
            </ul>
        </nav>
    );
}


export default Menu;