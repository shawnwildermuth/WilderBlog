/// <binding Clean='default' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var bower = require('gulp-bower-files');

gulp.task("npmTasks", function () {
  // Angular2 
  gulp.src([
     'node_modules/angular2/bundles/*.*',
     'node_modules/es6-shim/es6-shim.js*',
     'node_modules/systemjs/dist/*.*',
     'node_modules/rxjs/bundles/rx.js',
  ]).pipe(gulp.dest("wwwroot/lib/angular2"));
});

gulp.task("minify", function () {
  gulp.src(["wwwroot/js/*.js"])
    .pipe(uglify())
    .pipe(concat("wilderblog.min.js"))
    .pipe(gulp.dest("wwwroot/lib/site"));
});

gulp.task('default', ["npmTasks", "minify"]);