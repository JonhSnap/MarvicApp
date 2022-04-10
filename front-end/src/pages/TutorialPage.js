import React, { useEffect, useState } from 'react'
import '../scss/Tutorial.scss'
import { motion } from "framer-motion";
import Data from '../tutorial/data-tutorial.json'
import BtnNextPrevComponent from '../components/btn-next-prev/BtnNextPrevComponent';

export default function TutorialPage() {
  const [show, setShow] = useState(true)
  const [count, setCount] = useState(1)



  return (
    <div className='tutorial'>

      {show && <motion.div className='content-1' transition={{
        type: "spring",
        damping: 10,
        stiffness: 100
      }} animate={{ scale: 1.1 }}>
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
      {show && <motion.div className='content-2'  transition={{
        type: "spring",
        damping: 10,
        stiffness: 100
      }} animate={{ scale: 1.1 }}>
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
          <BtnNextPrevComponent setShow={setShow} setCount={setCount} count={count} />
        </div>
      </motion.div>}
      {show && <motion.div className='content-3' initial={{ scale: 0 }}
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
      </motion.div>}
    </div>
  )
}
