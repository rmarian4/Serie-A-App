import React from 'react'
import Spinner from 'react-spinkit' 
import './Loading.css'

const Loading = () => {
    return(
        <div className='loading'>
            <div className='loadingContainer'>
                <img src='https://www.legaseriea.it/assets/legaseriea/images/logo_main_seriea.png?v=35' alt='' />
                <Spinner
                    name='ball-spin-fade-loader'
                    color='blue'
                    fadeIn='none'
                />
            </div>
        </div>
    )
}

export default Loading