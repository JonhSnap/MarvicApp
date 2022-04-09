import React, { useEffect, useState } from 'react'
import '../scss/Tutorial.scss'
import { motion } from "framer-motion";
import Data from '../tutorial/data-tutorial.json'

export default function TutorialPage() {
  const [show, setShow] = useState(true)
  const [count, setCount] = useState(1)
  // let count = 1;


  const hiddenTutorial = () => {
    document.querySelector('.tutorial').style.display = 'none';
  }

  const toggleBtn = (e) => {
    setShow(v => !v)
    setTimeout(() => setShow(v => !v), 200)
    if (e.target.innerHTML == "Next") {
      setCount(count => count + 1)
      if (count != Data.posts.length - 1) {
        document.querySelector('.btn-previous').style.pointerEvents = "auto";
        document.querySelector('.btn-previous').style.cursor = "pointer";
      }
      else {
        document.querySelector('.btn-next').style.pointerEvents = "none";
        document.querySelector('.btn-next').style.cursor = "auto";
      }
    } else {
      setCount(count => count - 1)
      if (count != 2) {
        document.querySelector('.btn-next').style.pointerEvents = "auto";
        document.querySelector('.btn-next').style.cursor = "pointer";
      }
      else {
        document.querySelector('.btn-previous').style.pointerEvents = "none";
        document.querySelector('.btn-previous').style.cursor = "auto";
      }
    }
  }




  return (
    <div className='tutorial'>

      {show && <motion.div className='content-1' initial={{ scale: 0 }}
        animate={{ rotate: 360, scale: 1 }}
        transition={{
          type: "spring",
          stiffness: 260,
          damping: 20
        }}>
        {Data.posts.map((post) => {
          let html = "";
          if (post.id == count) {
            html = <div className='content'>
              <div className='title-content'>
                {post.title1}
              </div><div className='main-content'>
                {post.content1}
              </div>
            </div>
          }
          return html
        })}
      </motion.div>}
      { <motion.div className='content-2' initial={{ scale: 0 }}
        animate={{ scale: 1 }}
        transition={{
          type: "spring",
          stiffness: 260,
          damping: 20
        }}>
        <div className='content2'>
          {Data.posts.map((post) => {
            let html = "";
            if (post.id == count) {
              html =
                <><div className='title-content'>
                  {post.title2}
                </div><div className='main-content'>
                    {post.content2}
                  </div></>

            }
            return html
          })}
          <div className='btn'>
            <button className='btn-previous' onClick={toggleBtn}>Previous</button>
            <button className='btn-next' onClick={toggleBtn}>Next</button>
            <button className='btn-skip' onClick={hiddenTutorial}>Skip</button>
          </div>
        </div>
      </motion.div>}
      <motion.div className='content-3' initial={{ scale: 0 }}
        animate={{ rotate: 360, scale: 1 }}
        transition={{
          type: "spring",
          stiffness: 260,
          damping: 20
        }}>
        <div className='circle-center'>
          Scrum
        </div>
        <div className='circle-1'>
          Commitment
        </div>
        <div className='circle-2'>
          Focus
        </div>
        <div className='circle-3'>
          Openness
        </div>
        <div className='circle-4'>
          Respect
        </div>
        <div className='circle-5'>
          Courage
        </div>
      </motion.div>
    </div>
  )
}
