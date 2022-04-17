import React, { useState } from 'react'
import './Confirm.scss'

export default function ConfirmComponent({showConfirm, showScore}) {

  return (
    <div id="confirm">
      <div className='main-confirm'>
        <div className='title-confirm'>
          Bạn có chắc không?
        </div>
        <div className='btn-confirm'>
          <button className='yes-confirm' onClick={() => {
            showScore(true)
            showConfirm(false)
          }}>
            Có
          </button>
          <button className='no-confirm' onClick={() => showConfirm(false)}>
            Không
          </button>
        </div>
      </div>
    </div>
  )
}