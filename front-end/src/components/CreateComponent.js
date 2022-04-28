import React, { useEffect, useRef, useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCirclePlus, faCircleDot, faClipboard, faSquareCheck } from '@fortawesome/free-solid-svg-icons'
import DropDownComponent from './dropdown/DropDownComponent'
import { v4 } from 'uuid'
import axios from 'axios'
import { BASE_URL } from '../util/constants'
import { useSelector } from 'react-redux'
import { createIssue, fetchIssue } from '../reducers/listIssueReducer'
import { useListIssueContext} from '../contexts/listIssueContext'

function InputComponent({ setShow, project }) {
  const [, dispatch] = useListIssueContext()
  const inputRef = useRef(null)
  const [selectedValue, setSelectedValue] = useState(1);
  const [valueInput, setValueInput] = useState('');
  const { currentUser } = useSelector(state => state.auth.login)

  const handleChange = e => {
    setSelectedValue(e.value);
  }



  useEffect(() => {
    var input = document.getElementById('input-create')

    const createIssues = async () => {

      const issuesPOST = {
        "id_Project": project.id,
        " id_IssueType": selectedValue,
        "story_Point_Estimate": 0,
        "priority": 3,
        "id_Stage": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "summary": input.value,
        "isFlagged": 0,
        "isWatched": 0,
        "id_Creator": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "isDeleted": 0
      };

      try {
        createIssue(issuesPOST, dispatch)
        fetchIssue(project.id, dispatch)
        setShow(false);
      } catch (error) {
        console.log(error);
      }
    }

    const handleClick2 = (e) => {
      if (!e.target.matches('.item-drop-down') && !inputRef.current.contains(e.target)) {
        setShow(false)
      }
    }
    const handleKeyBoardEnter = (event) => {
      if (event.key === "Enter") {
        if (input.value != "") {
          event.preventDefault();
          createIssues();
        }
        // document.getElementById("myBtn").click();
      }
    }
    input.addEventListener("keypress", handleKeyBoardEnter);
    document.addEventListener('click', handleClick2)
    return () => {
      input.removeEventListener("keypress", handleKeyBoardEnter);
      document.removeEventListener('click', handleClick2);
    }
  }, [])




  return (
    <>
      <div ref={inputRef} className='w-full h-full flex items-center'>
        <div id='react-select'>
          <DropDownComponent selectedValue={selectedValue} handleChange={handleChange} />
        </div>
        <input value={valueInput} onChange={(event) => setValueInput(event.target.value)} id='input-create' autoFocus className='p-2 ml-2 rounded-[5px] flex-1 outline-blue-500' placeholder='What needs to be done?' />
      </div>
    </>
  )
}

export default function CreateIssuesComponent({ createWhat, listIssue, setListIssue, project }) {
  const [show, setShow] = useState(false)

  const handleClick = () => {
    setShow(true)
  }

  return (
    <>
      <div id='wrap-create' className='w-full h-14 py-3 flex items-center cursor-pointer'>
        {show ? (<InputComponent project={project} listIssue={listIssue} setListIssue={setListIssue} setShow={setShow} />) : (<div onClick={handleClick} className='w-full h-full flex items-center'>
          <FontAwesomeIcon className='px-2' size='2x' icon={faCirclePlus} />
          <div className='pl-4'>Create {createWhat}</div>
        </div>)}
      </div>
    </>
  )
}
