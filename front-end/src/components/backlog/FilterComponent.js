import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import React, { useState } from 'react'
import MemberComponent from './MemberComponent'
import { faUserPlus } from '@fortawesome/free-solid-svg-icons'

export default function FilterComponent() {
    const [star, setStar] = useState(true)
    const clickStar = () => {
        setStar(!star)
        //Click 1 lần đầu tiên star chưa là true ngay
        if (star) {
            document.getElementById('star').style.fill = 'gold'
        } else {
            document.getElementById('star').style.fill = '#9ca3af'
        }
    }
    return (
        <>
            <div className='action-filter flex justify-around items-center h-16 w-full my-4'>
                <div className='action flex-1 flex items-center'>
                    <div className="search-wrapper border-2 border-[#ccc] inline-flex justify-start items-center h-80% rounded mx-2">
                        <svg class="w-5 h-5 icon mx-2" viewBox="0 0 20 20" fill="#ccc"><path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd"></path></svg>
                        <input type="text" placeholder="Search" className='outline-none py-2 mx-1' />
                    </div>
                    <div className='mx-3'>
                        <MemberComponent />
                    </div>
                    <div className='add-member w-10 h-10 rounded-[50%] flex justify-center items-center bg-[#ccc] border-solid border-[#000] border-2 mx-2 cursor-pointer'>
                        <FontAwesomeIcon icon={faUserPlus} />
                    </div>
                    <div className='filter h-full flex justify-center items-center'>
                        <div className="custom-select h-full rounded-sm mx-2">
                            <select className='border-solid border-[#000] border-[1px] rounded-[4px] p-1'>
                                <option value="0">Select car:</option>
                                <option value="1">Audi</option>
                                <option value="2">BMW</option>
                            </select>
                        </div>
                        <div className="custom-select h-full rounded-sm mx-2">
                            <select className='border-solid border-[#000] border-[1px] rounded-[4px] p-1'>
                                <option value="0">Select car:</option>
                                <option value="1">Audi</option>
                                <option value="2">BMW</option>
                            </select>
                        </div>
                        <div className="clear-filter h-full mx-2 border-solid border-[#000] border-[1px] p-1 rounded-[4px] cursor-pointer">
                            Clear filter
                        </div>
                    </div>
                </div>
                <svg onClick={clickStar} id='star' className='fill-gray-400 px-4 cursor-pointer' viewBox="0 0 576 512" height="50%" title="star"> 
                    <path d="M259.3 17.8L194 150.2 47.9 171.5c-26.2 3.8-36.7 36.1-17.7 54.6l105.7 103-25 145.5c-4.5 26.3 23.2 46 46.4 33.7L288 439.6l130.7 68.7c23.2 12.2 50.9-7.4 46.4-33.7l-25-145.5 105.7-103c19-18.5 8.5-50.8-17.7-54.6L382 150.2 316.7 17.8c-11.7-23.6-45.6-23.9-57.4 0z" />
                </svg>
            </div>
        </>
    )
}
