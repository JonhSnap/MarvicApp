import React from 'react'
import '../../../src/index.scss'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCircle, faCheck, faFlag, faTimeline } from '@fortawesome/free-solid-svg-icons'
import MemberComponent from './MemberComponent'

export default function TaskComponent() {
    return (
        <>
            <div className='task-item min-h-[5rem]  my-3 w-full  rounded-[10px] cursor-pointer'>
                <div className='stage-name w-full flex justify-between bg-[#EB5757] p-2 rounded-t-[10px]'>
                    <div className='inline-flex items-center text-2xl text-[#fff]'>Tên task</div> 
                    <div className='option text-[0.1rem] h-full aspect-square inline-flex justify-center items-center border-solid border-[#000] border-2 p-1 rounded-[4px] bg-white text-[#000] cursor-pointer'>
                        <FontAwesomeIcon size='6x' icon={faCircle} />
                        <FontAwesomeIcon size='6x' icon={faCircle} />
                        <FontAwesomeIcon size='6x' icon={faCircle} />
                    </div>
                </div>
                <div className='w-full h-auto rounded-b-[10px] bg-white px-3 min-h-[1rem]'>
                    <div className='text-[#000] py-3 text-xl'>
                        Mô tả
                    </div>
                    <div className='border-solid border-[#ccc] border-[1px] w-full h-[1px]'></div>
                    <div className='text-[#000] py-3 text-xl'>
                        Mô tả
                    </div>
                    <div className='border-solid border-[#ccc] border-[1px] w-full h-[1px]'></div>
                    <div className='py-4 flex justify-between'>
                        <div className='w-1/4 flex justify-around items-center'>
                            <FontAwesomeIcon icon={faTimeline} />
                            <FontAwesomeIcon color='#17A700' icon={faCheck} />
                            <FontAwesomeIcon color='#EF0000' icon={faFlag} />
                        </div>
                        <MemberComponent />
                    </div>
                </div>
            </div>
        </>
    )
}
