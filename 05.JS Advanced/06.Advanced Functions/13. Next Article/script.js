function getArticleGenerator(articles) {
    
    let result = articles;
    return () => {
        let sentance = result.shift();
        if (sentance !== undefined) {
            let article = document.createElement("article");
            article.textContent += sentance;
            document.querySelector(`#content`).appendChild(article);
        }
    }
}
