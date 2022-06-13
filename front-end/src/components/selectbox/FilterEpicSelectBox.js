import React from 'react'
import SelectBoxBase from './SelectBoxBase'
import CreateComponent from '../CreateComponent'
import EditIssuePopup from '../popup/EditIssuePopup'
import useModal from '../../hooks/useModal';
import { useMembersContext } from '../../contexts/membersContext';

function FilterEpicSelectBox({ onClose, bodyStyle, epics, issueEpics, project, handleChooseEpic }) {

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
                        <EpicItem key={item.id} project={project} epics={epics} epic={item} handleChooseEpic={handleChooseEpic} />
                    ))
                }
                <CreateComponent idIssueType={1} project={project} createWhat={"epic"} />
            </div>
        </SelectBoxBase>
    )
}

export default FilterEpicSelectBox

function EpicItem({ project, epics, epic, handleChooseEpic }) {
    const [show, setShow] = useModal();
    const { state: { members }
    } = useMembersContext();

    return (
        <>
            {
                show && <EditIssuePopup members={members} project={project} issue={epic} setShow={setShow} />
            }
            <div
                onClick={() => handleChooseEpic(epic.id)}
                className='flex items-center gap-x-2'>
                <input
                    className='cursor-pointer border-gray-500'
                    id={epic.id}
                    checked={epics.includes(epic.id)}
                    readOnly
                    type="checkbox"
                />
                <label
                    onClick={() => setShow(true)}
                    className='text-base font-semibold hover:underline hover:text-epic-color cursor-pointer'
                    htmlFor={epic.id}>{epic.summary}</label>
            </div>
        </>
    )
}