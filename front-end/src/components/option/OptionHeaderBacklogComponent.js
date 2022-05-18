import React from 'react'
import { useSprintContext } from '../../contexts/sprintContext';
import { deleteSprint, fetchSprint } from '../../reducers/sprintReducer'
import Portal from '../portal/Portal';

export default function OptionHeaderBacklogComponent({ sprint, project, setShowEditSprint, bodyStyle, onClose }) {
    const { dispatch } = useSprintContext();

    const handleDeleteSprint = async () => {
        await deleteSprint(sprint?.id, dispatch);
        fetchSprint(project?.id, dispatch);
    }

    return (
        <Portal
            containerclassName='fixed inset-0 z-10'
            bodyClassName='fixed z-20'
            bodyStyle={bodyStyle}
            overlay={false}
            onClose={onClose}
        >
            <div className=' bg-white whitespace-nowrap w-fit h-auto flex flex-col rounded-md shadow-md'>
                <div onClick={() => setShowEditSprint(true)} role="button" className='p-2 hover:bg-[#f4f5f7]'>
                    Edit sprint
                </div>
                <div onClick={handleDeleteSprint} role="button" className='p-2 hover:bg-[#f4f5f7]'>
                    Delete sprint
                </div>
            </div>
        </Portal>
    )
}
