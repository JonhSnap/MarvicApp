import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCirclePlus } from '@fortawesome/free-solid-svg-icons'

export default function CreateIssuesComponent({createWhat}) {
  return (
    <>
      <div className='w-full h-14 px-3 flex items-center cursor-pointer'>
        <FontAwesomeIcon size='2x' icon={faCirclePlus} />
        <div className='pl-4'>Create {createWhat}</div>
      </div>
    </>
  )
}
