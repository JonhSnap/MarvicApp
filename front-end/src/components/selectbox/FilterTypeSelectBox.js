import React from 'react'
import SelectBoxBase from './SelectBoxBase'

function FilterTypeSelectBox({ issueTypes, handleChooseType, type, onClose, bodyStyle }) {
    return (
        <SelectBoxBase
            onClose={onClose}
            bodyStyle={bodyStyle}
        >
            <div
                className='type-dropdown'>
                {
                    issueTypes.length > 0 &&
                    issueTypes.map(item => (
                        <div
                            key={item.id}
                            onClick={() => handleChooseType(item.value)}
                            className={`flex items-center gap-x-2 p-1 cursor-pointer rounded hover:bg-gray-300 mb-2 ${type.includes(item.value) ? 'bg-[#e2e2e2]' : 'bg-white'}`}>
                            <div className="w-5 h-5">
                                <img className='block w-full h-full object-cover rounded-md' src={item.thumbnail} alt="" />
                            </div>
                            <span className='inline-block'>{item.title}</span>
                        </div>
                    ))
                }
            </div>
        </SelectBoxBase>
    )
}

export default FilterTypeSelectBox