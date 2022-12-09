
const Main = ({
    posts
}) => {
    return (
        <main className="Main">
            <h1>Some Heading</h1>
            {posts.map(p => <p key={p.id}>{p.title}</p>)}
        </main>
    );
}

export default Main;