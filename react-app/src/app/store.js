import { configureStore } from '@reduxjs/toolkit';
import standingsReducer from '../features/standingsSlice';
import statLeadersReducer from '../features/statLeadersSlice';
import matchesReducer from '../features/matchesSlice'

export const store = configureStore({
  reducer: {
    standings: standingsReducer,
    statLeaders: statLeadersReducer,
    matches: matchesReducer
  },
});
