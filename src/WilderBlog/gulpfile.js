/// <binding Clean='default' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

gulp.task("npmTasks", function () {
  gulp.src([
     'node_modules/angular2/bundles/*.*',
     //'node_modules/angular2/bundles/js',
     //'node_modules/angular2/bundles/angular2.*.js*',
     //'node_modules/angular2/bundles/http.*.js*',
     //'node_modules/angular2/bundles/router.*.js*',
     //'node_modules/angular2/bundles/angular2-polyfills.js',
     //'node_modules/angular2/bundles/angular2.dev.js'
     'node_modules/es6-shim/es6-shim.js*',
     'node_modules/systemjs/dist/*.*',
     //'node_modules/systemjs/dist/system.src.js',
     'node_modules/rxjs/bundles/rx.js',
  ]).pipe(gulp.dest("wwwroot/lib/angular2"));
});

gulp.task('default', ["npmTasks"]);