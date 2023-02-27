import React from 'react';
import Search from './Search';
import { Link } from 'react-router-dom';

const Header = () => {
  return (
    <nav className='flex justify-between mx-auto max-w-screen-lg w-full items-center h-[50px] px-5'>
      <Link to="/">
        <div className="flex items-center">
          <img className="mr-5" src="/santa-hat.png" alt="logo" />
          <h1 className="font-sans font-bold text-xl text-neutral-700">THE Secret Santa</h1>
        </div>
      </Link>
        <Search/>
    </nav>
  )
}

export default Header