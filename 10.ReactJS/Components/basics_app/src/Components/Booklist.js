import Book from "./Book";

function Booklist(props) {

    function bookClicked(title) {
        console.log(`The book ${title} has been clicked!`)
    }


    return(
        <div className="book-list">
            {props.books.map(b => {
                return <Book key={b.id} title={b.title} description={b.description} clickHandler = {() => bookClicked(b.title)}/>;
            })}
        </div>
    );
}

export default Booklist;