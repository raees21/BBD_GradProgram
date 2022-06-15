const express = require("express");
const bodyParser = require("body-parser");
const cors = require("cors");
const multer = require("multer");
const path = require("path");
const { createReadStream } = require("fs");
const fs = require("fs");
const util = require("util");

const helpers = require("./helpers");

const {
  addMovie,
  connectToDB,
  getMovies,
  validateUsername,
  createUser,
  removeUser,
  listAllUsers,
  removeMovie,
  getMovieInfo,
} = require("./mysql");

const { uploadFile, getFileStream } = require("./s3");

const app = express();
app.use(cors());
// Configuring body parser middleware
app.use(bodyParser.urlencoded({
  limit: '100mb',
  parameterLimit: 100000,
  extended: true 
}));
app.use(bodyParser.json({
  limit: '100mb'
}));
app.use(express.static(__dirname + "/public"));
const port = 3030;

connectToDB();

const removeFile = util.promisify(fs.unlink);

// app.get('/', async (req, res) => {
//   const response = await getLastMovieID();
//     console.log(response[0]["previd"])
// });

app.get("/GetMovies", async (req, res) => {
  const movies = await getMovies();
  res.send(movies);
});

app.get("/GetMovieInfo", async (req, res) => {
  res.status(200);
  const response = await getMovieInfo(req["body"]["id"]);
  res.send(response);
});

app.post("/CreateUser", async (req, res) => {
  const validation = await validateUsername(req["body"]["userid"]);
  if (validation === 0) {
    res.status(200);
    createUser(req["body"]["userid"]);
    //Unathi to do something with req.password and send token?
    res.send("User created successfully!");
  } else {
    res.status(400);
    res.send("Error: this username is already in use.");
  }
});

app.post("/Login", async (req, res) => {
  const validation = await validateUsername(req["body"]["userid"]);
  if (validation === 1) {
    res.status(200);
    //Unathi to do something with req.password and send token?
    res.send("User logged in successfully!");
  } else {
    res.status(400);
    res.send("Error: this username does not exist.");
  }
});

app.post("/DeleteUser", async (req, res) => {
  const validation = await validateUsername(req["body"]["userid"]);
  if (validation === 1) {
    res.status(200);
    removeUser(req["body"]["userid"]);
    res.send("User deleted successfully!");
  } else {
    res.status(400);
    res.send("Error: this username does not exist.");
  }
});

app.post("/AddMovie", async (req, res) => {
  const movie = req.body;
  let image;

  try {
    image = helpers.decodeBase64Image(
      movie.image,
      `${movie.name}-${Date.now()}`
    );
    console.log(image);
    await uploadFile(image);
    addMovie({
      ...movie,
      image,
    });
  } catch (e) {
    console.log(`Error ${e}`);
    res.status(400);
    res.send({
      error: e,
    });
  } finally {
    await removeFile(image);
  }

  res.status(201);
  res.send({
    ...movie,
    image: image,
  });
});

app.get("/images/:id", (req, res) => {
  const id = req.params.id;
  const readStream = getFileStream(id);
  readStream.pipe(res);
});

app.post("/RemoveMovie", (req, res) => {
  res.status(200);
  removeMovie(req["body"]["id"]);
  res.send("Movie deleted successfully!");
});

app.post("/EditMovie", (req, res) => {
  const book = req.body;
  console.log(book);
  res.send(book.test);
  //Just need unathi to assist here - same as add movie or slightly diff?
});

app.listen(port, () =>
  console.log(`Movie Central Server listening on port ${port}!`)
);
