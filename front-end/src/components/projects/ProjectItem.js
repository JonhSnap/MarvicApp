import React from 'react'
import { useNavigate } from 'react-router-dom'

function ProjectItem({ project }) {
    const navigate = useNavigate();
    const handleClickName = (key) => {
        navigate(`/projects/${key}`);
    }
    
  return (
    <div className="item flex py-[8px] hover:bg-gray-main">
        <div className='basis-[5%] flex items-center justify-center'>
            <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="#ccc" strokeWidth={2}>
            <path strokeLinecap="round" strokeLinejoin="round" d="M11.049 2.927c.3-.921 1.603-.921 1.902 0l1.519 4.674a1 1 0 00.95.69h4.915c.969 0 1.371 1.24.588 1.81l-3.976 2.888a1 1 0 00-.363 1.118l1.518 4.674c.3.922-.755 1.688-1.538 1.118l-3.976-2.888a1 1 0 00-1.176 0l-3.976 2.888c-.783.57-1.838-.197-1.538-1.118l1.518-4.674a1 1 0 00-.363-1.118l-3.976-2.888c-.784-.57-.38-1.81.588-1.81h4.914a1 1 0 00.951-.69l1.519-4.674z" />
            </svg>
        </div>
        <div className='basis-[25%] flex items-center gap-x-3'>
            <img
            className='w-6 h-6 object-cover rounded-sm'
            src="https://images.unsplash.com/photo-1562577309-4932fdd64cd1?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8ZGlnaXRhbCUyMG1hcmtldGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" alt="" />
            <span onClick={() => handleClickName(project.key)} className='text-primary cursor-pointer hover:underline'>{project.name}</span>
        </div>
        <div className='basis-[20%]'>
            <span>{project.key}</span>
        </div>
        <div className='basis-[25%]'>
            <span>Type-of-project</span>
        </div>
        <div className='basis-[25%] flex items-center gap-x-3'>
            <img
            className='w-6 h-6 object-cover rounded-full'
            src="https://images.unsplash.com/photo-1562577309-4932fdd64cd1?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8ZGlnaXRhbCUyMG1hcmtldGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" alt="" />
            <span className='text-primary'>Lead of project</span>
        </div>
    </div>
  )
}

export default ProjectItem