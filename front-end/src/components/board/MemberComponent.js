import React from 'react'
import '../../../src/index.scss'
import avatar1 from '../../../src/images/avatar/avatar1.jpg'

export default function MemberComponent() {
    return (
        <>
            <div className='wrap-member flex min-w-[6rem] max-w-[100px] overflow-x-auto'>
                <div className='wrap-member-item w-6 h-10 inline-block cursor-pointer'>
                    <div style={{ backgroundImage: "url(" + avatar1 + ")" }} className="member-item w-10 h-full rounded-[50%] border-indigo-600 border-solid border-2 bg-cover bg-no-repeat bg-center">

                    </div>
                </div>
                <div className='wrap-member-item w-6 h-10 inline-block cursor-pointer'>
                    <div style={{ backgroundImage: "url(" + avatar1 + ")" }} className="member-item w-10 h-full rounded-[50%] border-indigo-600 border-solid border-2 bg-cover bg-no-repeat bg-center">

                    </div>
                </div>
                <div className='wrap-member-item w-6 h-10 inline-block cursor-pointer'>
                    <div style={{ backgroundImage: "url(" + avatar1 + ")" }} className="member-item w-10 h-full rounded-[50%] border-indigo-600 border-solid border-2 bg-cover bg-no-repeat bg-center">

                    </div>
                </div>
            </div>
        </>
    )
}
