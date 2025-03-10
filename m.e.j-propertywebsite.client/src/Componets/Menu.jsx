import React from "react";
import { Link, useLocation } from 'react-router-dom';
import "./Menu.css";

function Menu() {
    const location = useLocation();

    return (
        <nav className="unique-menu-container">
            <div className="logo">
                <img src="src\assets\Logo_Mejbolig_orange.png" alt="M.E.J Logo" height="50px"/>
            </div>
            <ul className="unique-menu-list">
                <li className={`unique-menu-item ${location.pathname === '/availableRentals' ? 'active' : ''}`}>
                    <Link to="/availableRentals">Find lejemål</Link>
                </li>
                <li className={`unique-menu-item ${location.pathname === '/InformationForTenants' ? 'active' : ''}`}>
                    <Link to="/InformationForTenants">information til lejere</Link>

                    <ul className="sub-menu">
                        <li className={`sub-menu-item ${location.pathname === '/InformationForTenants/GenerelInformation' ? 'active' : ''}`}>
                            <Link to="/InformationForTenants/GenerelInformation">Generel information</Link>
                        </li>
                        <li className={`sub-menu-item ${location.pathname === '/InformationForTenants/RulesOfOrder' ? 'active' : ''}`}>
                            <Link to="/InformationForTenants/RulesOfOrder">Ordens reglement</Link>
                        </li>
                    </ul>
                </li>

                <li className={`unique-menu-item ${location.pathname === '/about' ? 'active' : ''}`}>
                    <Link to="/about">Om os</Link>
                </li>
                <li className={`unique-menu-item ${location.pathname === '/contact' ? 'active' : ''}`}>
                    <Link to="/contact">Kontakt</Link>
                </li>
            </ul>
        </nav>
    );
}

export default Menu;
