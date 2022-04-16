import React from 'react'
import ModalBase from '../modal/ModalBase'
import { useForm } from 'react-hook-form'
import { yupResolver } from '@hookform/resolvers/yup'
import * as yup from 'yup'
import Button from '../button/Button';

const schema = yup.object({
  name: yup.string().required('Name is required'),
  key: yup.string().required('Key is required'),
  level: yup.string().required('Level is required')
})

function CreateProjectPopup({ onClose, setIsShowProjectPopup }) {
  const { register, handleSubmit, formState: { errors }} = useForm({
    resolver: yupResolver(schema)
  });
  console.log('errors ~ ', errors);

  // on submit
  const onSubmit = (data) => {
    console.log(data);
  }

  return (
    <ModalBase
    containerclassName='fixed inset-0 z-10 flex items-center justify-center'
    bodyClassname='relative content-modal'
    onClose={onClose}
    >
        <div className='relative w-[95vw] max-w-[600px] bg-white rounded p-10 shadow-md select-none'>
            <div onClick={() => setIsShowProjectPopup(false)} className="absolute top-0 right-0 p-2 cursor-pointer rounded-full hover:bg-primary hover:bg-opacity-30 transition-all">
            <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="#666" strokeWidth={2}>
            <path strokeLinecap="round" strokeLinejoin="round" d="M6 18L18 6M6 6l12 12" />
            </svg>
            </div>
            <h2 className='text-[25px] text-primary text-center font-semibold mb-10'>Create Project</h2>
            <form
            className='w-full'
            onSubmit={handleSubmit(onSubmit)}>
              <div className='flex flex-col items-start gap-y-2 mb-5'>
                <label className='font-semibold cursor-pointer' htmlFor="name">
                  <span className='opacity-80'>Name</span>
                  <sup className='text-red-500'>*</sup>
                </label>
                <input
                {...register('name')}
                className='w-full p-2 outline-none border-2 border-[#ccc]
                rounded focus:border-primary focus:border-opacity-60 transition-all'
                placeholder="Enter project's name"
                autoComplete='off'
                id='name'
                type="text" />
                <span className='text-[10px] text-red-500 italic'>{errors?.name?.message}</span>
              </div>
              <div className='flex flex-col items-start gap-y-2 mb-5'>
                <label className='font-semibold cursor-pointer' htmlFor="access">
                  <span className='opacity-80'>Access</span>
                  <sup className='text-red-500'>*</sup>
                </label>
                <select
                {...register('level')}
                className='w-full p-2 outline-none border-2 border-[#ccc]
                rounded focus:border-primary focus:border-opacity-60 transition-all'
                autoComplete='off'
                id='access'
                >
                  <option value="">Choose an access level</option>
                  <option value="team">Team</option>
                </select>
                <span className='text-[10px] text-red-500 italic'>{errors?.level?.message}</span>
              </div>
              <div className='flex flex-col items-start gap-y-2 mb-10'>
                <label className='font-semibold cursor-pointer' htmlFor="key">
                  <span className='opacity-80'>Key</span>
                  <sup className='text-red-500'>*</sup>
                </label>
                <input
                {...register('key')}
                className='w-full max-w-[30%] p-2 outline-none border-2 border-[#ccc]
                rounded focus:border-primary focus:border-opacity-60 transition-all'
                autoComplete='off'
                id='key'
                type="text" />
                <span className='text-[10px] text-red-500 italic'>{errors?.key?.message}</span>
              </div>
              <div className='w-full flex justify-end gap-x-2'>
                <Button handleClick={() => setIsShowProjectPopup(false)} primary={false}>Cancel</Button>
                <Button type='submit'>Create</Button>
            </div>
            </form>         
        </div>
    </ModalBase>
  )
}

export default CreateProjectPopup