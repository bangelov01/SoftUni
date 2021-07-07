async function attachEvents() {
    
    const baseUrl = `http://localhost:3030/jsonstore/blog/`;

    const posts = await getPosts(baseUrl);

    let postsElement = document.getElementById(`posts`);

    const buttonView = document.getElementById(`btnViewPost`);

    Object.values(posts).forEach(post => {
        let option = document.createElement(`option`);
        option.value = post.id;
        option.textContent = post.title.toUpperCase();

        postsElement.appendChild(option);
    })

    buttonView.addEventListener(`click`, async (e) => {

        const neededId = e.target.previousElementSibling.value;

        const [post, comments] = await Promise.all(
            [fetch(baseUrl + `posts/${neededId}`),
             fetch(baseUrl + `comments`)]
        )

        const neededPost = await post.json();

        document.getElementById(`post-title`).textContent = neededPost.title.toUpperCase();
        document.getElementById(`post-body`).textContent = neededPost.body;

        const neededComments = await comments.json();

        const commentObjects = Object.values(neededComments).filter(el => el.postId == neededId);

        let postCommentsElement = document.getElementById(`post-comments`);
        postCommentsElement.innerHTML = ``;

        commentObjects.forEach(comment => {
            let li = document.createElement(`li`);
            li.textContent = comment.text;
            postCommentsElement.appendChild(li);
        })
    })

    async function getPosts(baseUrl) {

        const response = await fetch(baseUrl + `posts`);
        const data = await response.json();

        return data;
    }
}

attachEvents();