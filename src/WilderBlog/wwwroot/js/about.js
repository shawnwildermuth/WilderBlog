/// <reference path="site.js" />
(function ($) {
  $(document).ready(function () {

    var $openSourceList = $("#openSourceList");
    if ($openSourceList.length > 0) {
      var template = _.template(
        "<div class='card-header'>" +
        "  <a href='<%= html_url %>' target='blank'><h4 class='card-subtitle'><%= name %></h4></a>" +
        "</div>" +
        "<div class='card-body'>" +
        "  <div class='card-text'>" +
        "    <small><%= description %></small>" +
        " </div>" +
        "</div>");
      $.get("https://api.github.com/users/shawnwildermuth/repos?type=owner&sort=pushed")
        .then(function (result) {
          var results = _.filter(result, function (item) {
            return !item.fork && item.watchers_count > 0 && item.description;
          });
          results = _.orderBy(results, ["stargazers_count"], ["desc"]);
          _.forEach(_.take(results,10), function (item) {
            $openSourceList.append($(template(item)))
          });
        });
    }
  });
})(jQuery);