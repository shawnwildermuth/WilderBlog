// Site-wide JavaScript

// Search Form
(function ($) {
  $("#searchForm").submit(function (e) {
    window.location = "/search/" + encodeURI($("#search").val());
    e.preventDefault();
    return false;
  });
})(jQuery);
