var gulp = require('gulp');
var dotnet = require('gulp-dotnet');
gulp.task('build', function(cb) {
  dotnet.build({ cwd: './' }, cb);
});