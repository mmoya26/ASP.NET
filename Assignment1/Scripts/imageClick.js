var imgElement = document.createElement('img');
var cover = document.getElementById('cover');
var imageContainer = document.getElementById('image-show');
var xIcon = document.getElementById('x');
var images = document.querySelectorAll(".image-thumbnail");

xIcon.addEventListener("click", function () {
    imageContainer.classList.add("none");
    cover.classList.add('none');
});

cover.addEventListener("click", function () {
    imageContainer.classList.add("none");
    cover.classList.add('none');
});

function addEventListener() {
    for (var i = 0; i < images.length; i++) {
        images[i].addEventListener("click", setUpImagePath);
    }
}

function setUpImagePath(e) {
    var flowerElement = e.target;
    var flowerToPathName = flowerElement.alt;
    var folderColor = this.className.split(' ')[1];
    flowerToPathName = flowerToPathName.toLowerCase();
    flowerToPathName = flowerToPathName.split(" ").join("_");

    imgElement.src = "/asp9/ex7/Content/images/" + folderColor + "/";
    imgElement.src += flowerToPathName;
    imgElement.src += "/images/1.jpg"

    imgElement.alt = flowerElement.alt;

    imageContainer.appendChild(imgElement);
    imageContainer.classList.remove("none");
    cover.classList.remove('none');
}

addEventListener(); 

