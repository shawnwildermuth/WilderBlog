// video.js
(function ($) {
  $(".video-toggle").on("click", function () {
    var $btn = $(this);
    var $video = $("#video-" + $btn.attr("data-id"));
    if ($btn.text() == "Show Video") {
      $btn.text("Hide Video");
      $iframe = $video.find("iframe");
      if (!$iframe.is('[src]')) {
        $iframe.attr("src", $iframe.attr("data-src"));
      }
      $video.show(0);
    } else {
      $btn.text("Show Video");
      $video.hide(0);
    }
  });
})(jQuery);