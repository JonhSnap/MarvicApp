import axios from 'axios';
import React from 'react'
import { useNavigate } from 'react-router-dom'
import { BASE_URL } from '../../util/constants';
import { useDispatch, useSelector } from 'react-redux'
import { getProjects } from '../../redux/apiRequest';

function ProjectItem({ project }) {
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const { currentUser } = useSelector(state => state.auth.login);
    const handleClickName = (key) => {
        navigate(`/projects/${key}`);
    }
    const handleClickStar = () => {
        const postData = async() => {
            let dataPost = {};
            if(project.isStared === 0) {
                dataPost = {
                    "id": project.id,
                    "name": project.name,
                    "key": project.key,
                    "access": project.access,
                    "id_Lead": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    "dateStarted": project.dateStarted,
                    "dateEnd": project.dateEnd,
                    "isStared": 1,
                    "id_Updator": currentUser.id,
                    "updateDate": new Date()
                }
            }else {
                dataPost = {
                    "id": project.id,
                    "name": project.name,
                    "key": project.key,
                    "access": project.access,
                    "id_Lead": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    "dateStarted": project.dateStarted,
                    "dateEnd": project.dateEnd,
                    "isStared": 0,
                    "id_Updator": currentUser.id,
                    "updateDate": new Date()
                }
            }
            console.log(dataPost);
            const resp = await axios.post(`${BASE_URL}/api/Project/Update`, dataPost)
            getProjects(dispatch);
            console.log('resp ~ ', resp);
        }
        postData();
    }
    
  return (
    <div className="item flex py-[8px] hover:bg-gray-main">
        <div className='basis-[5%] flex items-center justify-center'>
            {
                project.isStared ?
                <svg onClick={handleClickStar} xmlns="http://www.w3.org/2000/svg" className="h-6 w-6 cursor-pointer" viewBox="0 0 20 20" fill="yellow">
                <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
                </svg> :
                <svg onClick={handleClickStar} xmlns="http://www.w3.org/2000/svg" className="h-5 w-5 cursor-pointer" fill="none" viewBox="0 0 24 24" stroke="#ccc" strokeWidth={2}>
                <path strokeLinecap="round" strokeLinejoin="round" d="M11.049 2.927c.3-.921 1.603-.921 1.902 0l1.519 4.674a1 1 0 00.95.69h4.915c.969 0 1.371 1.24.588 1.81l-3.976 2.888a1 1 0 00-.363 1.118l1.518 4.674c.3.922-.755 1.688-1.538 1.118l-3.976-2.888a1 1 0 00-1.176 0l-3.976 2.888c-.783.57-1.838-.197-1.538-1.118l1.518-4.674a1 1 0 00-.363-1.118l-3.976-2.888c-.784-.57-.38-1.81.588-1.81h4.914a1 1 0 00.951-.69l1.519-4.674z" />
                </svg>
            }
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