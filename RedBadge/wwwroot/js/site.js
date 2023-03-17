// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Get references to our mobile navigation button and nav menu content
var navButton = document.getElementById('nav-button');
var navContent = document.getElementById('navbarSupportedContent');

// When the mobile navigation button is clicked, toggle the show-nav-content css class
navButton.addEventListener('click', () => {
    navContent.classList.toggle("show-nav-content");
});

