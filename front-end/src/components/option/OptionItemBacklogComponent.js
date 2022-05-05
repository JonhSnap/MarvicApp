import React from 'react'
import { useListIssueContext } from '../../contexts/listIssueContext';
import { deleteIssue, fetchIssue, updateIssues } from '../../reducers/listIssueReducer';
import createToast from '../../util/createToast';

export default function OptionItemBacklogComponent({ issue, project }) {
    const [, dispatch] = useListIssueContext();

    // handle change flagg
    const handleChangeFlag = () => {
        const issueUpdate = {...issue};
        if(issue.isFlagged) {
            issueUpdate.isFlagged = 0
        }else {
            issueUpdate.isFlagged = 1
        }
        updateIssues(issueUpdate, dispatch);
        createToast('success', issueUpdate.isFlagged ? 'Add flag successfully!' : 'Remove flag successfully!')
        setTimeout(() => {
            fetchIssue(project.id, dispatch);
        }, 500);
    }
    // handleDeleteIssue
    const handleDeleteIssue = () => {
        if(window.confirm(`Are you sure to delete issue ${issue.summary}?`)) {
            deleteIssue(issue.id, dispatch);
        }else {
            return;
        }
    }

    return (
        <>
            <div className='relative'>
                <div className='absolute right-0 border-solid border-[1px] border-[#ccc] rounded-[2px] shadow-2xl z-50 visible bg-white whitespace-nowrap w-fit h-auto flex flex-col'>
                    <div className='p-2 uppercase text-[#ccc]'>
                        action
                    </div>
                    <div onClick={handleChangeFlag} role="button" className='p-2 hover:bg-[#f4f5f7]'>
                        {issue?.isFlagged ? 'Remove flag' : 'Add flag'}
                    </div>
                    <div role="button" className='p-2 hover:bg-[#f4f5f7]'>
                        Change parent
                    </div>
                    <div role="button" className='p-2 hover:bg-[#f4f5f7]'>
                        Copy issue link
                    </div>
                    <div onClick={handleDeleteIssue} role="button" className='p-2 hover:bg-[#f4f5f7]'>
                        Delete
                    </div>
                    <div className='p-2 uppercase text-[#ccc]'>
                        move to
                    </div>
                    <div role="button" className='p-2 hover:bg-[#f4f5f7]'>
                        MPM Sprint 2
                    </div>
                    <div role="button" className='p-2 hover:bg-[#f4f5f7]'>
                        MPM Sprint 3
                    </div>
                    <div role="button" className='p-2 hover:bg-[#f4f5f7]'>
                        Top of backlog
                    </div>
                    <div role="button" className='p-2 hover:bg-[#f4f5f7]'>
                        Bottom of backlog
                    </div>
                </div>
            </div>
        </>
    )
}
