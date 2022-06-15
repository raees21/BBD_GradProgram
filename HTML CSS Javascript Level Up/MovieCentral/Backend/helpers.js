const fs = require ('fs');

const imageFilter = function(req, file, cb) {
    // Accept images only
    if (!file.originalname.match(/\.(jpg|JPG|jpeg|JPEG|png|PNG|gif|GIF)$/)) {
        req.fileValidationError = 'Only image files are allowed!';
        return cb(new Error('Only image files are allowed!'), false);
    }
    cb(null, true);
};
exports.imageFilter = imageFilter;

const decodeBase64Image = (base64image, fileName) => {

    // base64image.replace(/^data:image\/\w+;base64,/, "");
    let imageData = base64image.split(',');
    let imageType = imageData[0].replace('data:image/', '').replace(';base64', '');
    let data = imageData[1];
    let buffer = Buffer.from(data, 'base64');
    fs.writeFile(`${fileName}.${imageType}`, buffer, () => {});
    console.log('file saved');
    return(`${fileName}.${imageType}`);
};
exports.decodeBase64Image = decodeBase64Image;