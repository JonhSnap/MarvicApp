import React from 'react'
import { Outlet } from 'react-router-dom'
import Header from '../header/Header'

function Main() {
  return (
    <>
        <Header></Header>
        <Outlet></Outlet>
    </>
  )
}

export default Main