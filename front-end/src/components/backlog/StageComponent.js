import '../../../src/index.scss'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCircle, faCirclePlus } from '@fortawesome/free-solid-svg-icons'

import React from 'react'
import TaskComponent from './TaskComponent'

export default function StageComponent() {
    return (
        <>
            <div className='backlog-item h-fit overflow-y-auto w-[26rem] min-w-[26rem] min-h-[50rem] max-h-[50rem]  mx-4 bg-[#F4F5F7] block px-3 rounded-[4px] '>
                <div className='stage-name w-full flex justify-between py-3 sticky top-0 bg-[#F4F5F7] cursor-pointer'>
                    <div className='inline-flex items-center text-3xl font-bold'>Tên Stage</div>
                    <div className='option text-[0.1rem] h-full aspect-square inline-flex justify-center items-center border-solid border-[#000] border-2 p-1 rounded-[4px] bg-white text-[#000] cursor-pointer'>
                        <FontAwesomeIcon size='6x' icon={faCircle} />
                        <FontAwesomeIcon size='6x' icon={faCircle} />
                        <FontAwesomeIcon size='6x' icon={faCircle} />
                    </div>
                </div>
                <TaskComponent />
                <TaskComponent />
                <TaskComponent />
                <TaskComponent />
                <TaskComponent />
                <TaskComponent />
                <TaskComponent />
                <TaskComponent />
                <TaskComponent />
                <TaskComponent />
                <TaskComponent />
                <div className='w-full h-14 px-3 bg-[#C4C4C4] flex items-center rounded-[10px] cursor-pointer'>
                    <FontAwesomeIcon size='2x' icon={faCirclePlus} />
                    <div className='pl-4'>Create issues</div>
                </div>
            </div>
        </>
    )
}
