import React, { useEffect, useRef, useState, memo } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faAngleDown, faSquareCheck, faTimes, faAngleRight, faFlag, faBolt, faCheck, faLock, faEye, faThumbsUp, faTimeline, faPaperclip, faLink, faPlus, faArrowDownShortWide, faArrowDownWideShort } from '@fortawesome/free-solid-svg-icons'
import MemberComponent from '../board/MemberComponent'
import OptionComponent from '../option/OptionComponent'
import OptionItemBacklogComponent from '../option/OptionItemBacklogComponent'
import useModal from '../../hooks/useModal'
import EditIssuePopup from '../popup/EditIssuePopup'



function TaskItemComponent({ issue, project }) {
    const [showEdit, setShow, handleClose] = useModal();
    const [showFlag, setShowFlag] = useState(false);
    const [showInputPoint, setShowInputPoint] = useState(false);

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
                showEdit && <EditIssuePopup project={project} setShow={setShow} handleClose={handleClose}  issue={issue}></EditIssuePopup>
            }
            <div onClick={handleClickItem} ref={ref}
            className={`item hover:bg-[#eee] cursor-pointer w-full h-13 p-1
            px-4 mt-[-1px] border-solid border-[1px] border-[#ccc]
            flex justify-between items-center ${issue.isFlagged ? 'bg-[#ffe8e6] hover:bg-[#ffb9b3]' : 'bg-white'}`}>
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
                    {
                        issue.isFlagged === 1 &&
                        <span className='inline-block w-5 h-5 text-[#ff2d1a]'>
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                        <path fillRule="evenodd" d="M3 6a3 3 0 013-3h10a1 1 0 01.8 1.6L14.25 8l2.55 3.4A1 1 0 0116 13H6a1 1 0 00-1 1v3a1 1 0 11-2 0V6z" clipRule="evenodd" />
                        </svg>
                        </span>
                    }
                    {
                    !showInputPoint &&
                    (issue?.story_Point_Estimate?
                    <div onClick={() => setShowInputPoint(true)} className='rounded-full inline-flex items-center justify-center w-fit p-1 text-xs bg-[#dfe1e6] mx-[0.2rem]'>
                        <span className='inline-block w-3 h-3'>{issue?.story_Point_Estimate}</span>
                    </div> :
                    <div onClick={() => setShowInputPoint(true)} className='rounded-full inline-flex items-center justify-center w-fit p-1 text-xs bg-[#dfe1e6] mx-[0.2rem]'>
                        <span className='cursor-pointer inline-block w-3 h-3'>-</span>
                    </div>)
                    }
                    {
                        showInputPoint &&
                        <input
                        value={issue.story_Point_Estimate}
                        autoFocus={true}
                        onBlur={() => setShowInputPoint(false)}
                        className='w-[50px] p-2 border-2 border-primary'
                        type="number" />
                    }
                    {showFlag && <FontAwesomeIcon color='#EF0000' className='mx-2' icon={faFlag} />}
                    <div className='whitespace-nowrap h-4 w-auto uppercase text-xs font-bold  mx-2 border-solid border-[0.5px] border-[#ccc] flex justify-center items-center py-3 px-2 bg-[#ccc]'>
                        to do
                        <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={faAngleDown} />
                    </div>
                    <MemberComponent />
                    <OptionComponent child={<OptionItemBacklogComponent issue={issue} />} />
                </div>
            </div>
        </>
    )
}
export default memo(TaskItemComponent)
