import React, { useRef, useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCircle } from '@fortawesome/free-solid-svg-icons'
import useModal from '../../hooks/useModal'
import OptionHeaderBacklogComponent from './OptionHeaderBacklogComponent';
import { documentHeight } from '../../util/constants';

const secondThirdScreen = documentHeight * 2 / 3;

function OptionSprint({ setShowEditSprint, project, sprint }) {
    const [show, setShow, handleClose] = useModal();
    const [coord, setCoord] = useState({});
    const nodeRef = useRef();

    // handle click
    const handleClick = () => {
        if (show) return;
        const bounding = nodeRef.current.getBoundingClientRect();
        if (bounding) {
            setShow(true);
            setCoord(bounding);
        }
    }

    return (
        <div ref={nodeRef} onClick={handleClick} className='flex gap-x-1 w-fit p-2 cursor-pointer bg-white rounded-md'>
            <FontAwesomeIcon className='w-[6px] pointer-events-none' icon={faCircle}></FontAwesomeIcon>
            <FontAwesomeIcon className='w-[6px] pointer-events-none' icon={faCircle}></FontAwesomeIcon>
            <FontAwesomeIcon className='w-[6px] pointer-events-none' icon={faCircle}></FontAwesomeIcon>
            {
                show &&
                <OptionHeaderBacklogComponent
                    setShowEditSprint={setShowEditSprint}
                    sprint={sprint}
                    project={project}
                    onClose={handleClose}
                    bodyStyle={{
                        top: coord.bottom <= secondThirdScreen ? coord.bottom : null,
                        left: coord.left - 30,
                        bottom: !(coord.bottom <= secondThirdScreen) ? (documentHeight - coord.top) : null
                    }}
                />
            }
        </div>
    )
}

export default OptionSprint