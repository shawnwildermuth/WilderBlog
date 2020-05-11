// Site-wide JavaScript

// Search Form
(function ($) {
  $("#searchForm").submit(function (e) {
    window.location = "/search/" + encodeURI($("#search").val());
    e.preventDefault();
    return false;
  });
  //var $menu = $("#menu");
  //$("#toggle-menu").on("click", function (e) {
  //  $menu.toggleClass("shown");
  //});

  // Support Lazy Loading of Images
  var lazyLoadInstance = new LazyLoad({
    elements_selector: ".lazy"
    // ... more custom settings?
  });

  $('[data-toggle="tooltip"]').tooltip()

  window.cookieconsent.initialise({
    "palette": {
      "popup": {
        "background": "#404040",
        "text": "#eee"
      },
      "button": {
        "background": "#007BFF"
      }
    },
    "theme": "classic",
    "position": "bottom-right",
    "content": {
      "message": "My site uses cookies for analytics and some Google Adwords ads. Thanks for supporting the site. If you want to learn more about cookies, look here:",
      "dismiss": "I get it..."
    }
  })


})(jQuery);
