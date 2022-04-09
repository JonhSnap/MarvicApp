import React, { useEffect, useState } from 'react'
import Button from '../components/button/Button'
import CreateProjectPopup from '../components/popup/CreateProjectPopup';
import ListProject from '../components/projects/ListProject';
import useModal from '../hooks/useModal';

function ProjectsPage() {
  const [isShowProjectPopup, setIsShowProjectPopup, handleCloseProjectPopup] = useModal();
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    const url = 'https://localhost:5001/api/Project/GetAlls';
    fetch(url)
    .then(resp => {
      return resp.json();
    })
    .then(data => {
      console.log('data ~ ', data);
    })
    .catch(err => console.log(err))
  }, [])

  return (
    <div className='w-[100vw] flex justify-center'>
      <div className="projects-wrapper w-[1320px] h-10">
        <div className="projects-top p-5 flex justify-between">
          <div className="projects-top-left flex flex-col gap-y-[30px]">
            <h2 className='text-3xl font-semibold'>Projects</h2>
            <div className="flex items-center search-wrapper border-2 border-gray-400 rounded-[4px] pr-1">
              <input
              className='w-[200px] p-[5px] rounded-[4px] outline-none border-none'
              type="text"
              placeholder='Search project'
              />
              <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
              <path fillRule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clipRule="evenodd" />
              </svg>
            </div>
          </div>
          <div className="projects-top-right">
            <Button handleClick={() => setIsShowProjectPopup(true)}>Create project</Button>
            {
              isShowProjectPopup && <CreateProjectPopup setIsShowProjectPopup={setIsShowProjectPopup} onClose={handleCloseProjectPopup} visible={isShowProjectPopup}></CreateProjectPopup>
            }
          </div>
        </div>
        <div className="projects-bottom">
          {
            projects.length === 0 ?
          <p className='text-center text-3xl opacity-50 py-10'>You don't have any projects yet</p> :
          <ListProject></ListProject>
          }
        </div>
      </div>
    </div>
  )
}

export default ProjectsPage