import React from 'react'
import SelectBoxBase from './SelectBoxBase'
import CreateComponent from '../CreateComponent'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faAngleRight } from '@fortawesome/free-solid-svg-icons';
import { v4, NIL } from 'uuid';

function FilterEpicSelectBox({ onClose, bodyStyle, epics, issueEpics, project, handleChooseEpic }) {
    return (
        <SelectBoxBase
            onClose={onClose}
            bodyStyle={bodyStyle}
        >
            <div
                className='epic-dropdown have-y-scroll p-2 w-[300px] h-[200px] overflow-y-auto
                mx-4 bg-white rounded-[5px] flex items-center flex-col shadow-lg shadow-epic-color'>
                <div className='flex justify-between w-full px-4 py-2'>
                    <span className='font-bold text-lg text-[#8777D9]'>Epic</span>
                </div>
                <div
                    onClick={() => handleChooseEpic('issues without epic')}
                    className={`w-full p-3 mb-2 flex items-center font-semibold cursor-pointer
                            shadow-md rounded-[5px] ${epics.includes('issues without epic') ? 'bg-[#8777D9] text-white' : 'bg-white'}`}>
                    issues without epic
                </div>
                <div>
                    <input
                        id='none-epic'
                        checked={epics.includes('issues without epic')}
                        type="checkbox"
                    />
                    <label htmlFor="none-epic">Issues without epic</label>
                </div>
                {
                    issueEpics.length > 0 &&
                    issueEpics.map(item => (
                        <div
                            key={v4()}
                            onClick={() => handleChooseEpic(item.id)}
                            className={`w-full p-3 flex flex-col font-semibold shadow-md rounded-[5px] mb-2 cursor-pointer
                                ${epics.includes(item.id) ? 'bg-[#8777D9] text-white' : 'bg-white'}`}>
                            <div className='flex items-center'>
                                <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={faAngleRight} />
                                <div className='h-5 w-5 inline-block bg-[#d0c6ff] rounded-[5px] mx-2'></div>
                                {item.summary}
                            </div>
                            <div className='h-2 w-full bg-[#ddd] rounded-[5px] my-2 relative'>
                                <div className='absolute top-0 left-0  bottom-0 bg-blue-600 rounded-[10px]' style={{ width: "40%" }}>
                                </div>
                            </div>
                        </div>
                    ))
                }
                <CreateComponent idIssueType={1} project={project} createWhat={"epic"} />
            </div>
        </SelectBoxBase>
    )
}

export default FilterEpicSelectBox