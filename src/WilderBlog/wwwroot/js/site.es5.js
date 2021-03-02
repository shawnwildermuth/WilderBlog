// Site-wide JavaScript
"use strict";

// Search Form
document.addEventListener("DOMContentLoaded", function (event) {

  var searchForm = document.getElementById("searchForm");
  if (searchForm) {
    var searchInput = document.getElementById("searchInput");
    searchForm.addEventListener("submit", function (e) {
      window.location = "/search/" + encodeURI(searchInput.value);
      e.preventDefault();
      return false;
    });
  }

  var infoPanel = document.getElementById("info-panel");
  var button = document.getElementById("info-table-btn");
  button.addEventListener("click", function () {
    if (infoPanel.classList.contains("hidden")) {
      infoPanel.classList.remove("hidden");
    } else {
      infoPanel.classList.add("hidden");
    }
  });

  // Support Lazy Loading of Images
  var lazyLoadInstance = new LazyLoad({
    elements_selector: ".lazy"
    // ... more custom settings?
  });

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
  });

  var toggles = document.getElementsByClassName("video-toggle");
  var videoContainer = document.getElementsByClassName("video-container");

  function clickHandler(e) {
    var video = document.getElementById("video-" + e.target.attributes['data-id']);
    if (video) {
      if (e.target.innerText === "Show Video") {
        e.target.innerText = "Hide Video";
        loadVideo(video);
        video.classList.remove("hide");
      } else {
        e.target.innerText = "Show Video";
        video.classList.add("hide");
      }
    }
  }

  function loadVideo(video) {
    var iframes = video.getElementsByTagName("iframe");
    if (iframes) {
      if (!iframes[0].attributes["src"]) {
        iframes[0].attributes["src"] = iframes[0].attributes["data-src"];
      }
    }
  }

  // Wire up clicks
  if (toggles) {
    toggles.forEach(function (t) {
      return t.addEventListener("click", clickHandler);
    });
  }

  if (videoContainer) {
    videoContainer.forEach(function (c) {
      if (c.classList.hasClass("auto-load")) loadVideo(c);
    });
  }
});

