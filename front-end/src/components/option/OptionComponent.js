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
                <div className='option relative p-1  text-[0.1rem] h-full aspect-square inline-flex justify-center items-center  rounded-[4px] bg-white text-[#000] cursor-pointer'>
                    <FontAwesomeIcon size='4x' className='p-[0.1rem]' icon={faCircle} />
                    <FontAwesomeIcon size='4x' className='p-[0.1rem]' icon={faCircle} />
                    <FontAwesomeIcon size='4x' className='p-[0.1rem]' icon={faCircle} />
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
