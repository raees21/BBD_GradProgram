const BACKEND_URL = "http://localhost:3030"
const ALL_MOVIES = "/GetMovies"

const queryString = window.location.search
const urlParams = new URLSearchParams(queryString)

let focusMovieID = urlParams.get("id")

const focusWrapper = document.querySelector('.focus-movie')
const relatedMoviesWrapper = document.querySelector('.wrapper')

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

function setFocusMovie(focusWrapper, focusMovie){
    image_link = encodeURIComponent(focusMovie.Image)
    focusWrapper[0].style = `background-image: url(${BACKEND_URL}/images/${image_link})`

    focusWrapper[0].querySelector('.title').innerHTML = focusMovie.Name
    focusWrapper[0].querySelector('.about').innerHTML = `2021 ‧ ${focusMovie.Category.toUpperCase()} ‧ Rating ${focusMovie.Rating} / 10`

    focusWrapper[0].querySelector('.description').innerHTML = focusMovie.Description
}

// Fetch the data from the API as soon as the page opens
async function getapi(url) {
    
    // Storing response
    const response = await fetch(url);
    
    let movieList = await response.json();

    let focusIndex = movieList.findIndex( ({ MovieID }) => MovieID == focusMovieID );

    let focusMovie = movieList[focusIndex]
    movieList.splice(focusIndex, 1)
    
    addDataToElement(5, movieList, relatedMoviesWrapper)
    setFocusMovie(focusWrapper.getElementsByClassName("container"), focusMovie)
}

getapi(`${BACKEND_URL}${ALL_MOVIES}`);