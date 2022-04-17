import React, { useEffect, useRef, useState } from 'react'
import Button from '../button/Button';
import ModalBase from '../modal/ModalBase'

function AddMemberPopup({ onClose, setShow }) {
    const inputRef = useRef();
    // const [members, setMembers] = useState([]);
    const [focus, setFocus] = useState(false);
    useEffect(() => {
        const inputEl = inputRef.current;
        const handleFocus = () => {
            setFocus(true);
        }
        const handleBlur = () => {
            setFocus(false);
        }
        inputEl.addEventListener('focus', handleFocus);
        inputEl.addEventListener('blur', handleBlur);
        return () => {
            inputEl.removeEventListener('focus', handleFocus);
            inputEl.removeEventListener('blur', handleBlur);
        }
    }, [])

  return (
    <ModalBase
    containerclassName='fixed inset-0 flex justify-center'
    bodyClassname='relative z-10 mt-[100px]'
    onClose={onClose}
    >
        <form className='w-[500px] bg-white p-5 rounded'>
            <h3 className='text-[20px] text-black font-semibold'>Add people</h3>
            <div className={`flex items-center p-3 pr-0 border-2 ${focus ? 'border-primary bg-white' : 'border-[#ccc] bg-gray-main'}
            rounded mt-5 transition-all mb-5`}>
                <div className='grow flex flex-col gap-1 items-start'>
                <div className='flex items-center rounded text-[12px] bg-[#ccc]'>
                    <span className='grow inline-block px-3'>Vothang@gmail.com</span>
                    <span className='inline-block p-2 font-bold text-black cursor-pointer hover:bg-gray-main'>x</span>
                </div>
                <input
                    ref={inputRef}
                    className='w-full p-3 outline-none border-none bg-transparent'
                    placeholder='Enter name or email address'
                    type="text"
                    />
                </div>
                <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5 mr-2" viewBox="0 0 20 20" fill="#ccc">
                <path fillRule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clipRule="evenodd" />
                </svg>
            </div>
            <div className='flex gap-4 justify-end'>
                <Button handleClick={() => setShow(false)} primary={false}>Cancel</Button>
                <Button>Add</Button>
            </div>
        </form>
    </ModalBase>
  )
}

export default AddMemberPopup