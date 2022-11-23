import style from './Header.module.css'

const Header = () => {
    return (
        <nav className={style.navigation}>
        <ul>
          <li className="listItem"><img src="\white-origami-bird.png" height="50" width="50"></img></li>
          <li className="listItem"><a href="#">Going To 1</a></li>
          <li className="listItem"><a href="#">Going To 2</a></li>
          <li className="listItem"><a href="#">Going To 3</a></li>
          <li className="listItem"><a href="#">Going To 4</a></li>
          <li className="listItem"><a href="#">Going To 5</a></li>
          <li className="listItem"><a href="#">Going To 6</a></li>
          <li className="listItem"><a href="#">Going To 7</a></li>
          <li className="listItem"><a href="#">Going To 8</a></li>
          <li className="listItem"><a href="#">Going To 9</a></li>
          <li className="listItem"><a href="#">Going To 10</a></li>
          <li className="listItem"><a href="#">Going To 11</a></li>
        </ul>
      </nav>
    );
}

export default Header;