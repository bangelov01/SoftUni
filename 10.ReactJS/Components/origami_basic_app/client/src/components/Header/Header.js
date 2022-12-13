import NavigationItem from './NavigationItem';
import style from './Header.module.css'

const Header = () => {
    return (
        <nav className={style.navigation}>
        <ul>
          <li className="listItem"><img src="\white-origami-bird.png" height="50" width="50"></img></li>
          <NavigationItem location={"/"}>Home</NavigationItem>
          <NavigationItem location={"/about"}>About Us</NavigationItem>
          <NavigationItem location={"/about/affiliates"}>About Our Affiliates</NavigationItem>
        </ul>
      </nav>
    );
}

export default Header;