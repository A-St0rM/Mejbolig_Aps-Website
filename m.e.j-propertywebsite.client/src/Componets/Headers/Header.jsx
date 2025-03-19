import { Link, useLocation } from 'react-router-dom';
import "./Header.css";

function Header() {
    const location = useLocation();

    return (
        <nav className="unique-header-container">
            <div className="logo">
                <Link to="/">
                    <img src="src\assets\Logo_Mejbolig_orange.png" alt="M.E.J Logo" height="50px" />
                </Link>
            </div>
            <ul className="unique-header-list">
                <li className={`unique-header-item ${location.pathname === '/availableRentals' ? 'active' : ''}`}>
                    <Link to="/availableRentals">Find lejemål</Link>
                </li>
                <li className={`unique-header-item ${location.pathname === '/InformationForTenants' ? 'active' : ''}`}>
                    <Link to="/InformationForTenants">information til lejere</Link>

                    <ul className="sub-header">
                        <li className={`sub-header-item ${location.pathname === '/InformationForTenants/GenerelInformation' ? 'active' : ''}`}>
                            <Link to="/InformationForTenants/GenerelInformation">Generel information</Link>
                        </li>
                        <li className={`sub-header-item ${location.pathname === '/InformationForTenants/RulesOfOrder' ? 'active' : ''}`}>
                            <Link to="/InformationForTenants/RulesOfOrder">Ordens reglement</Link>
                        </li>
                    </ul>
                </li>

                <li className={`unique-header-item ${location.pathname === '/about' ? 'active' : ''}`}>
                    <Link to="/about">Om os</Link>
                </li>
                <li className={`unique-header-item ${location.pathname === '/contact' ? 'active' : ''}`}>
                    <Link to="/contact">Kontakt</Link>
                </li>
            </ul>
        </nav>
    );
}

export default Header;
