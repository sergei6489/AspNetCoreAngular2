/// <binding AfterBuild='copy-all' />
var gulp = require('gulp');
var root_path = {
    webroot: "./wwwroot/",
    nmSrc:"./node_modules/"
};

root_path.rootLibrary = root_path.webroot + 'npm-library/';
gulp.task('copyNpmLibrary', function () {
    gulp.src(root_path.nmSrc + '/systemjs/dist/**/*.*', { base: root_path.nmSrc + '/systemjs/dist/' }).pipe(gulp.dest(root_path.rootLibrary + '/systemjs/'));

    gulp.src([root_path.nmSrc+'@angular/common/bundles/*.*', root_path.nmSrc+'@angular/core/bundles/*.*',root_path.nmSrc+'@angular/forms/bundles/*.*',root_path.nmSrc+'@angular/http/bundles/*.*',
    root_path.nmSrc + '@angular/compiler/bundles/*.*', root_path.nmSrc + '@angular/platform-browser/bundles/*.*',
    root_path.nmSrc + '@angular/platform-browser-dynamic/bundles/*.*', root_path.nmSrc + '@angular/router/bundles/*.*'], { base: root_path.nmSrc + '/angular2/bundles/' }).pipe(gulp.dest(root_path.rootLibrary + '/angular2/'));

    gulp.src(root_path.nmSrc + '/es6-shim/es6-sh*', { base: root_path.nmSrc + '/es6-shim/' }).pipe(gulp.dest(root_path.rootLibrary + '/es6-shim/'));

    gulp.src(root_path.nmSrc + '/rxjs/bundles/*.*', { base: root_path.nmSrc + '/rxjs/bundles/' }).pipe(gulp.dest(root_path.rootLibrary + '/rxjs/'));
});

gulp.task('copy-app', function () {
    gulp.src('./appScripts/*.js').pipe(gulp.dest(root_path.webroot + '/appLibrary/'))
    gulp.src('mainpage.html').pipe(gulp.dest(root_path.webroot))
    gulp.src('system.config.js').pipe(gulp.dest(root_path.webroot))
});

gulp.task('copy-all', ['copyNpmLibrary', 'copy-app'])