import React, { useEffect, useState } from "react";
import './Header.css';
import {useNavigate, useLocation} from 'react-router-dom'

const Header = () => {
    const [matchesBtnSelected, setMatchesBtn] = useState(false);
    const [standingsBtnSelected, setStandingsBtn] = useState(false);
    const [statsLeadersBtnSelected, setStatsLeadersBtn] = useState(false)
    const navigate = useNavigate()
    const location = useLocation()

    useEffect(() => {
        if(location.pathname === '/') {
            setMatchesBtn(true)
        } else if (location.pathname === '/standings') {
            setStandingsBtn(true)
        } else {
            setStatsLeadersBtn(true)
        }
    }, [location])
    

    const matchesOnClick = () => {
        if(matchesBtnSelected){
            return
        }
        setMatchesBtn(true)
        setStandingsBtn(false)
        setStatsLeadersBtn(false)
        navigate("/")
    }

    const standingsOnClick = () => {
        if(standingsBtnSelected) {
            return
        }
        setMatchesBtn(false)
        setStandingsBtn(true)
        setStatsLeadersBtn(false)
        navigate("/standings")
    }

    const statsOnClick = () => {
        if(statsLeadersBtnSelected) {
            return
        }
        setMatchesBtn(false)
        setStandingsBtn(false)
        setStatsLeadersBtn(true)
        navigate("/leaders")
    }

    return (
        <div className="header">
            <div className="buttons-container">
                <button 
                    onClick={matchesOnClick} 
                    className={matchesBtnSelected ? "matches-button-selected" : "matches-button"}>
                        Matches
                </button>

                <button 
                    onClick={standingsOnClick} 
                    className={standingsBtnSelected ? "standings-button-selected" : "standings-button"}>
                        Standings
                </button>

                <button 
                    onClick={statsOnClick} 
                    className={statsLeadersBtnSelected ? "statsLeaders-button-selected" : "statsLeaders-button"}>
                        Leaders
                </button>
            </div>
        </div>
    )
}

export default Header