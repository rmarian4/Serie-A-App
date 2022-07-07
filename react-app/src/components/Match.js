import React, {useState} from 'react'
import './Match.css'
import { useDispatch } from 'react-redux'
import {getMatchStats} from '../features/matchesSlice'
import {Table} from 'react-bootstrap'
import Spinner from 'react-spinkit' 

const Match = ({match, matchDay, index, showMatchStatsObj, setShowMatchStats}) => {

    const [showStatistics, setShowStatistics] = useState(false)
    const dispatch = useDispatch()

    const showStats = () => {
        let showMatchStatsObjCopy = {...showMatchStatsObj}
        
        if(showStatistics) {
            setShowStatistics(false)
            showMatchStatsObjCopy[index] = false
            setShowMatchStats(showMatchStatsObjCopy)
        } else {
            setShowStatistics(true)
            showMatchStatsObjCopy[index] = true
            setShowMatchStats(showMatchStatsObjCopy)
        }

        if(match.matchStats === null){
            dispatch(getMatchStats(matchDay, match.hometeam.teamName, match.awayteam.teamName))
        }
        
    }
    
    const buttonContainer = (
        <div className='buttonContainer'>
            <button onClick={showStats} className='statsBtn'>Statistics</button>
        </div>
    )

    if(showStatistics && match.matchStats === null) {
        return (
            <div className='loadingMatchStatsContainer'>
                <Spinner
                    name='ball-spin-fade-loader'
                    color='blue'
                    fadeIn='none'
                />
            </div>
        )
    }


    if(showStatistics && match.matchStats !== null) {
        //setRowNum(rowNum)
        return (
            <div className='statsCard'>
                <Table variant='dark' hover>
                    <thead>
                        <tr>
                            <td className='text-center'>
                                <img src={match.hometeam.clubCrestUrl} alt=''/>
                                {match.hometeam.teamName}
                            </td>
                            <td></td>
                            <td className='text-center'>
                                <img src={match.awayteam.clubCrestUrl} alt=''/>
                                {match.awayteam.teamName}
                            </td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td className='text-center'>{match.matchStats.posession.hometeam}</td>
                            <td className='text-center'>Posession</td>
                            <td className='text-center'>{match.matchStats.posession.awayteam}</td>
                        </tr>
                        <tr>
                            <td className='text-center'>{match.matchStats.shotsOnTarget.hometeam}</td>
                            <td className='text-center'>Shots on Target</td>
                            <td className='text-center'>{match.matchStats.shotsOnTarget.awayteam}</td>
                        </tr>
                        <tr>
                            <td className='text-center'>{match.matchStats.totalShots.hometeam}</td>
                            <td className='text-center'>Total Shots</td>
                            <td className='text-center'>{match.matchStats.totalShots.awayteam}</td>
                        </tr>
                        <tr>
                            <td className='text-center'>{match.matchStats.postCrossbar.hometeam}</td>
                            <td className='text-center'>Post/Crossbars hit</td>
                            <td className='text-center'>{match.matchStats.postCrossbar.awayteam}</td>
                        </tr>
                        <tr>
                            <td className='text-center'>{match.matchStats.offSides.hometeam}</td>
                            <td className='text-center'>Offsides</td>
                            <td className='text-center'>{match.matchStats.offSides.awayteam}</td>
                        </tr>
                        <tr>
                            <td className='text-center'>{match.matchStats.foulsCommitted.hometeam}</td>
                            <td className='text-center'>Fouls Committed</td>
                            <td className='text-center'>{match.matchStats.foulsCommitted.awayteam}</td>
                        </tr>
                        <tr>
                            <td className='text-center'>{match.matchStats.yellowCards.hometeam}</td>
                            <td className='text-center'>Yellow Cards</td>
                            <td className='text-center'>{match.matchStats.yellowCards.awayteam}</td>
                        </tr>
                        <tr>
                            <td className='text-center'>{match.matchStats.redCards.hometeam}</td>
                            <td className='text-center'>Red Cards</td>
                            <td className='text-center'>{match.matchStats.redCards.awayteam}</td>
                        </tr>
                        <tr>
                            <td className='text-center'>{match.matchStats.corners.hometeam}</td>
                            <td className='text-center'>Corners</td>
                            <td className='text-center'>{match.matchStats.corners.awayteam}</td>
                        </tr>
                    </tbody>
                </Table>
                <button onClick={showStats} className='scoresBtn'>See Score</button>
            </div>
        )
    }

    return(
        <div className='match'>
            <div className='matchDetails'>
                <div className='homeTeamContainer'>
                    <div className='homeTeamInfo'>
                        <h3>{match.hometeam.teamName}</h3>
                        <img src={match.hometeam.clubCrestUrl} alt='' />
                        <h3>{match.hometeam.goalsScored}</h3>
                    </div>
                    <div className='homeTeamGoalScorers'>
                        {match.hometeam.goalScorers.map((player, i) => 
                            <p key={i}>{player}</p>    
                        )}
                    </div>
                </div>
                
                <div className='matchInfoContainer'>
                    <div className='matchInfo'>
                        {match.date.slice(0,10)}
                    </div>
                </div>


                <div className='awayTeamContainer'>
                    <div className='awayTeamInfo'>
                        <h3>{match.awayteam.goalsScored}</h3>
                        <img src={match.awayteam.clubCrestUrl} alt='' />
                        <h3>{match.awayteam.teamName}</h3>
                    </div>
                    <div className='awayTeamGoalScorers'>
                        {match.awayteam.goalScorers.map((player, i) => 
                            <p key={i}>{player}</p>    
                        )}
                    </div>
                </div>
            </div>


            {match.hometeam.goalsScored !== '-' ? buttonContainer : null}

            
        </div>
    )
}

export default Match