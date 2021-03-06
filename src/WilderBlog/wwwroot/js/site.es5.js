// Site-wide JavaScript
"use strict";

// Search Form
document.addEventListener("DOMContentLoaded", function (event) {

  /***************** Search **************************************************** */

  var searchForm = document.getElementById("searchForm");
  if (searchForm) {
    var searchInput = document.getElementById("searchInput");
    searchForm.addEventListener("submit", function (e) {
      window.location = "/search/" + encodeURI(searchInput.value);
      e.preventDefault();
      return false;
    });
  }

  /***************** Info  **************************************************** */

  var infoPanel = document.getElementById("info-panel");
  var button = document.getElementById("info-table-btn");
  button.addEventListener("click", function () {
    if (infoPanel.classList.contains("hidden")) {
      infoPanel.classList.remove("hidden");
    } else {
      infoPanel.classList.add("hidden");
    }
  });

  /***************** Lazy Images **************************************************** */

  // Support Lazy Loading of Images
  var lazyLoadInstance = new LazyLoad({
    elements_selector: ".lazy"
    // ... more custom settings?
  });

  /***************** cookie consent **************************************************** */

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

  /***************** Videos **************************************************** */

  var toggles = document.getElementsByClassName("video-toggle");
  var videoContainers = document.getElementsByClassName("video-container");

  function clickHandler(e) {
    var videoItemId = "video-" + e.target.attributes['data-id'].value;
    var video = document.getElementById(videoItemId);
    if (video) {
      if (e.target.innerText === "Show Video") {
        e.target.innerText = "Hide Video";
        video.classList.remove("hidden");
        loadVideo(video);
      } else {
        video.classList.add("hidden");
        e.target.innerText = "Show Video";
      }
    }
  }

  function loadVideo(video) {
    var iframes = video.getElementsByTagName("iframe");
    if (iframes) {
      if (!iframes[0].attributes["src"] && iframes[0].attributes["data-src"]) {
        var dataSrc = iframes[0].attributes["data-src"].value;
        iframes[0].setAttribute("src", dataSrc);
      }
    }
  }

  // Wire up clicks
  if (toggles) {
    for (var x = 0; x < toggles.length; ++x) {
      toggles[x].addEventListener("click", clickHandler);
    }
  }

  if (videoContainers) {
    for (var x = 0; x < videoContainers.length; ++x) {
      if (videoContainers[x].classList.contains("auto-load")) loadVideo(videoContainers[x]);
    };
  }

  /***************** About **************************************************** */
  var openSourceList = document.getElementById("openSourceList");
  if (openSourceList) {
    var template = _.template("<div class=\"border border-gray-100 rounded m-1 p-1\">\n    <a href='<%= html_url %>' target='blank'><h4><%= name %></h4></a>\n    <p class=\"text-sm\"><%= description %></p>\n  </div>\n");

    fetch("https://api.github.com/users/shawnwildermuth/repos?type=owner&sort=pushed").then(function (result) {
      return result.json();
    }).then(function (data) {
      var results = _.filter(data, function (item) {
        return !item.fork && item.watchers_count > 0 && item.description;
      });
      results = _.orderBy(results, ["stargazers_count"], ["desc"]);
      _.forEach(_.take(results, 10), function (item) {
        var block = document.createElement("div");
        block.innerHTML = template(item);
        openSourceList.append(block);
      });
    });
  }
});

