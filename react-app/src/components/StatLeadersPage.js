import React, {useEffect} from "react";
import { useDispatch, useSelector } from 'react-redux'
import { selectStatLeaders, getStatLeaders } from '../features/statLeadersSlice'
import AssistLeadersCard from "./AssistLeadersCard";
import GoalLeadersCard from "./GoalLeadersCard";
import KeyPassLeadersCard from "./KeyPassLeadersCard";
import KmRunLeadersCard from './KmRunLeadersCard'
import RecoveryLeadersCard from "./RecoveryLeadersCard";
import SavesLeadersCard from "./SavesLeadersCard";
import './StatLeadersPage.css'
import Loading from './Loading'

const StatLeadersPage = () => {
    const statLeaders = useSelector(selectStatLeaders)
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(getStatLeaders())
    }, [dispatch])

    if(statLeaders === null) {
        return <Loading />
    }
    else if (statLeaders === 'No stats available since season has not begun.') {
        return (
            <div className="messageContainer">
                <h1>No leaders yet, season has not yet begun</h1>
            </div>
        )
    }


    return (
        <div className="statLeadersPage">
            <div className="statsLeaderRow">
                <GoalLeadersCard goalLeaders={statLeaders.goalLeaders} />
                <AssistLeadersCard assistLeaders={statLeaders.assistLeaders} />
            </div>
            <div className="statsLeaderRow">
                <KeyPassLeadersCard keyPassLeaders={statLeaders.keyPassLeaders} />
                <KmRunLeadersCard kmRunLeaders={statLeaders.kmRunLeaders} />
            </div>
            <div className="statsLeaderRow">
                <RecoveryLeadersCard recoveryLeaders={statLeaders.recoveryLeaders} />
                <SavesLeadersCard savesLeaders={statLeaders.savesMadeLeaders} />
            </div>
        </div>
    )
}

export default StatLeadersPage