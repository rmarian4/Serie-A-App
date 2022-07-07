import React from "react";
import './LeadersCard.css'
import {Table} from 'react-bootstrap'

const KeyPassLeadersCard = ({keyPassLeaders}) => {
    return (
        <div className="leadersCard">
            <h1>Top {keyPassLeaders.length} for Key Passes</h1>
            <Table variant='dark' hover>
                <thead>
                    <tr>
                        <td></td>
                        <td className='text-center'>Player</td>
                        <td className='text-center'>Key Passes</td>
                    </tr>
                </thead>
                <tbody>
                    {keyPassLeaders.map((player, i) => {
                        return (
                            <tr key={i}>
                                <td className='text-center'>{player.spot}</td>
                                <td className="playerCell">
                                    <img src={player.clubCrestUrl} alt='' />
                                    {player.playerName}
                                </td>
                                <td className='text-center'>{player.keyPasses}</td>
                            </tr>
                        )
                    })}
                </tbody>
            </Table>
        </div>
    )
}

export default KeyPassLeadersCard