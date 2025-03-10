import "./Button.css";
import { Link } from "react-router-dom";

function Button() {
  return (
      <Link to="/availableRentals" className="orange-button">
          Find din bolig!
      </Link>
    );
}

export default Button;