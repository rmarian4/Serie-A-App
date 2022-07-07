import React from 'react'
import {Table} from 'react-bootstrap'
import './LeadersCard.css'

const SavesLeadersCard = ({savesLeaders}) => {
    return (
        <div className='leadersCard'>
            <h1>Top {savesLeaders.length} Goalkeepers for Saves Made</h1>
            <Table variant='dark' hover>
                <thead>
                    <tr>
                        <td></td>
                        <td className='text-center'>Player</td>
                        <td className='text-center'>Saves</td>
                    </tr>
                </thead>
                <tbody>
                    {savesLeaders.map((player, i) => {
                        return (
                            <tr key={i}>
                                <td className='text-center'>{player.spot}</td>
                                <td className="playerCell">
                                    <img src={player.clubCrestUrl} alt='' />
                                    {player.playerName}
                                </td>
                                <td className='text-center'>{player.saves}</td>
                            </tr>
                        )
                    })}
                </tbody>
            </Table>
        </div>
    )
}

export default SavesLeadersCard