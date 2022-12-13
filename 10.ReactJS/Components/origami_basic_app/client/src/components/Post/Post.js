const Post = ({
    content,
    author
}) => {
    return (
        <div className="Post">
            <p className="post-description">
                {content}
            </p>
            <div>
                <span>
                    <small>Author: </small> {author}
                </span>
            </div>
        </div>
    );
}

export default Post;