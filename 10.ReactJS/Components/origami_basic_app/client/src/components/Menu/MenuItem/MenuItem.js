const MenuItem = ({children}) => {
    return (
        <li className="listItem">
            <a href="#">{children}</a>
        </li>
    );
}

export default MenuItem;