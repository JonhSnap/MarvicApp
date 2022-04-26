import React from 'react'
import FilterComponent from './FilterComponent'

export default function HeaderPlanComponent({ memberComponent, leftComponent }) {
    return (
        <>
            <div className='project-name block text-5xl py-4'>
                Tên project / Tên sprint
            </div>
            <div className='action-filter flex justify-around items-center h-16 w-full my-4'>
                <FilterComponent memberComponent={memberComponent} />
                {leftComponent}
            </div>
        </>
    )
}
