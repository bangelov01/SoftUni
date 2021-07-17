import {setupHomeCreatePost, showHomeCreatePost} from "../src/partialViews/homeCreatePost.js"
import {setupHomeCommentPosts, showHomeCommentPosts} from "../src/partialViews/homeComments.js"

let main;
let homeCreateSection;
let homeCommentsSection;

export function setupHome(mainTarget, sectionCreateTarget, sectionCommentsTarget) {

    main = mainTarget;
    homeCreateSection = sectionCreateTarget;
    homeCommentsSection = sectionCommentsTarget;

    setupHomeCreatePost(homeCreateSection);
    setupHomeCommentPosts(homeCommentsSection);
}

export async function showHome() {

        main.innerHTML = '';
        const homeCreatePostSect = showHomeCreatePost();
        const homeCommentsSect = await showHomeCommentPosts();

        main.appendChild(homeCreatePostSect);
        main.appendChild(homeCommentsSect);
}