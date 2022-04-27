import React, { useRef, useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faAngleDown, faSquareCheck, faTimes, faAngleRight, faFlag, faBolt, faCheck, faLock, faEye, faThumbsUp, faTimeline, faPaperclip, faLink, faPlus, faArrowDownShortWide, faArrowDownWideShort } from '@fortawesome/free-solid-svg-icons'
import OptionComponent from '../option/OptionComponent'
import ButtonBacklogComponent from '../backlog/ButtonBacklogComponent'
import MemberComponent from '../board/MemberComponent'
import CKEditorComponent from '../CKEditorComponent'
import ModalBase from '../modal/ModalBase'

function EditIssuePopup({ issue, handleClose, setShow }) {
    const ref = useRef(null)
    const [showFlag, setShowFlag] = useState(false);
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
    
      const [showCKEditorDescription, setShowCKEditorDescription] = useState(false)
      const [showCKEditorCMT, setShowCKEditorCMT] = useState(false)
    
      const showCKEditorDescriptionClick = () => {
        setShowCKEditorDescription(true);
      }
    
      const showCKEditorCMTClick = () => {
        setShowCKEditorCMT(true)
      }
      const hiddenCKEditorDescriptionClick = () => {
        setShowCKEditorDescription(false)
      }
    
      const hiddenCKEditorCMTClick = () => {
        setShowCKEditorCMT(false)
      }
      const desription = document.querySelector('#description')
      var tempDescription
    
      const getValueCKEditor = (event, editor) => {
        tempDescription = editor.getData()
      }
    
      const handleSaveClick = () => {
        if (tempDescription != undefined)
          document.querySelector('#description').innerHTML = tempDescription
        setShowCKEditorDescription(false)
      }


  return (
    <ModalBase
    containerclassName='fixed inset-0 z-10 flex items-center justify-center'
    bodyClassname='relative content-modal'
    onClose={handleClose}>
        <div
        className='h-[80vh] overflow-auto bg-white overflow-y-auto mb-10 overflow-x-hidden
        flex flex-col flex-[2]  mx-4 relative p-5 rounded-md'>
                    <div className='flex justify-between sticky'>
                        <div className='flex items-center'>
                        <div className='flex items-center whitespace-nowrap'>
                            <FontAwesomeIcon size='1x' className='mx-1 p-[0.2rem] text-white text-[10px] inline-block bg-[#904ee2]' icon={faBolt} />
                            Tên epic
                        </div>
                        <span className='mx-2'> / </span>
                        <div className='flex items-center'>
                            <FontAwesomeIcon size='1x' className='text-[#4bade8]' icon={faSquareCheck} />
                            Name
                        </div>
                        </div>
                        <div className='flex items-center'>
                        <FontAwesomeIcon size='2x' className='mx-1 text-[1.5rem]' icon={faLock} />
                        <FontAwesomeIcon size='2x' className='mx-1 text-[1.5rem]' icon={faEye} />
                        <FontAwesomeIcon size='2x' className='mx-1 text-[1.5rem]' icon={faThumbsUp} />
                        <FontAwesomeIcon size='2x' className='mx-1  text-[1.5rem]' icon={faTimeline} />
                        <OptionComponent />
                        <FontAwesomeIcon onClick={() => setShow(false)} size='2x' className='mx-4 text-[1.5rem] cursor-pointer' icon={faTimes} />
                        </div>
                    </div>
                    <div className='text-[2rem] whitespace-nowrap'>
                        {issue?.summary}
                    </div>
                    <div className='flex items-center'>
                        <ButtonBacklogComponent icon={<FontAwesomeIcon size='2x' className='m-1 text-[1.5rem]' icon={faPaperclip} />} text={"Attach"} />
                        <ButtonBacklogComponent icon={<FontAwesomeIcon size='2x' className='m-1 text-[1.5rem]' icon={faTimeline} />} text={"Add a child issue"} />
                        <ButtonBacklogComponent icon={<FontAwesomeIcon size='2x' className='m-1 text-[1.5rem]' icon={faLink} />} text={"Link issue"} />
                    </div>
                    <div className='flex items-center'>
                        <div className='inline-flex flex-col my-4 w-fit'>
                        <div className='uppercase flex items-center p-2 bg-[#ccc] w-fit rounded-[5px] mx-4 whitespace-nowrap'>
                            to do
                            <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={faAngleDown} />
                        </div>
                        </div>
                        <div className='inline-flex w-fit'>
                        <FontAwesomeIcon color='#EF0000' className='mx-2' icon={faFlag} />
                        Flagged
                        </div>
                    </div>
                    <div className='font-bold m-1'>
                        Description
                    </div>
                    {showCKEditorDescription ? (<div id='description' style={{ display: "none" }} onClick={() => showCKEditorDescriptionClick()} className='m-1 py-2' contentEditable="">
                        {issue?.description}
                    </div>) : <div id='description' style={{ display: "block" }} onClick={() => showCKEditorDescriptionClick()} className='m-1 py-2' contentEditable="">
                        {issue?.description}
                    </div>}
                    {/* {!showCKEditorDescription && <div id='description' onClick={() => showCKEditorDescriptionClick()} className='m-1 py-2' contentEditable="">
                        Add a description...
                    </div>} */}
                    {showCKEditorDescription && <CKEditorComponent save={handleSaveClick} dataCKEditor={desription.innerHTML} getValueCKEditor={getValueCKEditor} hidden={hiddenCKEditorDescriptionClick} />}
                    <div className='child-isue'>
                        <div className='flex justify-between w-full h-11 items-center my-2'>
                        <div className='font-bold m-1'>
                            Child issue
                        </div>
                        <div className='flex h-full w-fit items-center'>
                            <div className='uppercase flex items-center p-2 bg-[#ccc] w-fit rounded-[5px] mx-4 whitespace-nowrap'>
                            to do
                            <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={faAngleDown} />
                            </div>
                            <OptionComponent />
                            <FontAwesomeIcon size='2x' className='mx-4 text-[1.5rem]' icon={faPlus} />
                        </div>
                        </div>
                        <div className='item w-full h-13 p-1 bg-white px-4 mt-[-1px] border-solid border-[1px] border-[#ccc] flex justify-between items-center'>
                        <div className='left-item h-full flex items-center'>
                            <div className='icon mx-1 inline-block'>
                            <FontAwesomeIcon size='1x' className='text-[#4bade8]' icon={faSquareCheck} />
                            </div>
                            <div className='mx-1 inline-block text-[#acacac]'>
                            <span>MPM-2</span>
                            </div>
                            <div className='mx-1 inline-block'>
                            <span>Name</span>
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
                        </div>
                        </div>
                    </div>
                    <div className='link-issue mb-6'>
                        <div className='flex justify-between w-full h-11 items-center my-2'>
                        <div className='font-bold m-1'>
                            Link issue
                        </div>
                        <div className='flex h-full w-fit items-center'>
                            <FontAwesomeIcon size='2x' className='mx-4 text-[1.5rem]' icon={faPlus} />
                        </div>
                        </div>
                        <div className='item w-full h-13 p-1 bg-white px-4 mt-[-1px] border-solid border-[1px] border-[#ccc] flex justify-between items-center'>
                        <div className='left-item h-full flex items-center'>
                            <div className='icon mx-1 inline-block'>
                            <FontAwesomeIcon size='1x' className='text-[#4bade8]' icon={faSquareCheck} />
                            </div>
                            <div className='mx-1 inline-block text-[#acacac]'>
                            <span>MPM-2</span>
                            </div>
                            <div className='mx-1 inline-block'>
                            <span>Name</span>
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
                            <FontAwesomeIcon size='2x' className='mx-4 text-[1.5rem]' icon={faTimes} />
                        </div>
                        </div>
                    </div>
                    <div className='detail'>
                        <div className='item w-full h-13 p-1 bg-white px-4 mt-[-1px] border-solid border-[1px] border-[#ccc] border-b-0 flex justify-between items-center'>
                        <div className='flex justify-between w-full h-8 items-center my-2'>
                            <div className='font-bold m-1'>
                            Link issue
                            </div>
                            <div className='flex h-full w-fit items-center'>
                            <FontAwesomeIcon size='2x' className='mx-4 text-[1.5rem]' icon={faAngleDown} />
                            </div>
                        </div>
                        </div>
                        <div className='item w-full h-13 p-1 bg-white px-4 mt-[-1px] border-solid border-[1px] border-[#ccc] flex justify-between items-center flex-wrap'>
                        <div className='w-[40%] h-13 my-4'>
                            Assignee
                        </div>
                        <div className='w-[60%]'>
                            <MemberComponent />
                        </div>
                        <div className='w-[40%] h-13 my-4'>
                            Labels
                        </div>
                        <div className='w-[60%]'>
                            None
                        </div>
                        <div className='w-[40%] h-13 my-4'>
                            Sprint

                        </div>
                        <div className='w-[60%]'>

                            MPM Sprint 1
                        </div>
                        <div className='w-[40%] h-13 my-4'>
                            Story point estimate
                        </div>
                        <div className='w-[60%]'>
                            none
                        </div>
                        <div className='w-[40%] h-13 my-4'>
                            Reporter
                        </div>
                        <div className='w-[60%]'>
                            <MemberComponent />
                        </div>
                        </div>
                    </div>
                    <div className='flex justify-between my-4 text-[#a1a1a1]'>
                        <span>Created 16 hours ago</span>
                        <span>Updated 7 hours ago</span>
                    </div>
                    <div className='flex flex-col'>
                        <div className='font-bold'>
                        Activity
                        </div>
                        <div className='flex justify-between'>
                        <div>
                            <span>Show: </span>
                            <div className='w-fit h-5  p-2 bg-[#ccc] inline-flex justify-center items-center mx-2'>All</div>
                            <div className='w-fit h-5  p-2 bg-[#ccc] inline-flex justify-center items-center mx-2'>Comments</div>
                            <div className='w-fit h-5  p-2 bg-[#ccc] inline-flex justify-center items-center mx-2'>History</div>
                        </div>
                        <div className='w-fit h-5  p-2 inline-flex justify-center items-center mx-2'>Newest first
                            <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={faArrowDownWideShort} />
                        </div>
                        </div>
                    </div>
                    <div className='my-5 flex items-center'>
                        <MemberComponent />
                        {!showCKEditorCMT && <div onClick={() => showCKEditorCMTClick()} className='p-4 border-solid border-[1px] border-[#ccc] flex-1'>
                        Add a comments...
                        </div>}
                        <div>

                        {showCKEditorCMT && <CKEditorComponent hidden={hiddenCKEditorCMTClick} />}
                        </div>
                    </div>
                    <div id='comment' className='flex flex-col'>
                        <div className='my-5 flex'>
                        <MemberComponent />
                        <div className='flex flex-col px-2'>
                            <div className='flex '>
                            <div className='pr-4 flex-1 font-bold'>
                                thinhquocle524
                            </div>
                            <div className='ml-4'>
                                54 minutes ago
                            </div>
                            </div>
                            <div className='py-3' contentEditable="">
                            dsfsdfsdfs
                            </div>
                            <div className='font-bold text-[#838383]'>
                            Delete
                            </div>
                        </div>
                        </div>
                    </div>
        </div>
    </ModalBase>
  )
}

export default EditIssuePopup