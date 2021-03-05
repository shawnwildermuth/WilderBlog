// Site-wide JavaScript
"use strict";

// Search Form
document.addEventListener("DOMContentLoaded", function (event) {

  /**********************Menu ************************************************** */

  let menu = document.getElementById("menu");
  let menuButton = document.getElementById("menu-button");
  if (menu && menuButton) {
    menuButton.addEventListener("click", () => {
      menu.classList.toggle("hidden");
    });
  }


  /***************** Search **************************************************** */

  let searchForm = document.getElementById("searchForm");
  if (searchForm) {
    let searchInput = document.getElementById("searchInput");
    searchForm.addEventListener("submit", function (e) {
      window.location = "/search/" + encodeURI(searchInput.value);
      e.preventDefault();
      return false;
    });
  }

  /***************** Info  **************************************************** */


  const infoPanel = document.getElementById("info-panel");
  const button = document.getElementById("info-table-btn");
  button.addEventListener("click", function () {
    if (infoPanel.classList.contains("hidden")) {
      infoPanel.classList.remove("hidden");
    } else {
      infoPanel.classList.add("hidden");
    }
  });

  /***************** Lazy Images **************************************************** */

  // Support Lazy Loading of Images
  let lazyLoadInstance = new LazyLoad({
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

  const toggles = document.getElementsByClassName("video-toggle");
  const videoContainers = document.getElementsByClassName("video-container");

  function clickHandler(e) {
    const videoItemId = `video-${e.target.attributes['data-id'].value}`;
    const video = document.getElementById(videoItemId);
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
    const iframes = video.getElementsByTagName("iframe");
    if (iframes) {
      if (!iframes[0].attributes["src"] && iframes[0].attributes["data-src"]) {
        const dataSrc = iframes[0].attributes["data-src"].value;
        iframes[0].setAttribute("src", dataSrc);
      }
    }
  }

  // Wire up clicks
  if (toggles) {
    for (let x = 0; x < toggles.length; ++x) {
      toggles[x].addEventListener("click", clickHandler);
    }
  }

  if (videoContainers) {
    for (let x = 0; x < videoContainers.length; ++x) {
      if (videoContainers[x].classList.contains("auto-load")) loadVideo(videoContainers[x]);
    };
  }


  /***************** About **************************************************** */
  const openSourceList = document.getElementById("openSourceList");
  if (openSourceList) {
    let template = _.template(
`<div class="border border-gray-100 rounded m-1 p-1">
    <a href='<%= html_url %>' target='blank'><h4><%= name %></h4></a>
    <p class="text-sm"><%= description %></p>
  </div>
`);

    fetch("https://api.github.com/users/shawnwildermuth/repos?type=owner&sort=pushed")
      .then(result => result.json())
      .then(function (data) {
        let results = _.filter(data, function (item) {
          return !item.fork && item.watchers_count > 0 && item.description;
        });
        results = _.orderBy(results, ["stargazers_count"], ["desc"]);
        _.forEach(_.take(results, 10), function (item) {
          const block = document.createElement("div");
          block.innerHTML = template(item);
          openSourceList.append(block)
        });
      });
  }


});
