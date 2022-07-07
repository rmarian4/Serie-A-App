import {createSlice } from '@reduxjs/toolkit';
import { fetchStandings } from '../services/getData';

const initialState = {
  standings: null
}

export const standingsSlice = createSlice({
  name: 'standings',
  initialState,
  reducers: {
    setStandings: (state, action) => {
      state.standings = action.payload;
    }
  }
});

export const getStandings = () => {
  return async dispatch => {
      let standings = await fetchStandings()
      dispatch(setStandings(standings))
  }
}

export const { setStandings } = standingsSlice.actions;
export const selectStandings = (state) => state.standings.standings;
export default standingsSlice.reducer;
