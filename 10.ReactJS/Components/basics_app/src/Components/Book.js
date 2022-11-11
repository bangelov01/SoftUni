function Book(props) {
    if (!props.title) {
        return (
            <article>
                <h3>Book has no title!</h3>
            </article>
        );
    }

    return(
        <article>
            <h3 onClick={props.clickHandler}>{props.title}</h3>
            <p>{props.description}</p>
        </article>
    );
}

export default Book;