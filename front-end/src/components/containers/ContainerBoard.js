import axios from 'axios';
import React, { useEffect, useRef, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import useModal from '../../hooks/useModal';
import { getProjects } from '../../redux/apiRequest';
import { BASE_URL } from '../../util/constants';
import AddMemberPopup from '../popup/AddMemberPopup';
import './ContainerBoard.scss'

function ContainerBoard({ project }) {
    const { currentUser } = useSelector(state => state.auth.login);
    const dispatch = useDispatch();
    const [show, setShow, handleClose] = useModal();
    const [focus, setFocus] = useState(false);
    const inputRef= useRef();

    const handleFocus = () => {
        setFocus(true);
    }
    const handleBlur = () => {
        setFocus(false);
    }
    // handle click star
    const handleClickStar = () => {
        const putData = async() => {
            const dataPut ={
                id: project.id,
                name: project.name,
                key: project.key,
                access: project.access,
                dateEnd: project.dateEnd,
                dateStarted: project.dateStarted,
                isStared: project.isStared,
                id_Lead: currentUser.id,
                id_Updator: currentUser.id,
                updateDate: new Date()
            }
            if(project.isStared === 0) {
                dataPut.isStared = 1;
            }else {
                dataPut.isStared = 0;
            }
            console.log(dataPut);
            const resp = await axios.put(`${BASE_URL}/api/Project/Update`, dataPut)
            getProjects(dispatch);
            console.log('resp ~ ', resp);
        }
        putData();
    }

    useEffect(() => {
        const inputEl = inputRef.current;
        inputEl.addEventListener('focus', handleFocus);
        inputEl.addEventListener('blur', handleBlur);

        return () => {
            inputEl.removeEventListener('focus', handleFocus);
            inputEl.removeEventListener('blur', handleBlur);
        }
    }, [])

    const handleClickAdd = () => {
        setShow(true);
    }

  return (
    <div className='container'>
        <div className="top">
            { show && <AddMemberPopup project={project} setShow={setShow} onClose={handleClose}></AddMemberPopup>}
            <div className="navigate">
                <span>Projects</span>
                <span>/</span>
                <span>{project.name}</span>
            </div>
            <div className="wrap-key">
                <h3 className="key">{project.key} board</h3>
                {
                    project.isStared ?
                    <svg onClick={handleClickStar} xmlns="http://www.w3.org/2000/svg" className="h-8 w-8 cursor-pointer" viewBox="0 0 20 20" fill='yellow'>
                    <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
                    </svg>
                    :
                    <svg onClick={handleClickStar} xmlns="http://www.w3.org/2000/svg" className="h-8 w-8 cursor-pointer" fill="none" viewBox="0 0 24 24" stroke="#ccc" strokeWidth={2}>
                    <path strokeLinecap="round" strokeLinejoin="round" d="M11.049 2.927c.3-.921 1.603-.921 1.902 0l1.519 4.674a1 1 0 00.95.69h4.915c.969 0 1.371 1.24.588 1.81l-3.976 2.888a1 1 0 00-.363 1.118l1.518 4.674c.3.922-.755 1.688-1.538 1.118l-3.976-2.888a1 1 0 00-1.176 0l-3.976 2.888c-.783.57-1.838-.197-1.538-1.118l1.518-4.674a1 1 0 00-.363-1.118l-3.976-2.888c-.784-.57-.38-1.81.588-1.81h4.914a1 1 0 00.951-.69l1.519-4.674z" />
                    </svg>
                }
            </div>
            <div className="actions">
                <div className={`wrap-input ${focus ? 'expand' : ''}`}>
                    <input
                    placeholder={focus ? 'Search this board' : ''}
                    ref={inputRef} type="text" />
                    <svg xmlns="http://www.w3.org/2000/svg" className="icon" viewBox="0 0 20 20" fill="#ccc">
                    <path fillRule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clipRule="evenodd" />
                    </svg>
                </div>
                <div className="members">
                    <div className="avatar">
                        <img src="https://images.unsplash.com/photo-1644982647708-0b2cc3d910b7?ixlib=rb-1.2.1&ixid=MnwxMjA3fDF8MHxlZGl0b3JpYWwtZmVlZHwxfHx8ZW58MHx8fHw%3D&auto=format&fit=crop&w=500&q=60" alt="" />
                    </div>
                    <div onClick={handleClickAdd} className="add-member">
                    <svg xmlns="http://www.w3.org/2000/svg" className="icon" fill="none" viewBox="0 0 24 24" stroke="#999" strokeWidth={2}>
                    <path strokeLinecap="round" strokeLinejoin="round" d="M18 9v3m0 0v3m0-3h3m-3 0h-3m-2-5a4 4 0 11-8 0 4 4 0 018 0zM3 20a6 6 0 0112 0v1H3v-1z" />
                    </svg>
                    </div>
                </div>
            </div>
        </div>
        <div className="bottom">

        </div>
    </div>
  )
}

export default ContainerBoard