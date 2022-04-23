import React from 'react'

export default function OptionHeaderBacklogComponent() {
    return (
        <>
            <div className='relative'>
                <div className='absolute right-0 border-solid border-[1px] border-[#ccc] rounded-[2px] shadow-2xl z-10 bg-white whitespace-nowrap w-fit h-auto flex flex-col'>
                    <div role="button" className='p-2 hover:bg-[#f4f5f7]'>
                        Edit sprint
                    </div>
                    <div role="button" className='p-2 hover:bg-[#f4f5f7]'>
                        Delete sprint
                    </div>
                </div>
            </div>
        </>
    )
}
