import React from 'react'
import {Table} from 'react-bootstrap'
import './LeadersCard.css'

const KmRunLeadersCard = ({kmRunLeaders}) => {
    return (
        <div className='leadersCard'>
            <h1>Top {kmRunLeaders.length} for KM Run</h1>
            <Table variant='dark' hover>
                <thead>
                    <tr>
                        <td></td>
                        <td className='text-center'>Player</td>
                        <td className='text-center'>Avg</td>
                        <td className='text-center'>Minutes</td>
                    </tr>
                </thead>
                <tbody>
                    {kmRunLeaders.map((player, i) => {
                        return (
                            <tr key={i}>
                                <td className='text-center'>{player.spot}</td>
                                <td className='playerCell'>
                                    <img src={player.clubCrestUrl} alt='' />
                                    {player.playerName}
                                </td>
                                <td className='text-center'>{player.kmRun}</td>
                                <td className='text-center'>{player.minutes}</td>
                            </tr>
                        )
                    })}
                </tbody>
            </Table>
        </div>
    )
}

export default KmRunLeadersCard