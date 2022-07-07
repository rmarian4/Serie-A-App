import React from 'react'
import {Table} from 'react-bootstrap'
import './LeadersCard.css'

const RecoveryLeadersCard = ({recoveryLeaders}) => {
    return (
        <div className='leadersCard'>
            <h1>Top {recoveryLeaders.length} for Recoveries</h1>
            <Table variant='dark' hover>
                <thead>
                    <tr>
                        <td></td>
                        <td className='text-center'>Player</td>
                        <td className='text-center'>Recoveries</td>
                    </tr>
                </thead>
                <tbody>
                    {recoveryLeaders.map((player, i) => {
                        return (
                            <tr key={i}>
                                <td className='text-center'>{player.spot}</td>
                                <td className="playerCell">
                                    <img src={player.clubCrestUrl} alt='' />
                                    {player.playerName}
                                </td>
                                <td className='text-center'>{player.recoveries}</td>
                            </tr>
                        )
                    })}
                </tbody>
            </Table>
        </div>
    )
}

export default RecoveryLeadersCard