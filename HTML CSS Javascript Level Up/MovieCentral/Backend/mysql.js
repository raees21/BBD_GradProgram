const sql = require("mysql");

const connection = sql.createConnection({
  host: "mvcnt-db-instance-1.c9pplul3arts.us-east-1.rds.amazonaws.com",
  user: "admin",
  password: "moviecentraldb",
  database: "moviecentral",
});

const connectToDB = () => {
  connection.connect((error) => {
    if (error) {
      console.error("error: " + error.message);
      return;
    }
    console.log("Connected to the MySQL server.");
  });
};
exports.connectToDB = connectToDB;

const getMovies = () => {
  const query = "SELECT * FROM Movies";
  return new Promise((resolve, reject) => {
    connection.query(query, (error, results) => {
      if (error) {
        reject(error);
      }
      resolve(results);
    });
  });
};
exports.getMovies = getMovies;

const addMovie = async (movieData) => {
  // const movieid = await getLastMovieID()[0]["previd"];
  const query = `
  INSERT INTO Movies (
    Name,
    Rating,
    Category,
    ReleaseDate,
    Description,
    Image
  ) VALUES (
    "${movieData.name}",
    "${movieData.rating}",
    "${movieData.category}",
    "${movieData.release_date}",
    "${movieData.description}",
    "${movieData.image}"
  )`;
  connection.query(query, (error, results, fields) => {
    if (error) {
      return console.error(error.message);
    }
    console.log(results);
    return results;
  });
};
exports.addMovie = addMovie;

const validateUsername = (userid) => {
  const query = `Select count(*) as validbit from Users where UserID = '${userid}'`;
  return new Promise((resolve, reject) => {
    connection.query(query, (error, results) => {
      if (error) {
        reject(error);
      }
      resolve(results[0]["validbit"]);
    });
  });
};
exports.validateUsername = validateUsername;

const createUser = (userID) => {
  const query = `INSERT INTO Users VALUES ('${userID}')`;
  return new Promise((resolve, reject) => {
    connection.query(query, (error, results) => {
      if (error) {
        reject(error);
      }
      resolve(results);
    });
  });
};
exports.createUser = createUser;

const removeUser = (userID) => {
  const query = `DELETE FROM Users where UserID = '${userID}'`;
  return new Promise((resolve, reject) => {
    connection.query(query, (error, results) => {
      if (error) {
        reject(error);
      }
      resolve(results);
    });
  });
};
exports.removeUser = removeUser;

const listAllUsers = (userID) => {
  const query = `Select * from Users`;
  return new Promise((resolve, reject) => {
    connection.query(query, (error, results) => {
      if (error) {
        reject(error);
      }
      resolve(results);
    });
  });
};
exports.listAllUsers = listAllUsers;

const removeMovie = (movieID) => {
  const query = `DELETE FROM Movies where MovieID = '${movieID}'`;
  return new Promise((resolve, reject) => {
    connection.query(query, (error, results) => {
      if (error) {
        reject(error);
      }
      resolve(results);
    });
  });
};
exports.removeMovie = removeMovie;

const getLastMovieID = () => {
  const query = `Select max(MovieID) as previd from Movies`;
  return new Promise((resolve, reject) => {
    connection.query(query, (error, results) => {
      if (error) {
        reject(error);
      }
      resolve(results);
    });
  });
};

const getMovieInfo = (movieID) => {
  const query = `Select * FROM Movies where MovieID = '${movieID}'`;
  return new Promise((resolve, reject) => {
    connection.query(query, (error, results) => {
      if (error) {
        reject(error);
      }
      resolve(results);
    });
  });
};
exports.getMovieInfo = getMovieInfo;
