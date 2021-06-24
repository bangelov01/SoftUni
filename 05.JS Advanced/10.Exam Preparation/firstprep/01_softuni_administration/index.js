function solve() {
    function solve() {

        let addButtonElement = document.querySelector(`form div:last-child button`);
        let moduleRepo = {};
    
        addButtonElement.addEventListener(`click`, (e) => {
            e.preventDefault();
    
            let lectureNameElement = document.querySelector(`input[name="lecture-name"]`);
            let dateElement = document.querySelector(`input[name="lecture-date"]`);
            let moduleElement = document.querySelector(`select[name="lecture-module"]`);
    
            if (lectureNameElement.value == `` ||
                dateElement.value == `` ||
                moduleElement.value == `Select module`) {
                return;
            }
    
            let formattedDate = formatDate(dateElement.value);
            let lecture = createLectureObject(lectureNameElement.value,formattedDate);
            createModuleEntity(moduleElement.value, lecture);
    
            function formatDate(dateElementValue) {
                let first = dateElementValue.replace(/-/g, "/");
                let result = first.replace("T", " - ");
                return result;
            }

            function createLectureObject(lectureNameValue, formattedDate) {
                return {
                    Name: lectureNameValue,
                    Date: formattedDate
                }
            }

            function createModuleEntity(moduleNameValue, lecture){
    
                document.querySelector(`.modules`).innerHTML = ``;
    
                if (!moduleRepo[moduleNameValue]) {
                    moduleRepo[moduleNameValue] = [];
                }
    
                moduleRepo[moduleNameValue].push(lecture);
                moduleRepo[moduleNameValue].sort((a,b) => a.Date.localeCompare(b.Date));
    
                appendElements(moduleRepo, moduleNameValue)
            }
    
            function createDivElement(moduleName){
    
                let div = document.createElement(`div`);
                div.classList.add(`module`);
                let h3 = document.createElement(`h3`);
                h3.textContent = `${moduleName}-module`.toUpperCase();
                div.appendChild(h3);
                let ul = document.createElement(`ul`);
                div.appendChild(ul);
    
                return div;
            }
    
            function createLiElement(lecture) {
    
                let li = document.createElement(`li`);
                li.classList.add(`flex`);
                let h4 = document.createElement(`h4`);
                h4.textContent = `${lecture.Name} - ${lecture.Date}`;
                let button = document.createElement(`button`);
                button.classList.add(`red`);
                button.textContent = `Del`;
                button.addEventListener(`click`, (e) => {
                    let neededH4 = e.target.previousElementSibling;
                    let name = neededH4.textContent.split(` - `)[0];
                    let ul = e.target.parentElement.parentElement;
    
                    if (ul.children.length == 1) {
    
                        let neededH3Text = ul.previousElementSibling.textContent;
                        let neededModuleName = neededH3Text.split(`-`)[0].toLowerCase();
                        neededModuleName = neededModuleName.charAt(0).toUpperCase() + neededModuleName.slice(1);
                        delete moduleRepo[neededModuleName];
                        ul.parentElement.remove();
                        return;
                    }
                    else{
                        e.target.parentElement.remove();
                    }
    
                    moduleRepo[moduleElement.value] = moduleRepo[moduleElement.value].filter(el => el.Name !== name);
                })
                li.appendChild(h4);
                li.appendChild(button);
    
                return li;
            }

            function appendElements(moduleRepo) {
    
                let modules = Object.keys(moduleRepo);
                for (const module of modules) {
                    let div = createDivElement(module);
                    let neededUl = div.querySelector(`ul`);
                    for (const lecture of moduleRepo[module]) {
                        let li = createLiElement(lecture)
                        neededUl.appendChild(li);
                    }
                    document.querySelector(`.modules`).appendChild(div);
                }
            }
        });
    };
};