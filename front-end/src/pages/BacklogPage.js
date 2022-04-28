import React from 'react'
import Sidebar from '../components/sidebar/Sidebar'

function BacklogPage() {
  return (
    <div className="flex">
      <div className='basis-[20%]'>
        <Sidebar></Sidebar>
      </div>
      <div className='basis-[80%]'>
        backlog
      </div>
      </div>
  )
}

export default BacklogPage