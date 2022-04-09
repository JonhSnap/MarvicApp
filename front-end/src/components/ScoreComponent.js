import React, { useState } from 'react'
import '../scss/Score.scss'

export default function ScoreComponent({showScore}) {
  return (
    <div className='score-main'>
        <div className='score'>
            <div className='score-title'>
                Điểm
            </div>
            <div className='score-num'>
                100
            </div>
            <button className='btn-ok' onClick={() => showScore(false)}>
                OK
            </button>
        </div>
    </div>
  )
}
