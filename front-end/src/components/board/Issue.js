import React, { useMemo } from 'react'
import { useListIssueContext } from '../../contexts/listIssueContext'
import { useModalContext } from '../../contexts/modalContext'
import { issueTypes } from '../../util/constants'
import './Issue.scss'

function Issue({ issue }) {
    const {
        modal: [, setShowEdit],
        item: [, setIssue]
    } = useModalContext();
    const [{ issueEpics }] = useListIssueContext();
    const epic = useMemo(() => {
        return issueEpics.find(item => item.id === issue.id_Parent_Issue);
    }, [issueEpics, issue]);
    // handle click issue
    const handleClickIssue = () => {
        setIssue(issue);
        setShowEdit(true);
    }

    return (
        <div className="issue">
            <div className="wrapper-summary">
                <div className="type">
                    <img className='type-img' src={issueTypes.find(item => item.value === issue.id_IssueType)?.thumbnail} alt="" />
                </div>
                <p onClick={handleClickIssue} className="summary">{issue.summary}</p>
            </div>
            <div className="epic">{epic ? epic.summary : 'None'}</div>
        </div>
    )
}

export default Issue