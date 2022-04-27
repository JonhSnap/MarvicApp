import React, { useEffect, useRef, useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faAngleDown, faSquareCheck, faTimes, faAngleRight, faFlag, faBolt, faCheck, faLock, faEye, faThumbsUp, faTimeline, faPaperclip, faLink, faPlus, faArrowDownShortWide, faArrowDownWideShort } from '@fortawesome/free-solid-svg-icons'
import MemberComponent from '../board/MemberComponent'
import OptionComponent from '../option/OptionComponent'
import OptionItemBacklogComponent from '../option/OptionItemBacklogComponent'
import useModal from '../../hooks/useModal'
import EditIssuePopup from '../popup/EditIssuePopup'



export default function TaskItemComponent({ issue }) {
    const [showEdit, setShow, handleClose] = useModal();
    const [showFlag, setShowFlag] = useState(false)

    const ref = useRef(null)

    const handleClickAddFlag = function () {
        if (!showFlag) {
            setShowFlag(true)
            ref.current.style.backgroundColor = "#ffbdad"
        } else {
            setShowFlag(false)
            ref.current.style.backgroundColor = "#fff"
        }
    }

    const editHTMLAddFlag = () => {
        if (showFlag)
            return "Remove flag"
        else
            return "Add flag"
    }
    // handle click item
    const handleClickItem = (e) => {
        if(e.target.matches('.item')) {
            setShow(true);
        }
    }
    
    return (
        <>  
            {
                showEdit && <EditIssuePopup setShow={setShow} handleClose={handleClose}  issue={issue}></EditIssuePopup>
            }
            <div onClick={handleClickItem} ref={ref} className='item hover:bg-[#eee] cursor-pointer w-full h-13 p-1 bg-white px-4 mt-[-1px] border-solid border-[1px] border-[#ccc] flex justify-between items-center'>
                <div className='left-item h-full flex items-center'>
                    <div className='icon mx-1 inline-block'>
                        <FontAwesomeIcon size='1x' className='text-[#4bade8]' icon={faSquareCheck} />
                    </div>
                    <div className='mx-1 inline-block text-[#acacac]'>
                        <span>{issue.summary}</span>
                    </div>
                    <div className='mx-1 inline-block'>
                        <span>{issue?.summary}</span>
                    </div>
                    <div className='parent bg-[#eae6ff] uppercase inline-block px-1 mx-1 rounded-[2px] font-medium'>
                        <span>parent</span>
                    </div>
                </div>
                <div className='right-item h-full w-fit flex items-center'>
                    <div className='rounded-full  inline-flex w-5 h-5 text-xs bg-[#dfe1e6] mx-[0.2rem]'>
                        <span className='m-auto'>4</span>
                    </div>
                    {showFlag && <FontAwesomeIcon color='#EF0000' className='mx-2' icon={faFlag} />}
                    <div className='whitespace-nowrap h-4 w-auto uppercase text-xs font-bold  mx-2 border-solid border-[0.5px] border-[#ccc] flex justify-center items-center py-3 px-2 bg-[#ccc]'>
                        to do
                        <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={faAngleDown} />
                    </div>
                    <MemberComponent />
                    <OptionComponent child={<OptionItemBacklogComponent editHTMLAddFlag={editHTMLAddFlag} handleClickAddFlag={handleClickAddFlag} />} />
                </div>
            </div>
        </>
    )
}
