import React, { useEffect, useRef, useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { toast } from 'react-toastify'
import { faCirclePlus } from '@fortawesome/free-solid-svg-icons'
import DropDownComponent from './dropdown/DropDownComponent'
import { useSelector } from 'react-redux'
import { createIssue, fetchIssue } from '../reducers/listIssueReducer'
import { useListIssueContext} from '../contexts/listIssueContext'
import createToast from '../util/createToast'

function InputComponent({ setShow, project, idIssueType }) {
  const [, dispatch] = useListIssueContext()
  const filedRef = useRef(null);
  const [selectedValue, setSelectedValue] = useState(2);
  const [valueInput, setValueInput] = useState('');
  const { currentUser } = useSelector(state => state.auth.login)

  const handleChange = e => {
    setSelectedValue(e.value);
  }
  // handle enter
  const handleEnter = (e) => {
    if(e.code === 'Enter') {
      if(valueInput) {
        const issuesPost = {
          "id_Project": project.id,
          "id_IssueType": Number(idIssueType) || Number(selectedValue),
          "story_Point_Estimate": 0,
          "priority": 3,
          "id_Stage": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "id_Assignee": null,
          "summary": valueInput,
          "isFlagged": 0,
          "isWatched": 0,
          "id_Creator": currentUser.id,
          "isDeleted": 0,
          "dateCreated": new Date()
        };
        createIssue(issuesPost, dispatch);
        setShow(false);
        // show toast message
        createToast('success', 'Create issue successfully!')
        setTimeout(() => {
          fetchIssue(project.id, dispatch);
        }, 500);
      }
    }
  }
  
  useEffect(() => {
    // var input = document.getElementById('input-create')

    const handleClick2 = (e) => {
      if (!e.target.matches('.item-drop-down') && !filedRef.current.contains(e.target)) {
        setShow(false)
      }
    }
    // const handleKeyBoardEnter = (event) => {
    //   if (event.key === "Enter") {
    //     if (input.value != "") {
    //       event.preventDefault();
    //       createIssues();
    //     }
    //   }
    // }
    // input.addEventListener("keypress", handleKeyBoardEnter);
    document.addEventListener('click', handleClick2)
    return () => {
      // input.removeEventListener("keypress", handleKeyBoardEnter);
      document.removeEventListener('click', handleClick2);
    }
  }, [])

  return (
    <>
      <div ref={filedRef} className='w-full h-full flex items-center'>
      {
        !idIssueType &&
        <div id='react-select'>
          <DropDownComponent selectedValue={selectedValue} handleChange={handleChange} />
        </div>
      }
        <input onKeyUp={handleEnter} value={valueInput} onChange={(event) => setValueInput(event.target.value)} id='input-create' autoFocus className='p-2 ml-2 rounded-[5px] flex-1 outline-blue-500' placeholder='What needs to be done?' />
      </div>
    </>
  )
}

export default function CreateIssuesComponent({ createWhat, listIssue, setListIssue, project, idIssueType }) {
  const [show, setShow] = useState(false)

  const handleClick = () => {
    setShow(true)
  }

  return (
    <>
      <div id='wrap-create' className='w-full h-14 py-3 flex items-center cursor-pointer'>
        {show ? (<InputComponent idIssueType={idIssueType} project={project} listIssue={listIssue} setListIssue={setListIssue} setShow={setShow} />) : (<div onClick={handleClick} className='w-full h-full flex items-center'>
          <FontAwesomeIcon className='px-2' size='2x' icon={faCirclePlus} />
          <div className='pl-4'>Create {createWhat}</div>
        </div>)}
      </div>
    </>
  )
}