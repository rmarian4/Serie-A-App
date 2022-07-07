import axios from 'axios';

const baseUrl = "https://localhost:7084/api/SeriaAScoreApp";

const fetchStandings = async () => {
    let response = await axios.get(`${baseUrl}/standings`)
    
    return response.data
}

const fetchStatLeaders = async () => {
    let response = await axios.get(`${baseUrl}/statsLeaders`)

    return response.data
}

const fetchMatches = async (matchDay) => {
    let response = await axios.get(`${baseUrl}/matches/${matchDay}`)

    return response.data
}

const fetchMatchStats = async (matchDay, homeTeam, awayTeam) => {
    let response = await axios.get(`${baseUrl}/matches/${matchDay}/${homeTeam}/${awayTeam}`)

    return response.data
}

export {fetchStandings, fetchStatLeaders, fetchMatches, fetchMatchStats}

