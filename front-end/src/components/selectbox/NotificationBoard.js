import React from 'react'
import { v4 } from 'uuid'
import './NotificationBoard.scss'
import SelectBoxBase from './SelectBoxBase'

function NotificationBoard({ onClose, bodyStyle, notifyData }) {
    return (
        <SelectBoxBase
            onClose={onClose}
            bodyStyle={bodyStyle}
        >
            <div className="notification-wrapper">
                <div className="notification-board have-y-scroll">
                    {
                        Object.entries(notifyData).length > 0 ?
                            (
                                <div className='notification-list'>
                                    {
                                        notifyData.items.map(item => (
                                            <div key={v4()} className={`notification-item ${!item.isView ? 'unview' : ''}`}>
                                                <div className="left">
                                                    <span className='text'>{item.message}</span>
                                                    <span className='time'>10/10/2022</span>
                                                </div>
                                                <div className='dot-new'></div>
                                            </div>
                                        ))
                                    }
                                </div>
                            ) :
                            (
                                <p>You don't have any notification</p>
                            )
                    }
                </div>
            </div>
        </SelectBoxBase>
    )
}

export default NotificationBoard