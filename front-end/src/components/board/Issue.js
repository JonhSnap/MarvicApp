import React from 'react'
import { issueTypes } from '../../util/constants'
import './Issue.scss'

function Issue({ issue }) {

    return (
        <div className="issue">
            <div className="wrapper-summary">
                <div className="type">
                    <img className='type-img' src={issueTypes.find(item => item.value === issue.id_IssueType)?.thumbnail} alt="" />
                </div>
                <p className="summary">{issue.summary}</p>
            </div>
            <div className="epic">Epic</div>
        </div>
    )
}

export default Issue