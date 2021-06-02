function editElement(reference, match, replacer) {
    
    let elementsToChange = reference.textContent;
    let matcher = new RegExp(match,`g`);
    let edited = elementsToChange.replace(matcher, replacer);
    reference.textContent = edited;
}