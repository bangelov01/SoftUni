class Story {
    #comments;
    #likes;
    constructor(title, creator, comments = [], likes = []){
        this.title = title;
        this.creator = creator;
        this.#comments = comments;
        this.#likes = likes;
    }

    get likes() {

        if (this.#likes.length == 0) {
            return `${this.title} has 0 likes`;
        }
        if (this.#likes.length == 1) {
            return `${this.#likes[0]} likes this story!`;
        }

        return `${this.#likes[0]} and ${this.#likes.length - 1} others like this story!`;
    }

    like(username) {
        
        if (this.#likes.includes(username)) {
            throw new Error("You can't like the same story twice!");
        }
        if (this.creator == username) {
            throw new Error("You can't like your own story!");
        }

        this.#likes.push(username);

        return `${username} liked ${this.title}!`;
    }

    dislike(username) {

        if (!this.#likes.includes(username)) {
            throw new Error("You can't dislike this story!");
        }

        this.#likes = this.#likes.filter(el => el !== username);

        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {

        let neededComment = this.#comments.filter(el => el.Id == id);

        if (neededComment.length == 0 || id === undefined) {
            let comment = {
                Id: this.#comments.length + 1,
                Username: username,
                Content: content,
                Replies: []
            };

            this.#comments.push(comment);

            return `${username} commented on ${this.title}`;
        }

        neededComment[0].Replies.push({
            Id: `${neededComment[0].Id}.${neededComment[0].Replies.length + 1}`,
            Username: username,
            Content: content
        })

        return "You replied successfully";
    }

    toString(sortingType) {

        if (sortingType == `asc`) {
            this.#comments.sort((a,b) => a.Id - b.Id);
            this.#comments.forEach(comment => {
                comment.Replies.sort((a,b) => a.Id - b.Id)
            })
        }
        else if (sortingType == `desc`) {
            this.#comments.sort((a,b) => b.Id - a.Id);
            this.#comments.forEach(comment => {
                comment.Replies.sort((a,b) => b.Id - a.Id)
            })
        }
        else if(sortingType == `username`) {
            this.#comments.sort((a,b) => a.Username.localeCompare(b.Username));
            this.#comments.forEach(comment => {
                comment.Replies.sort((a,b) => a.Username.localeCompare(b.Username));
            })
        }

        let result = ``;
        result += `Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this.#likes.length}\nComments:\n`;

        for (const comment of this.#comments) {
            
            result += `-- ${comment.Id}. ${comment.Username}: ${comment.Content}\n`;

            if (comment.Replies.length > 0) {
                
                for (const reply of comment.Replies) {
                    
                    result += `--- ${reply.Id}. ${reply.Username}: ${reply.Content}\n`;
                }
            }
        }

        return result.trim();
    }
}
