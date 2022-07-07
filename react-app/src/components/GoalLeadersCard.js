import React from 'react'
import {Table} from 'react-bootstrap'
import './LeadersCard.css'

const GoalLeadersCard = ({goalLeaders}) => {
    return (
        <div className='leadersCard'>
            <h1>Top {goalLeaders.length} Goal Scorers</h1>
            <Table className='leaderTable' variant='dark' hover>
                <thead>
                    <tr>
                        <td></td>
                        <td className='text-center'>Player</td>
                        <td className='text-center'>Goals</td>
                        <td className='text-center'>Games Played</td>
                        <td className='text-center'>Penalties</td>
                    </tr>
                </thead>
                <tbody>
                    {goalLeaders.map((player, i) => {
                        return (
                            <tr key={i}>
                                <td className='text-center'>{player.spot}</td>
                                <td className='playerCell'>
                                    <img src={player.clubCrestUrl} alt='' />
                                    {player.playerName}
                                </td>
                                <td className='text-center'>{player.goalsScored}</td>
                                <td className='text-center'>{player.gamesPlayed}</td>
                                <td className='text-center'>{player.penaltyGoals}</td>
                            </tr>
                        )
                    })}
                </tbody>
            </Table>
        </div>
    )
}

export default GoalLeadersCard