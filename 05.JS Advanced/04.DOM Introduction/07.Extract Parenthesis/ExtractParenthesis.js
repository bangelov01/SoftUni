function extract(content) {

    let initialText = document.getElementById(content).textContent;
    let pattern = new RegExp(/[(][a-zA-z\s]+[)]/gm);
    let result = [];

    let match = pattern.exec(initialText);

    while (match) {
        result.push(match[0]);
        match = pattern.exec(initialText);
    }

    return result.join(`; `)
}