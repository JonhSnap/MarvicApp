import React, { useEffect, useState } from 'react'
import '../btn-next-prev/BtnNextPrev.scss'
import Data from '../../tutorial/data-tutorial.json'
import { boolean } from 'yup'

export default function BtnNextPrevComponent(props) {

    if (0 < parseInt(localStorage.getItem('count')) <= Data.posts.length) {
        localStorage.count = props.count
    }
    useEffect(() => {
        if (parseInt(localStorage.getItem('count')) == 1) {
            document.querySelector('.btn-previous').style.pointerEvents = "none";
            document.querySelector('.btn-previous').style.cursor = "auto";
        }

        if (parseInt(localStorage.getItem('count')) == Data.posts.length) {
            document.querySelector('.btn-next').style.pointerEvents = "none";
            document.querySelector('.btn-next').style.cursor = "auto";
        }
    }, [])

    const hiddenTutorial = () => {
        document.querySelector('.tutorial').style.display = 'none';
    }

    const toggleBtn = (e) => {

        props.setShow(v => !v)
        setTimeout(() => props.setShow(v => !v), 200)
        if (e.target.innerHTML == "Next") {
            props.setCount(count => count + 1)
            localStorage.btn = 'NEXT'
        } else {
            props.setCount(count => count - 1)
            localStorage.btn = 'PREV'
        }
    }
    return (
        <>
            <div className='btn'>
                <button className='btn-previous' onClick={toggleBtn}>Previous</button>
                <button className='btn-next' onClick={toggleBtn}>Next</button>
                <button className='btn-skip' onClick={hiddenTutorial}>Skip</button>
            </div>
        </>
    )
}
