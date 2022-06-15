const BACKEND_URL = "http://localhost:3030"
const ALL_MOVIES = "/GetMovies"

let IN_THEATRES = []
let COMING_SOON = []

const theatresSection = document.querySelector('#in-theatres')
const comingSoonSection = document.querySelector('#coming-soon')

const mobileMenu = document.querySelector('.mobile-menu');
const menuButton = document.querySelector('.openmenu');
const closeButton = document.querySelector('.closemenu');
const deleteButton = document.querySelector('.btn-remove')

menuButton.addEventListener('click', () => {
    mobileMenu.classList.add('active');
    document.body.style.overflow = "hidden";
});

closeButton.addEventListener('click', () => {
    mobileMenu.classList.remove('active');
    document.body.style.overflow = "visible";
});

//Delete Button 

// deleteButton.addEventListener('click', () =>{
//     const movie = movieList.childern; 
//     for (const movie of movies){
//         if (movie.classList.contains('selected')){
//             movie.remove(); 
//         }
//     }
// });

const test = (file) => {
    return new Promise((resolve, reject) => {
        var reader = new FileReader();
        reader.readAsDataURL(file)
        reader.onload = () => resolve(reader.result)
    })
};

const changeToBase64 = async () => {
    let image = document.getElementById('textimage');
    let textimage = document.getElementById('image');
    
    document.getElementById('image').value = await test(image.files[0]);
}


function addDataToElement(numberRequiredElements, dataList, sectionToAppendTo){
    for (let i = 0; i < numberRequiredElements; i++){
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
    let IN_THEATRES = movieList.slice(0, movieList.length/2)
    let COMING_SOON = movieList.slice(movieList.length/2, movieList.length)

    
    addDataToElement(5, IN_THEATRES, theatresSection)
    addDataToElement(5, COMING_SOON, comingSoonSection)
}

getapi(`${BACKEND_URL}${ALL_MOVIES}`);