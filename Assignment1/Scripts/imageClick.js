var imgElement = document.createElement('img');
var imageContainer = document.getElementById('image-show');
var xIcon = document.getElementById('x');
var imageOne = document.getElementById('image-one');
var imageTwo = document.getElementById('image-two');
var imageThree = document.getElementById('image-three');

imageOne.addEventListener("click", function () {
    imgElement.src = "../../images/blue/aster_novae_angliae/images/1.jpg";
    imgElement.alt = "aster novae angliae flower";
    console.log(imgElement);
    imageContainer.appendChild(imgElement);
    imageContainer.classList.remove("none");
});

imageTwo.addEventListener("click", function () {
    imgElement.src = "./../images/blue/aster_pantens/images/1.jpg";
    imgElement.alt = "Aster Pantens Flower";
    console.log(imgElement);
    imageContainer.appendChild(imgElement);
    imageContainer.classList.remove("none");
});

imageThree.addEventListener("click", function () {
    imgElement.src = "../../images/blue/centaurea_cyanus_peg/images/1.jpg";
    imgElement.alt = "Centaurea Cyanus Peg";
    console.log(imgElement);
    imageContainer.appendChild(imgElement);
    imageContainer.classList.remove("none");
});

xIcon.addEventListener("click", function () {
    imageContainer.classList.add("none");
});