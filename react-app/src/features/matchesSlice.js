import {createSlice } from '@reduxjs/toolkit';
import { fetchMatches, fetchMatchStats } from '../services/getData';


const initialState = {
    matches: null
}

const matchesSlice = createSlice({
    name: 'matches',
    initialState,
    reducers: {
        setMatches: (state, action) => {
            return {...state, matches: action.payload}
        },
        setMatchStats: (state, action) => {
            let match = state.matches.find(match => match.hometeam.teamName === action.payload.homeTeam)
            let updatedMatch = {...match, matchStats: action.payload.matchStats}

            let updatedMatches = state.matches.map(match => match.hometeam.teamName !== updatedMatch.hometeam.teamName ? match : updatedMatch)
            return {...state, matches: updatedMatches}
        }
    }
})

export const getMatches = matchDay => {
    return async dispatch => {
        let matches = await fetchMatches(matchDay)
        dispatch(setMatches(matches))
    }
}

export const getMatchStats = (matchDay, homeTeam, awayTeam) => {
    return async dispatch => {
        let matchStats = await fetchMatchStats(matchDay, homeTeam, awayTeam)
        let actionObject = {
            matchStats,
            homeTeam
        }
        dispatch(setMatchStats(actionObject))
    }
}

export const {setMatches, setMatchStats} = matchesSlice.actions;
export default matchesSlice.reducer;
export const selectMatches = state => state.matches.matches;

