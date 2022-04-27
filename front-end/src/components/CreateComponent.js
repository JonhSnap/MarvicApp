import React, { useEffect, useRef, useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCirclePlus, faCircleDot, faClipboard, faSquareCheck } from '@fortawesome/free-solid-svg-icons'
import DropDownComponent from './dropdown/DropDownComponent'

function InputComponent({ setShow }) {
  const inputRef = useRef(null)

  useEffect(() => {
    const handleClick2 = (e) => {
      if (!inputRef.current.contains(e.target)) {
        setShow(false)
      }
    }
    document.addEventListener('click', handleClick2)
    return () => document.removeEventListener('click', handleClick2)
  }, [])

  return (
    <>
      <div ref={inputRef} className='w-full h-full flex items-center'>
        <DropDownComponent />
        <input autoFocus className='p-2 ml-2 rounded-[5px] flex-1 outline-blue-500' placeholder='What needs to be done?' />
      </div>
    </>
  )
}

export default function CreateIssuesComponent({ createWhat }) {
  const [show, setShow] = useState(false)

  const handleClick = () => {
    setShow(true)
  }

  return (
    <>
      <div id='wrap-create' className='w-full h-14 py-3 flex items-center cursor-pointer'>
        {show ? (<InputComponent setShow={setShow} />) : (<div onClick={handleClick} className='w-full h-full flex items-center'>
          <FontAwesomeIcon className='px-2' size='2x' icon={faCirclePlus} />
          <div className='pl-4'>Create {createWhat}</div>
        </div>)}
      </div>
    </>
  )
}
