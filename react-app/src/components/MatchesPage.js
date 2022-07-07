import React, { useEffect, useState } from 'react'
import { useSelector, useDispatch } from 'react-redux'
import { getMatches, selectMatches } from '../features/matchesSlice'
import Match from './Match'
import Loading from './Loading'
import './MatchesPage.css'
import {Pagination} from 'react-bootstrap'


const MatchesPage = () => {
    const matches = useSelector(selectMatches)
    const dispatch = useDispatch()
    const [matchDay, setMatchDay] = useState(sessionStorage.getItem('matchDay') ? parseInt(sessionStorage.getItem('matchDay')) : 1)
    const [loading, setLoading] = useState(true)

    const [showMatchStats, setShowMatchStats] = useState({
                                                    0: false,
                                                    1: false,
                                                    2: false,
                                                    3: false,
                                                    4: false,
                                                    5: false,
                                                    6: false,
                                                    7: false,
                                                    8: false,
                                                    9: false
                                                })

    const changeMatchDay = (matchDay) => {
        setMatchDay(matchDay)
        sessionStorage.setItem('matchDay', matchDay)
    }


    useEffect(() => {
        dispatch(getMatches(matchDay))
    }, [dispatch, matchDay])

    useEffect(() => {
        setLoading(false);
    }, [matches])

    useEffect(() => {
        setLoading(true);
    }, [matchDay])

    let matchDays = []

    matchDays.push(
        <Pagination.Item className='menuTitle' key={-1}>
            Match Day
        </Pagination.Item>
    )
    for (let i = 1; i <=38; i++) {
        matchDays.push(
            <Pagination.Item  key={i} active={i === matchDay} onClick={() => changeMatchDay(i)}>
                {i}
            </Pagination.Item>
        )
        
    }


    
    if(loading || !matches || !matchDay){
        return <Loading />
    }

    let matchRows = []
    
    for(let i=0; i<=matches.length -1; i+=2){
        matchRows.push(
            <div key={i} className={showMatchStats[i] || showMatchStats[i+1] ? `matchesRow showStats` : `matchesRow`}>
                <Match index={i} showMatchStatsObj={showMatchStats} setShowMatchStats={setShowMatchStats} match={matches[i]} matchDay={matchDay} />
                <Match index={i+1} showMatchStatsObj={showMatchStats} setShowMatchStats={setShowMatchStats} match={matches[i+1]} matchDay={matchDay} />
            </div>
        )
    }

    return(
        <div className='matchesPage'>

            <div className='matchDayMenu'>
                <Pagination className='matchDays'>
                    {matchDays}
                </Pagination>
            </div>

            {matchRows}

        </div>
    )
}

export default MatchesPage