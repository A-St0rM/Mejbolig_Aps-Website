import './CounterPropertyCard.css';

function CounterPropertyCard() {
    return (
    
        <div className="counter-card animate-wiggle">
            <div className="card-text">
                <div className="number-of-properties">
                    <p>Antal Boliger</p>
                    <p>132</p>
                </div>

                <div className="number-of-typeProperties">
                    <p>Boligtyper</p>
                    <p>5</p>
                </div>
            </div>
        </div>
  
    );
}

export default CounterPropertyCard;