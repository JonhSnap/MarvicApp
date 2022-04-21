import React, { useEffect } from 'react'
import { useSelector } from 'react-redux';
import { Outlet, useNavigate } from 'react-router-dom'
import Header from '../header/Header'

function Main() {
  const navigate = useNavigate();
  const { currentUser } = useSelector(state => state.auth.login);
  useEffect(() => {
    if(!currentUser) {
      navigate('/login');
      return
    }
  }, [])
  if(currentUser === null) return null
  return (
    <>
        <Header></Header>
        <Outlet></Outlet>
    </>
  )
}

export default Main