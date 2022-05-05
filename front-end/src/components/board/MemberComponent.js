import React, { memo, useEffect, useState } from 'react'
import '../../../src/index.scss'
import { NIL } from 'uuid'
import { useListIssueContext } from '../../contexts/listIssueContext';
import { fetchIssue, updateIssues } from '../../reducers/listIssueReducer';

function MemberComponent({project, members, issue}) {
    const [assignee, setAssignee] = useState();
    const [showAssignee, setShowAssignee] = useState(false);
    const [, dispatch] = useListIssueContext();

    // handle toggle assignee
    const handleToggleAssignee = (e) => {
        if(e.target.matches('.wrap-assignee')) {
            setShowAssignee(prev => !prev);
        }
    }
    // handle Unassignee
    const handleUnassignee = () => {
        const issueUpdate = {...issue}
        issueUpdate.id_Assignee = NIL;
        issueUpdate.updateDate = new Date();
        updateIssues(issueUpdate, dispatch);
        setTimeout(() => {
            fetchIssue(project.id, dispatch);
        }, 500);
    }

    useEffect(() => {
        if(members?.length > 0) {
            if(issue.id_Assignee && issue.id_Assignee !== '00000000-0000-0000-0000-000000000000') {
                const result = members.find(item => item.id === issue.id_Assignee);
                result ? setAssignee(result) : setAssignee({});
            }
        }
    }, [members])

    return (
        <>
            <div onClick={handleToggleAssignee} className='wrap-assignee relative wrap-member w-[22px] h-[22px] mr-2'>
            {
                assignee ?
                <span title={assignee.userName} className='pointer-events-none inline-flex items-center justify-center w-full h-full text-white
                text-[12px] bg-orange-400 rounded-full'>
                {
                    assignee?.userName?.slice(0, 1)
                }
                </span> :
                <span className='inline-block w-full h-full pointer-events-none text-[#ccc] hover:text-gray-500'>
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                    <path fillRule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-6-3a2 2 0 11-4 0 2 2 0 014 0zm-2 4a5 5 0 00-4.546 2.916A5.986 5.986 0 0010 16a5.986 5.986 0 004.546-2.084A5 5 0 0010 11z" clipRule="evenodd" />
                    </svg>
                </span>
            }
            {
                showAssignee &&
                <div className="absolute z-10 top-[calc(100%+10px)] left-0 -translate-x-50 bg-white
                flex flex-col w-[100px] shadow-lg rounded-md overflow-hidden">
                {
                    issue.id_Assignee && issue.id_Assignee !== '00000000-0000-0000-0000-000000000000' &&
                    <div onClick={handleUnassignee} className='w-full p-2 mb-1 bg-white hover:bg-gray-main'>Unassigneed</div>
                }
                    {
                        members?.length > 0 &&
                        members.map(item => (
                            <div
                            key={item.id}
                            className={`w-full p-2 mb1 bg-white hover:bg-gray-main ${item.id === issue.id_Assignee ? 'bg-gray-main' : ''}`}
                            >{item.userName}</div>
                        ))
                    }
                </div>
            }
            </div>
        </>
    )
}
export default memo(MemberComponent);
