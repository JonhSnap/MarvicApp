import React, { useEffect, useRef, useState } from 'react'
import Button from '../components/button/Button'
import CreateProjectPopup from '../components/popup/CreateProjectPopup';
import ListProject from '../components/projects/ListProject';
import useModal from '../hooks/useModal';
import { getProjects } from '../redux/apiRequest';
import { useSelector, useDispatch } from 'react-redux'
import { changeFilters } from '../redux/projectsSlice';

function ProjectsPage() {
  const timerRef = useRef();
  const dispatch = useDispatch();
  const [search, setSearch] = useState('');
  const { projects, error } = useSelector(state => state.projects);
  const { currentUser } = useSelector(state => state.auth.login);
  const [isShowProjectPopup, setIsShowProjectPopup, handleCloseProjectPopup] = useModal();
  const inputRef = useRef();
  const [isFocusInput, setIsFocusInput] = useState(false);


  useEffect(() => {
    timerRef.current = setTimeout(() => {
      dispatch(changeFilters({ name: search }))
      getProjects(dispatch, currentUser.id);
    }, 1000);
    return () => clearTimeout(timerRef.current)
  }, [search])
  useEffect(() => {
    document.title = 'Marvic-Projects'
    const inputRefCopy = inputRef.current;
    const handleFoucs = e => {
      setIsFocusInput(true);
    }
    const handleBlur = e => {
      setIsFocusInput(false);
    }
    inputRefCopy.addEventListener('focus', handleFoucs);
    inputRefCopy.addEventListener('blur', handleBlur);
    return () => {
      inputRefCopy.removeEventListener('focus', handleFoucs);
      inputRefCopy.removeEventListener('blur', handleBlur);
    }
  }, [])

  return (
    <div className='w-[100vw] flex justify-center'>
      <div className="projects-wrapper w-[1320px] h-10">
        <div className="projects-top p-5 flex justify-between">
          <div className="projects-top-left flex flex-col gap-y-[30px]">
            <h2 className='text-3xl font-semibold'>Projects</h2>
            <div className={`flex items-center search-wrapper border-2 ${isFocusInput ? 'border-primary' : 'border-[#ccc]'} rounded-[4px] pr-1 transition-all`}>
              <input
                value={search}
                onChange={e => setSearch(e.target.value)}
                ref={inputRef}
                className='w-[200px] p-[5px] rounded-[4px] outline-none border-none'
                type="text"
                placeholder='Search project'
              />
              <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" viewBox="0 0 20 20" fill="#ccc">
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
            error ? <p className='text-center text-3xl opacity-50 py-10 text-red-500'>Error when get projects</p> :
              (projects.length === 0 ?
                <p className='text-center text-3xl opacity-50 py-10'>You don't have any projects yet</p> :
                <ListProject></ListProject>)
          }
        </div>
      </div>
    </div>
  )
}

export default ProjectsPage