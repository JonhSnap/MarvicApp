import React from 'react'
import TopDetail from '../project-detail/TopDetail';
import './ContainerBoard.scss'

function ContainerBoard({ project }) {
    return (
        <div className='container'>
            <TopDetail project={project} />
            <div className="bottom">

            </div>
        </div>
    )
}

export default ContainerBoard