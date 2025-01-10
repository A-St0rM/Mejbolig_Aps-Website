import { useEffect, useState } from 'react';
import { Routes, Route, Navigate } from 'react-router-dom';
import './App.css';
import FrontPage from './FrontPage.jsx';

function App() {


    return (
        <div>
            <Routes>
                <Route path="/" element={<FrontPage />} />
            </Routes>
        </div>
    );
    
}

export default App;