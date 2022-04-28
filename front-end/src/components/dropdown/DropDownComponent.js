import React from 'react'
import $ from 'jquery';
import Select from 'react-select'
import taskImage from '../../images/type-issues/task.jpg'
import storyImage from '../../images/type-issues/story.jpg'
import bugImage from '../../images/type-issues/bug.jpg'

export default function DropDownComponent(props) {
    const options = [
        { value: '1', label: <div className='item-drop-down'><img className='pointer-events-none' src={storyImage} height="20px" width="20px" /></div> },
        { value: '2', label: <div className='item-drop-down'><img className='pointer-events-none' src={taskImage} height="20px" width="20px" /></div> },
        { value: '3', label: <div className='item-drop-down'><img className='pointer-events-none' src={bugImage} height="20px" width="20px" /></div> }
    ]

    return (
        <>
            <Select options={options}
                value={options.find(obj => obj.value === props.selectedValue)}
                onChange={props.handleChange}
                defaultValue={{ value: '1', label: <div className='item-drop-down pointer-events-none'><img src={storyImage} height="20px" width="20px" /></div> }} />
        </>
    )
}
