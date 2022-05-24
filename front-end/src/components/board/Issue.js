import React, { useMemo } from 'react'
import { useListIssueContext } from '../../contexts/listIssueContext'
import { issueTypes } from '../../util/constants'
import './Issue.scss'

function Issue({ issue }) {
    const [{ issueEpics }] = useListIssueContext();
    const epic = useMemo(() => {
        return issueEpics.find(item => item.id === issue.id_Parent_Issue);
    }, [issueEpics, issue]);

    return (
        <div className="issue">
            <div className="wrapper-summary">
                <div className="type">
                    <img className='type-img' src={issueTypes.find(item => item.value === issue.id_IssueType)?.thumbnail} alt="" />
                </div>
                <p className="summary">{issue.summary}</p>
            </div>
            <div className="epic">{epic ? epic.summary : 'None'}</div>
        </div>
    )
}

export default Issue