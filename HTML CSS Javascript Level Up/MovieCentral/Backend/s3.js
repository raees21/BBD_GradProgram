const fs = require('fs');
const S3 = require('aws-sdk/clients/s3');
require('dotenv').config();

const bucket = process.env.AWS_BUCKET_NAME;
const region = process.env.AWS_BUCKET_REGION;
const accessKeyId = process.env.AWS_ACCESS_KEY;
const secretAccessKey = process.env.AWS_SECRET_KEY;

const s3 = new S3({
    region,
    accessKeyId,
    secretAccessKey
});

const uploadFile = (file) => {
    const fileStream = fs.createReadStream(`./${file}`);

    const uploadParams = {
        Bucket: bucket,
        Body: fileStream,
        Key: file
    }

    return s3.upload(uploadParams).promise();
};
exports.uploadFile = uploadFile;

const getFileStream = (fileId) => {
    const downloadParams = {
        Key: fileId,
        Bucket: bucket
    };

    return s3.getObject(downloadParams).createReadStream();
};
exports.getFileStream = getFileStream;