import '../Css/FrontPage.css';
import { useEffect, useRef, useState } from 'react';
import Header from '../../Componets/Headers/Header';
import Button from '../../Componets/Buttons/Button';
import CounterPropertyCard from '../../Componets/Cards/CounterPropertyCard';
import Footer from '../../Componets/Footer';
import Rental from '../../Componets/Cards/Rental';

function FrontPage() {

    const imageRef = useRef(null);
    const [isVisible, setIsVisible] = useState(false);
    const [expandedItems, setExpandedItems] = useState([]);

    useEffect(() => {
        const observer = new IntersectionObserver(
            ([entry]) => {
                if (entry.isIntersecting) {
                    setIsVisible(true);
                    observer.disconnect();
                }
            },
            { threshold: 0.3 } // Trigger when 30% of the image is visible
        );

        if (imageRef.current) {
            observer.observe(imageRef.current);
        }

        return () => {
            if (imageRef.current) {
                observer.unobserve(imageRef.current);
            }
        };
    }, []);

    const toggleItem = (index) => {
        setExpandedItems((prev) => {
            const newExpandedItems = [...prev];
            newExpandedItems[index] = !newExpandedItems[index];
            return newExpandedItems;
        });
    };

    const dummyRentals = [
        {
            rentalPropertyId: 1,
            imageUrl: 'src/assets/test.jpg',
            propertyName: 'Property 1',
            propertyAddress: 'Address 1',
            rentalPrice: 1000,
            propertySquareFootage: 50
        },
        {
            rentalPropertyId: 2,
            imageUrl: 'src/assets/test.jpg',
            propertyName: 'Property 2',
            propertyAddress: 'Address 2',
            rentalPrice: 2000,
            propertySquareFootage: 75
        },
        {
            rentalPropertyId: 3,
            imageUrl: 'src/assets/test.jpg',
            propertyName: 'Property 3',
            propertyAddress: 'Address 3',
            rentalPrice: 3000,
            propertySquareFootage: 100
        }
    ];

    return (
        <div>
            <Header />
            <div className="page-container">
                <div className="front-page-content">
                    <img className="main-background" src="src/assets/newbackground.png" alt="M.E.J Logo" />
                    <div className="titel-text">
                        <h1>Mejbolig Aps</h1>
                    </div>
                    <div className="sub-button">
                        <Button text="Find din bolig!" to="/availableRentals" />
                    </div>
                </div>
                <div className="card">
                    <CounterPropertyCard />
                </div>
                <br />
                <div className="second-content">
                    <div className="second-content-text">
                        <h1 className="title">Velkommen til Mejbolig</h1>
                        <p className="text">
                            Velkommen til vores skønne kvarter!
                            Her finder du et trygt og levende fællesskab med naturskønne omgivelser, gode naboer og moderne faciliteter.
                        </p>
                        <Button text="Om os" to="/About" />
                    </div>
                    <img
                        ref={imageRef}
                        className={`second-content-image ${isVisible ? 'show' : ''}`}
                        src="src/assets/mejbolig_indoors.jpg"
                        alt="bolig indendørs"
                    />
                </div>
                <br />
                <div className="third-content">
                    <div className="third-content-images">
                        <img ref={imageRef} className={`third-content-image img1 ${isVisible ? 'show' : ''}`} src="src/assets/mejbolig_indoors.jpg" alt="bolig indendørs" />
                        <img ref={imageRef} className={`third-content-image img2 ${isVisible ? 'show' : ''}`} src="src/assets/mejbolig_indoors.jpg" alt="bolig indendørs" />
                        <img ref={imageRef} className={`third-content-image img3 ${isVisible ? 'show' : ''}`} src="src/assets/mejbolig_indoors.jpg" alt="bolig indendørs" />
                    </div>
                    <div className="third-content-text">
                        <h1 className="third-title">Information til lejere</h1>
                        <p className="third-text">Velkommen til Mejbolig ApS – din pålidelige partner i boligudlejning. Vi tilbyder en række forskellige boligtyper og hjælper dig gennem hele lejeprocessen. Her er nogle vigtige informationer for dig som lejer:</p>
                        <ul className="third-list">
                            {[
                                "Lejekontrakter: Vi tilbyder fleksible lejekontrakter, der passer til dine behov. Alle kontrakter er klart formuleret, så du ved, hvad du kan forvente.",
                                "Depositum og forudbetalt leje: Som en del af lejeaftalen kræves et depositum og forudbetalt leje. Det vil fremgå klart af din kontrakt, hvad der gælder for din bolig.",
                                "Reparationer og vedligeholdelse: Vi sørger for, at din bolig altid er i god stand. Hvis du opdager fejl eller mangler, kan du hurtigt kontakte os for at få dem løst.",
                                "Betaling: Lejen skal betales månedligt. Betalingsoplysninger og tidsfrister fremgår af din lejekontrakt."
                            ].map((item, index) => (
                                <li key={index} className={`third-list-item ${expandedItems[index] ? 'expanded' : ''}`}>
                                    <div className="list-header" onClick={() => toggleItem(index)}>
                                        <span className={`arrow ${expandedItems[index] ? 'expanded' : ''}`}>&#9660;</span>
                                        <span className="list-title">{item.split(":")[0]}</span>
                                    </div>
                                    <div className={`expanded-text ${expandedItems[index] ? 'show' : ''}`}>{item.split(":")[1]}</div>
                                </li>
                            ))}
                        </ul>
                        <Button text="Information om lejere" to="/InformationForTenants" />
                    </div>
                </div>
                <br />
                <div className="rental-section">
                    <h2 className="rental-section-title">Flyt Ind Nu! Se Alle Tilgængelige Lejemål</h2>
                    <div className="rental-cards">
                        {dummyRentals.map((property) => (
                            <Rental key={property.rentalPropertyId} property={property} />
                        ))}
                    </div>
                </div>
            </div>
            <br />
            <Footer />
        </div>
    );
}

export default FrontPage;


