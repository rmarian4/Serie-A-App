import React, { useEffect } from 'react'
import { Table } from 'react-bootstrap'
import './Standings.css'
import { useDispatch, useSelector } from 'react-redux' 
import {selectStandings, getStandings} from '../features/standingsSlice'
import Loading from './Loading'

const Standings = () => {
    const standings = useSelector(selectStandings)
    const dispatch = useDispatch()


    useEffect(() => {
        dispatch(getStandings())
    }, [dispatch])

    if(standings === null){
        return <Loading />
    }

    return (
        <div className='standings'>
            <div className='table-container'>
                <Table variant='dark' hover>
                    <thead>
                        <tr>
                            <td className='text-center' colSpan={2}></td>
                            <td className='text-center border-left' colSpan={4}>Matches</td>
                            <td className='text-center border-left' colSpan={4}>Home</td>
                            <td className='text-center border-left' colSpan={4}>Away From Home</td>
                            <td className='text-center border-left' colSpan={3}>Goals</td>
                        </tr>
                        <tr>
                            <td className='text-center'>Teams</td>
                            <td className='text-center border-left'>Points</td>
                            <td className='text-center border-left'>P</td>
                            <td className='text-center'>W</td>
                            <td className='text-center'>D</td>
                            <td className='text-center'>L</td>
                            <td className='text-center border-left'>P</td>
                            <td className='text-center'>W</td>
                            <td className='text-center'>D</td>
                            <td className='text-center'>L</td>
                            <td className='text-center border-left'>P</td>
                            <td className='text-center'>W</td>
                            <td className='text-center'>D</td>
                            <td className='text-center'>L</td>
                            <td className='text-center border-left'>GF</td>
                            <td className='text-center'>GA</td>
                            <td className='text-center'>GD</td>
                        </tr>
                    </thead>
                    <tbody>
                        {standings.map((team, i) => {
                            return (
                                <tr key={i}>
                                    <td className='teamCell'>
                                        {team.position}
                                        <img src={team.crestUrl} alt=''/>
                                        {team.teamName}
                                    </td>
                                    <td className='text-center border-left'>{team.points}</td>
                                    <td className='text-center border-left'>{team.gamesPlayed}</td>
                                    <td className='text-center'>{team.wins}</td>
                                    <td className='text-center'>{team.draws}</td>
                                    <td className='text-center'>{team.losses}</td>
                                    <td className='text-center border-left'>{team.homeMatchesPlayed}</td>
                                    <td className='text-center'>{team.homeWins}</td>
                                    <td className='text-center'>{team.homeDraws}</td>
                                    <td className='text-center'>{team.homeLosses}</td>
                                    <td className='text-center border-left'>{team.awayMatchesPlayed}</td>
                                    <td className='text-center'>{team.awayWins}</td>
                                    <td className='text-center'>{team.awayDraws}</td>
                                    <td className='text-center'>{team.awayLosses}</td>
                                    <td className='text-center border-left'>{team.goalsFor}</td>
                                    <td className='text-center'>{team.goalsAgainst}</td>
                                    <td className='text-center'>{team.goalDifference}</td>
                                </tr>
                            )
                        })}
                    </tbody>
                </Table>
            </div>
        </div>
    )
}

export default Standings