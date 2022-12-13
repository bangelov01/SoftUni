import React, { useState, useEffect } from 'react';
import { Route, Routes, Link, NavLink, Redirect } from 'react-router-dom'

import Header from './components/Header';
import Menu from './components/Menu'
import Main from './components/Main'
import About from './components/About'
import Error from './components/Error'

import style from './App.module.css';

import * as postServices from './Services/postServices'

function App() {
  const [state, setState] = useState({
    posts: []
  })
  useEffect(() => {
    postServices.getAll().then(posts => setState({posts}));
  }, [])
  return (
    <div className={style.app}>
      <Header/>
      <div className="Container">
        <Menu/>
        <Routes>
          <Route path="/" element={<Main posts={state.posts}/>}/>
          <Route path="/about" element={<About/>}/>
          <Route path="/about/:company" element={<About/>}/>
          <Route path="*" element={<Error/>}/>
        </Routes>
      </div>
    </div>
  );
}

export default App;
