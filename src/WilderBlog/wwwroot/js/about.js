/// <reference path="site.js" />
(function ($) {
  $(document).ready(function () {

    var $openSourceList = $("#openSourceList");
    if ($openSourceList.length > 0) {
      var template = _.template(
        "<div class='card-header'>" +
        "  <a href='<%= html_url %>' target='blank'><h4 class='card-subtitle'><%= name %></h4></a>" +
        "</div>" +
        "<div class='card-block'>" +
        "  <div class='card-text'>" +
        "    <small><%= description %></small>" +
        " </div>" +
        "</div>");
      $.get("https://api.github.com/users/shawnwildermuth/repos?type=owner&sort-updated")
        .then(function (result) {
          var results = _.filter(result, function (item) {
            return !item.fork;
          });
          results = _.orderBy(results, ["stargazers_count"], ["desc"]);
          _.forEach(results, function (item) {
            $openSourceList.append($(template(item)))
          });
        });
    }
  });
})(jQuery);