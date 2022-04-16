import React, { useEffect } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faAngleRight, faAngleLeft, faTimes } from '@fortawesome/free-solid-svg-icons'
import Data from '../../tutorial/data-tutorial.json'
import { data } from '../../tutorial/data-tutorial'

export default function BtnNextPrevComponent(props) {
    if (0 < parseInt(localStorage.getItem('count')) <= data.length) {
        localStorage.count = props.count
    }

    const hiddenTutorial = () => {
        document.querySelector('#wrap-tutorial').style.display = 'none';
    }

    const toggleBtn = (item) => {
        props.setShowAnimation(v => !v)
        props.setShow(v => !v)
        setTimeout(() => props.setShow(v => !v), -100)
        // console.log(e.target.value)
        if (item === 'next') {
            props.setCount(count => count + 1)
            if (parseInt(localStorage.getItem('count')) == data.length - 1) {
                document.querySelector('.btn-next').style.pointerEvents = "none";
                document.querySelector('.btn-next').style.cursor = "auto";
            } else {
                document.querySelector('.btn-prev').style.pointerEvents = "auto";
                document.querySelector('.btn-prev').style.cursor = "pointer";
            }
        } else {
            props.setCount(count => count - 1)
            if (parseInt(localStorage.getItem('count')) == 2) {
                document.querySelector('.btn-prev').style.pointerEvents = "none";
                document.querySelector('.btn-prev').style.cursor = "auto";
            } else {
                document.querySelector('.btn-next').style.pointerEvents = "auto";
                document.querySelector('.btn-next').style.cursor = "pointer";
            }
        }
    }
    return (
        <>
            <button className='btn-next' value={'next'} onClick={() => toggleBtn('next')} ><FontAwesomeIcon icon={faAngleRight} /></button>
            <button className='btn-prev' value={'prev'} onClick={() => toggleBtn('prev')}  ><FontAwesomeIcon icon={faAngleLeft} /></button>
            <button className='btn-skip' value={'skip'} onClick={hiddenTutorial}><FontAwesomeIcon size='4x' icon={faTimes} /></button>
        </>
    )
}
