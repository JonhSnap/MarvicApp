import React, { useState } from 'react'
import { NIL } from 'uuid';
import { v4 } from 'uuid'
import { useListIssueContext } from '../../contexts/listIssueContext';
import { useSprintContext } from '../../contexts/sprintContext';
import { fetchIssue } from '../../reducers/listIssueReducer';
import { completeSprint, fetchSprint } from '../../reducers/sprintReducer';
import SelectBoxBase from './SelectBoxBase'

function SprintSelectbox({ listSprint, sprint, project, onClose, bodyStyle }) {
    const { dispatch } = useSprintContext();
    const [, dispatchIssue] = useListIssueContext();

    // handle choose sprint
    const handleChooseSprint = async (idSprint) => {
        const dataPost = {
            "currentProjectId": project.id,
            "currentSprintId": sprint.id,
            "newSprintId": idSprint
        }
        await completeSprint(dataPost, dispatch);
        await fetchSprint(project.id, dispatch);
        fetchIssue(project.id, dispatchIssue);
    }

    return (
        <SelectBoxBase
            onClose={onClose}
            bodyStyle={bodyStyle}
        >
            <div className='min-w-[100px] max-w-[150px] bg-white rounded shadow-md flex flex-col'>
                <p className='px-3 py-2 font-bold text-primary'>Select sprint</p>
                {
                    listSprint.map(item => (
                        <div onClick={() => handleChooseSprint(item.id)} key={v4()} className='px-3 py-2 cursor-pointer hover:bg-gray-main'>{item.sprintName}</div>
                    ))
                }
                <div onClick={() => handleChooseSprint(NIL)} key={v4()} className='px-3 py-2 cursor-pointer hover:bg-gray-main'>Back to backlog</div>
            </div>
        </SelectBoxBase>
    )
}

export default SprintSelectbox