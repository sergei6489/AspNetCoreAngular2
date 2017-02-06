var gulp = require('gulp');
var root_path = {
    webroot: "./wwwroot/",
    nmSrc:"./node_modules/"
};

root_path.rootLibrary = root_path + 'npm-library/';
gulp.task('copyNpmLibrary', function () {
    gulp.src(root_path.nmSrc + '/systemjs/dist/**/*.*', { base: root_path.nmSrc + '/systemjs/dist/' }).pipe(gulp.dest(root_path.rootLibrary + '/systemjs/'));

    gulp.src(root_path.nmSrc + '/angular2/bundles/**/*.*', { base: root_path.nmSrc + '/angular2/bundles/' }).pipe(gulp.dest(root_path.rootLibrary + '/angular2/'));

    gulp.src(root_path.nmSrc + '/es6-shim/es6-sh*', { base: root_path.nmSrc + '/es6-shim/' }).pipe(gulp.dest(root_path.rootLibrary + '/es6-shim/'));

    gulp.src(root_path.nmSrc + '/rxjs/bundles/*.*', { base: root_path.nmSrc + '/rxjs/bundles/' }).pipe(gulp.dest(root_path.rootLibrary + '/rxjs/'));
});