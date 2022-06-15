const BACKEND_URL = "http://localhost:3030"
const ALL_MOVIES = "/GetMovies"

const allMoviesWrapper = document.querySelector('.wrapper')

function addDataToElement(numberOfElements, dataList, sectionToAppendTo){
    for (let i = 0; i < numberOfElements; i++){
        if (dataList.length > i){
            clickableLink = document.createElement("a")

            newMovie = document.createElement("section")
            newMovie.classList.add("movie")

            clickableLink.appendChild(newMovie)
            sectionToAppendTo.appendChild(clickableLink)

            image_link = encodeURIComponent(dataList[i].Image)
            id_link = `/view_movie.html?id=${dataList[i].MovieID}`
            
            clickableLink.href = id_link
            newMovie.style = `background-image: url(${BACKEND_URL}/images/${image_link})`
        }
    }
}

// Fetch the data from the API as soon as the page opens
async function getapi(url) {
    
    // Storing response
    const response = await fetch(url);
    
    let movieList = await response.json();
    
    addDataToElement(movieList.length, movieList, allMoviesWrapper)
}

getapi(`${BACKEND_URL}${ALL_MOVIES}`);