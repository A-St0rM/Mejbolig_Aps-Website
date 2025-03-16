import "./Button.css";
import { Link } from "react-router-dom";

function Button({ text = "Find din bolig!", to = "/availableRentals" }) {
    return (
        <Link to={to} className="orange-button">
            {text}
        </Link>
    );
}

export default Button;
