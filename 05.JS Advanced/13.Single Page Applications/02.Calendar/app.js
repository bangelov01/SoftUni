const yearSelect = document.getElementById(`years`);

const monthNames = {
    "Jan": 1,
    "Feb": 2,
    "Mar": 3,
    "Apr": 4,
    "May": 5,
    "Jun": 6,
    "Jul": 7,
    "Aug": 8,
    "Sep": 9,
    "Oct": 10,
    "Nov": 11,
    "Dec": 12
}

const years = [...document.querySelectorAll(`.monthCalendar`)].reduce((acc,cur) => {
    acc[cur.id] = cur;
    return acc;
}, {});

const months = [...document.querySelectorAll(`.daysCalendar`)].reduce((acc,cur) => {
    acc[cur.id] = cur;
    return acc;
}, {});

displaySection(yearSelect);

yearSelect.addEventListener(`click`, (e) => {
    if (e.target.classList.contains(`date`) || e.target.classList.contains(`day`)) {
        e.stopImmediatePropagation();
        const yearId = `year-${e.target.textContent.trim()}`;
        displaySection(years[yearId]);
    }
});

document.body.addEventListener(`click`, (e) => {

    if (e.target.tagName == `CAPTION`) {
        const sectionId = e.target.parentElement.parentElement.id;
        if (sectionId.includes(`year-`)) {
            displaySection(yearSelect);
        }
        else if (sectionId.includes(`month-`)) {
            const yearId = sectionId.split(`-`)[1];
            displaySection(years[`year-${yearId}`]);
        }
    } else if (e.target.tagName == `TD` ||e.target.tagName == `DIV` ) {
        const monthName = e.target.textContent.trim();
        if (monthNames.hasOwnProperty(monthName)) {
            let parent = e.target.parentElement;

            while (parent.tagName != `TABLE`) {
                parent = parent.parentElement;
            }

            const year = parent.querySelector(`caption`).textContent.trim();
            const monthId = `month-${year}-${monthNames[monthName]}`;
            displaySection(months[monthId]);
        }
    }


});

function displaySection(section) {

    document.body.innerHTML = ``;
    document.body.appendChild(section);
}
