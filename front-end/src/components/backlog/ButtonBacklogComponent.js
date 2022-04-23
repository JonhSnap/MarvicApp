import React from 'react'

export default function ButtonBacklogComponent({ text, icon }) {
    return (
        <>
            <div className='btn-main flex items-center rounded-[5px] py-1 px-2  w-fit h-full mx-4 border-solid border-[#000] border-[1px]'>
                {icon}
                <span>{text}</span>
            </div>
        </>
    )
}
