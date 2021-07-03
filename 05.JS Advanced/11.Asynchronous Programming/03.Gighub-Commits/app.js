function loadCommits() {
    const username = document.getElementById(`username`).value;
    const repository = document.getElementById(`repo`).value;

    let url = `https://api.github.com/repos/${username}/${repository}/commits`;
    const parent = document.getElementById(`commits`);

    fetch(url)
    .then((response) => {
        if (response.status !== 200) {
            throw new Error(`Error: ${response.status} (Not Found)`)
        }
        return response.json();
    })
    .then((data) => {
        parent.innerHTML = ``;
        data.forEach(r => {
            let li = document.createElement(`li`);
            li.textContent = `${r.commit.author.name}: ${r.commit.message}`;
            parent.appendChild(li);
        })
    })
    .catch((error) => {
        parent.innerHTML = ``;
        let li = document.createElement(`li`);
        li.textContent = error.message;
        parent.appendChild(li);
    })
}