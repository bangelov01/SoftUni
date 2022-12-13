import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom'

import style from './NavigationItem.module.css'

const NavigationItem = ({location, children}) => {
    const [state, setState] = useState("")
    useEffect(() => setState(location), [])
    return (
        <li className="listItem">
            <Link to={state} className={style.navListItem}>{children}</Link>
        </li>
    );
}

export default NavigationItem;