import React from 'react'
import { useSprintContext } from '../../contexts/sprintContext';
import { deleteSprint, fetchSprint } from '../../reducers/sprintReducer'

export default function OptionHeaderBacklogComponent({ sprint, project, setShowEditSprint }) {
    const { dispatch } = useSprintContext();

    const handleDeleteSprint = async () => {
        await deleteSprint(sprint?.id, dispatch);
        fetchSprint(project?.id, dispatch);
    }

    return (
        <>
            <div className='absolute z-0 top-full right-0 border-solid border-[1px] border-[#ccc] rounded-[2px] shadow-2xl z-50 visible bg-white whitespace-nowrap w-fit h-auto flex flex-col'>
                <div onClick={() => setShowEditSprint(true)} role="button" className='p-2 hover:bg-[#f4f5f7]'>
                    Edit sprint
                </div>
                <div onClick={handleDeleteSprint} role="button" className='p-2 hover:bg-[#f4f5f7]'>
                    Delete sprint
                </div>
            </div>
        </>
    )
}
