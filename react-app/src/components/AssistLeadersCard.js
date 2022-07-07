import React from 'react'
import './LeadersCard.css'
import { Table } from 'react-bootstrap'

const AssistLeadersCard = ({assistLeaders}) => {
    return (
        <div className='leadersCard'>
            <h1>Top {assistLeaders.length} for Assists</h1>
            <Table variant='dark' hover>
                <thead>
                    <tr>
                        <td></td>
                        <td className='text-center'>Player</td>
                        <td className='text-center'>Assists</td>
                    </tr>
                </thead>
                <tbody>
                    {assistLeaders.map((player, i) => {
                        return (
                            <tr key={i}>
                                <td className='text-center'>{player.spot}</td>
                                <td className='playerCell'>
                                    <img src={player.clubCrestUrl} alt='' />
                                    {player.playerName}
                                </td>
                                <td className='text-center'>{player.assists}</td>
                            </tr>
                        )
                    })}
                </tbody>
            </Table>
        </div>
    )
}

export default AssistLeadersCard