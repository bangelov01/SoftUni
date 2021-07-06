function attachEvents() {

    const baseUrl = `http://localhost:3030/jsonstore/forecaster/`;
    const forecastElement = document.getElementById(`forecast`);

    const symbolType = {
        Sunny:`☀`,
        "Partly sunny":`⛅`,
        Overcast:`☁`,
        Rain:`☂`,
    }

    document.querySelector(`#submit`).addEventListener(`click`, getWeatherInfo)

    async function getWeatherInfo() {
        try {

            const locationNameInput = document.querySelector(`#location`).value;

            const baseLocation = await getBaseLocation(locationNameInput);
    
            const todayDetails = await getTodayInfo(baseLocation);
    
            const threeDayDetails = await getThreeDayInfo(baseLocation);

            const todayForecast = createCurrent(todayDetails);
            const threeDayForecast = createThreeDayForecast(threeDayDetails);

            document.querySelector(`#forecast`).style.display = `block`;
            forecastElement.innerHTML = ``;

            forecastElement.appendChild(todayForecast);
            forecastElement.appendChild(threeDayForecast);

        } catch (error) {

            forecastElement.style.display = `block`;
            forecastElement.innerHTML = ``;
            const div = createElement(`div`, {id: `current`, className: `label`}, `Error`);
            forecastElement.appendChild(div);
        }



        function createCurrent(todayDetails) {

            const result = createElement(`div`, { id: `current` },
                createElement(`div`, { className: `label` }, `Current conditions`),
                createElement(`div`, { className: `forecasts` },
                    createElement(`span`, { className: `condition symbol` }, `${symbolType[todayDetails.forecast.condition]}`),
                    createElement(`span`, { className: `condition` },
                        createElement(`span`, { className: `forecast-data` }, `${todayDetails.name}`),
                        createElement(`span`, { className: `forecast-data` }, `${todayDetails.forecast.low}°/${todayDetails.forecast.high}`),
                        createElement(`span`, { className: `forecast-data` }, `${todayDetails.forecast.condition}`)
                    )
                )
            )

            return result;
        }

        function createThreeDayForecast(threeDayDetails) {

            const result = createElement(`div`, { id: `upcoming` },
                createElement(`div`, { className: `label` }, `Three-day forecast`),
                createElement(`div`, { className: `forecast-info` },
                    threeDayDetails.forecast.map(el => createElement(`span`, { className: `upcoming` },
                        createElement(`span`, { className: `symbol` }, `${symbolType[el.condition]}`),
                        createElement(`span`, { className: `forecast-data` }, `${el.low}°/${el.high}`),
                        createElement(`span`, { className: `forecast-data` }, `${el.condition}`))
                    )
                )
            )

            return result;
        }

        async function getBaseLocation(locationNameInput) {

            const locationsResponse = await fetch(baseUrl + `locations`);    
            const locations = await locationsResponse.json();
    
            return locations.find(loc => locationNameInput === loc.name);
        }

        async function getTodayInfo(baseLocation) {

            const todayResponse = await fetch(baseUrl + `today/${baseLocation.code}`);
            const todayDetails = await todayResponse.json();

            return todayDetails;
        }

        async function getThreeDayInfo(baseLocation) {

            const threeDayResponse = await fetch(baseUrl + `upcoming/${baseLocation.code}`);
            const threeDayDetails = await threeDayResponse.json();

            return threeDayDetails;
        }
    }

    function createElement(type, attributes, ...content) {
        const result = document.createElement(type);
    
        for (let [attr, value] of Object.entries(attributes || {})) {
            if (attr.substring(0, 2) == 'on') {
                result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
            } else {
                result[attr] = value;
            }
        }
    
        content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);
    
        content.forEach(e => {
            if (typeof e == 'string' || typeof e == 'number') {
                const node = document.createTextNode(e);
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });
    
        return result;
    }
}

attachEvents();