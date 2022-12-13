import Post from '../Post'

const Main = ({
    posts
}) => {
    return (
        <main className="Main">
            <h1>Some Heading</h1>
            <div className="Posts">
                {posts.map(p => 
                <Post 
                    key={p.id}
                    content = {p.content}
                    author = {p.author}
                />)}
            </div>
        </main>
    );
}

export default Main;