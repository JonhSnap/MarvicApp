import React, { useEffect, useRef, useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCircle } from '@fortawesome/free-solid-svg-icons'

export default function OptionComponent({ child }) {
    const [show, setShow] = useState(false)

    const ref = useRef(null)

    const closeOpenMenus = (e) => {
        if (ref.current && show && !ref.current.contains(e.target)) {
            setShow(false)
        }
    }

    document.addEventListener('mousedown', closeOpenMenus)

    const handleClick = () => {
        setShow(v => !v)
    }

    return (
        <>
            <div ref={ref} className='relative flex flex-col h-full'>
                <div onClick={handleClick} className='option relative p-1  text-[0.1rem] h-full aspect-square inline-flex justify-center items-center  rounded-[4px] bg-white text-[#000] cursor-pointer'>
                    <FontAwesomeIcon size='4x' className='p-[0.1rem]' icon={faCircle} />
                    <FontAwesomeIcon size='4x' className='p-[0.1rem]' icon={faCircle} />
                    <FontAwesomeIcon size='4x' className='p-[0.1rem]' icon={faCircle} />
                </div>
                {show && child}
            </div>
        </>
    )
}
