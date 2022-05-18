import React, { memo } from 'react'
import { NIL } from 'uuid'
import SelectBoxBase from './SelectBoxBase'

function AssineeSelectBox({ issue, members, handleChooseAssignee, bodyStyle, onClose }) {
    return (
        <SelectBoxBase
            onClose={onClose}
            bodyStyle={bodyStyle}
        >
            <div className="bg-white flex flex-col w-[100px] shadow-lg rounded-md overflow-hidden">
                {
                    issue.id_Assignee && issue.id_Assignee !== NIL &&
                    <div onClick={() => handleChooseAssignee(null)} className='w-full cursor-pointer p-2 mb-1 bg-white hover:bg-gray-main'>Unassigneed</div>
                }
                {
                    members?.length > 0 &&
                    members.map(item => (
                        <div
                            key={item.id}
                            onClick={() => handleChooseAssignee(item.id)}
                            className={`w-full p-2 mb1 cursor-pointer bg-white hover:bg-gray-main ${item.id === issue.id_Assignee ? 'bg-orange-400 text-white pointer-events-none cursor-default' : ''}`}
                        >{item.userName}</div>
                    ))
                }
            </div>
        </SelectBoxBase>
    )
}

export default memo(AssineeSelectBox)