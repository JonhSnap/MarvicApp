import React from 'react'
import '../scss/Tutorial.scss'

export default function TutorialPage() {
  const hiddenTutorial = () => {
    document.querySelector('.tutorial').style.display = 'none';
  }
  return (
    <div className='tutorial'>
      <div className='content-1'>
        <div className='content'>
          <div className='title-content'>
            MARVIC
          </div>
          <div className='main-content'>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
          </div>
        </div>
      </div>
      <div className='content-2'>
      <div className='content2'>
          <div className='title-content'>
          Welcome
          </div>
          <div className='main-content'>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
          </div>
          <div className='btn'>
            <button className='btn-previous'>Previous</button>
            <button className='btn-next'>Next</button>
            <button className='btn-skip' onClick={hiddenTutorial}>Skip</button>
          </div>
        </div>
      </div>
      <div className='content-3'>
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
      </div>
    </div>
  )
}
