import React, { useState, useEffect } from 'react';

import Header from './components/Header';
import Menu from './components/Menu'
import Main from './components/Main'

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
        <Main posts={state.posts}/>
      </div>
    </div>
  );
}

export default App;
