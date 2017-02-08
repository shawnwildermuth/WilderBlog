/// <binding Clean='default' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var bower = require('gulp-bower-files');

gulp.task("minify", function () {
  gulp.src(["wwwroot/js/*.js", '!wwwroot/js/tour*.js'])
    .pipe(uglify())
    .pipe(concat("wilderblog.min.js"))
    .pipe(gulp.dest("wwwroot/lib/site"));
});

gulp.task('default', ["minify"]);