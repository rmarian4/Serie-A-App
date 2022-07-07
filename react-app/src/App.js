import React from 'react';
import './App.css';
import Header from './components/Header';
import Standings from './components/Standings';
import {BrowserRouter, Route, Routes} from 'react-router-dom'
import StatLeadersPage from './components/StatLeadersPage';
import MatchesPage from './components/MatchesPage';

function App() {
  return (
    <div className="app">
      <BrowserRouter>
          <Header/>
          <Routes>
              <Route path='/' element={<MatchesPage />} />
              <Route path='/standings' element={<Standings />} />
              <Route path='/leaders' element={<StatLeadersPage />} />
          </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
