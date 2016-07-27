// tourmap.js
(function ($) {

  var map;
  var currentLocNumber = 55;

  $(document).ready(function () {

    $('head').append("<style> #map img{max-width: inherit;} .gm-style-iw{ overflow: hidden !important;}</style>")

    var url = "//wildermuth.com/js/tourdates.js";


    $.get(url, function (data) {

      var lines = eval(data);

      $.each(lines, function (i, stop) {
        stop.info = stop.info.replace(" - ", "<br/>");
      });

      var map = travelMap.createMap({
        stops: lines,
        currentStop: currentLocNumber,
        selector: "#map"
      });

    });

  });

})(jQuery);