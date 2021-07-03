function loadRepos() {
	const username = document.getElementById(`username`).value;

	let url = `https://api.github.com/users/${username}/repos`;

	fetch(url)
	.then((response) => response.json())
	.then((data) => {
		const ulElement = document.getElementById(`repos`);
		ulElement.innerHTML = ``;
		data.forEach(repo => {
			const li = document.createElement(`li`);
			li.textContent = repo.full_name;
			ulElement.appendChild(li);
		})
	});
}