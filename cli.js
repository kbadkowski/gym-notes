var sys = require('util')
var exec = require('child_process').exec;

var arg = process.argv[2];
var logger;
var dir = "docker/";

switch (arg) {
    case "run-all":
        logger = exec(`docker-compose -f ${dir}docker-compose.yml up -d --build`, function (err, stdout, stderr) {
            if (err) {
                console.error("error with running app");
            }
            console.log(stdout);
        });

        logger.on('exit', function (code) {
        });
            console.log("application is running");
        break;
    case "run-db":
        logger = exec(`docker-compose -f ${dir}docker-compose.db.yml up -d --build`, function (err, stdout, stderr) {
            if (err) {
                console.error("error with running app");
            }
            console.log(stdout);
        });

        logger.on('exit', function (code) {
            console.log("application db running");
        });
        break;
    case "stop-all":
        logger = exec(`docker-compose -f ${dir}docker-compose.yml stop`, function (err, stdout, stderr) {
            if (err) {
                console.error("error with running app");
            }
            console.log(stdout);
        });

        logger.on('exit', function (code) {
        });
            console.log("application killed");
        break;
    case "help":
        help();
        break;
    default:
        console.log('run node cli.js help to see list of available commands');
        break;
}

function help() {
    console.log("available commands:\nrun-all - run all images\nrun-db - run db image\nstop-all - stop all images");
}