import { createSlice } from "@reduxjs/toolkit";
import {fetchStatLeaders} from '../services/getData'

const initialState = {
    statLeaders: null
}

const statLeadersSlice = createSlice({
    name: 'statLeaders',
    initialState,
    reducers:{
        setStatLeaders: (state, action) => {
            state.statLeaders = action.payload
        }
    }
})

export const getStatLeaders = () => {
    return async dispatch => {
        let statLeaders = await fetchStatLeaders()
        dispatch(setStatLeaders(statLeaders))
    }
}

export const {setStatLeaders} = statLeadersSlice.actions;
export const selectStatLeaders = state => state.statLeaders.statLeaders;
export default statLeadersSlice.reducer;