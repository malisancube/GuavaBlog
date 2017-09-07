var gulp = require("gulp"),
  fs = require("fs"),
  less = require("gulp-less");

gulp.task("less", function () {
    return gulp.src('wwwroot/styles/admin.less')
    .pipe(less())
    .pipe(gulp.dest('wwwroot/css'));
});