import React from 'react'
import SelectBoxBase from './SelectBoxBase'

function FilterLabelSelectBox({ onClose, bodyStyle }) {
    return (
        <SelectBoxBase
            onClose={onClose}
            bodyStyle={bodyStyle}
        >
            <div className='bg-white shadow-md p-3 rounded flex flex-col'>
                <div className='flex items-center gap-x-2'>
                    <input type="checkbox" />
                    <span>Label</span>
                </div>
                <div className='flex items-center gap-x-2'>
                    <input type="checkbox" />
                    <span>Label</span>
                </div>
                <div className='flex items-center gap-x-2'>
                    <input type="checkbox" />
                    <span>Label</span>
                </div>
                <div className='min-w-[100px] mt-2 flex items-center gap-2'>
                    <span className='inline-block w-4 h-4'>
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                            <path fillRule="evenodd" d="M10 5a1 1 0 011 1v3h3a1 1 0 110 2h-3v3a1 1 0 11-2 0v-3H6a1 1 0 110-2h3V6a1 1 0 011-1z" clipRule="evenodd" />
                        </svg>
                    </span>
                    <p className='text-sm font-semibold'>Add label</p>
                </div>
            </div>
        </SelectBoxBase>
    )
}

export default FilterLabelSelectBox