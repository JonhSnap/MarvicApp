import React from 'react'
import SelectBoxBase from './SelectBoxBase'
import CreateComponent from '../CreateComponent'

function FilterEpicBoardSelectBox({ onClose, bodyStyle, epics, issueEpics, project, handleChooseEpic }) {
    return (
        <SelectBoxBase
            onClose={onClose}
            bodyStyle={bodyStyle}
        >
            <div
                className='epic-dropdown have-y-scroll px-4 w-[200px] h-[200px] overflow-y-auto
                mx-4 bg-white rounded-[5px] flex flex-col gap-y-2 shadow-lg shadow-epic-color'>
                <div className='flex justify-between w-full py-2'>
                    <span className='font-bold text-lg text-[#8777D9]'>Epic</span>
                </div>
                <div
                    onClick={() => handleChooseEpic('issues without epic')}
                    className='flex items-center gap-x-2'>
                    <input
                        className='cursor-pointer'
                        id='none-epic'
                        checked={epics.includes('issues without epic')}
                        type="checkbox"
                        readOnly
                    />
                    <label className='text-base font-semibold' htmlFor="none-epic">Issues without epic</label>
                </div>
                {
                    issueEpics.length > 0 &&
                    issueEpics.map(item => (
                        <div
                            key={item.id}
                            onClick={() => handleChooseEpic(item.id)}
                            className='flex items-center gap-x-2'>
                            <input
                                className='cursor-pointer'
                                id={item.id}
                                checked={epics.includes(item.id)}
                                readOnly
                                type="checkbox"
                            />
                            <label className='text-base font-semibold' htmlFor={item.id}>{item.summary}</label>
                        </div>
                    ))
                }
                <CreateComponent idIssueType={1} project={project} createWhat={"epic"} />
            </div>
        </SelectBoxBase>
    )
}

export default FilterEpicBoardSelectBox