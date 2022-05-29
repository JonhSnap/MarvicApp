import React, { useRef, useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCircle } from '@fortawesome/free-solid-svg-icons'
import useModal from '../../hooks/useModal'
import OptionItemBacklogComponent from './OptionItemBacklogComponent';
import { documentHeight } from '../../util/constants'

const secondThirdScreen = documentHeight * 2 / 3;

export default function OptionComponent({ project, issue, child = null }) {
    const [show, setShow, handleClose] = useModal();
    const [coord, setCoord] = useState();
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
        <>
            <div onClick={handleClick} ref={nodeRef} className='flex flex-col h-full'>
                <div className='flex items-center justify-center cursor-pointer'>
                    <span className='inline-flex items-center justify-center text-gray-500 w-6 h-6 hover:text-gray-800'>
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                            <path d="M6 10a2 2 0 11-4 0 2 2 0 014 0zM12 10a2 2 0 11-4 0 2 2 0 014 0zM16 12a2 2 0 100-4 2 2 0 000 4z" />
                        </svg>
                    </span>
                </div>
                {
                    show &&
                    (
                        <OptionItemBacklogComponent
                            bodyStyle={{
                                top: coord.bottom <= secondThirdScreen ? coord.bottom : null,
                                left: coord.left - 60,
                                bottom: !(coord.bottom <= secondThirdScreen) ? (documentHeight - coord.top) : null
                            }}
                            project={project}
                            issue={issue}
                            onClose={handleClose}
                        />
                    )
                }
            </div>
        </>
    )
}
