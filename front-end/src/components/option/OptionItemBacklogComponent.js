import React from 'react'

export default function OptionItemBacklogComponent(props) {
    return (
        <>
            <div className='relative'>
                <div className='absolute right-0 border-solid border-[1px] border-[#ccc] rounded-[2px] shadow-2xl z-50 visible bg-white whitespace-nowrap w-fit h-auto flex flex-col'>
                    <div className='p-2 uppercase text-[#ccc]'>
                        action
                    </div>
                    <div onClick={() => props.handleClickAddFlag()} role="button" className='p-2 hover:bg-[#f4f5f7]'>
                        {props.editHTMLAddFlag()}
                    </div>
                    <div role="button" className='p-2 hover:bg-[#f4f5f7]'>
                        Change parent
                    </div>
                    <div role="button" className='p-2 hover:bg-[#f4f5f7]'>
                        Copy issue link
                    </div>
                    <div role="button" className='p-2 hover:bg-[#f4f5f7]'>
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
