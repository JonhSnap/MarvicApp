import React, { useState } from 'react'
import Header from '../components/header/Header'
import '../../src/index.scss'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCirclePlus } from '@fortawesome/free-solid-svg-icons'
import StageComponent from '../components/backlog/StageComponent'
import FilterComponent from '../components/backlog/FilterComponent'

export default function Backlog() {
    return (
        <>
            <Header />
            <div id='wrap-backlog' className='h-screen m-3'>
                <div className='project-name block text-5xl py-4'>
                    Tên project
                </div>
                <FilterComponent />
                <div className='main-backlog h-fit w-auto flex flex-row flex-nowrap overflow-auto min-h-[40rem] py-10'>
                    <StageComponent />
                    <StageComponent />
                    <StageComponent />
                    <StageComponent />
                    <StageComponent />
                    <StageComponent />
                    <StageComponent />
                    <div className='w-14 h-14 block '>
                        <FontAwesomeIcon size='3x' icon={faCirclePlus} />
                    </div>
                </div>
            </div>
        </>
    )
}
