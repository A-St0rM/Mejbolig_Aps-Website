import './CounterPropertyCard.css';

function CounterPropertyCard() {
    return (
    
        <div className="counter-card">        
            <div className="number-of-properties">         
                <p>Antal Boliger</p>
                <p>132</p>
            </div>

            <div className="number-of-typeProperties">
            <p>Boligtyper</p>
                <p>5</p>
            </div>

        </div>
  
    );
}

export default CounterPropertyCard;