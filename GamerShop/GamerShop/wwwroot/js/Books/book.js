var box = document.querySelector('.book-list-container');

var images = [
    "../img/Books/0.jpg",
    "../img/Books/1.jpg",
    "../img/Books/2.jpg",
    "../img/Books/3.jpg",
    "../img/Books/4.jpg"
];

var ArrayLength = images.length;

function ImageChange() {
    let index = 0;

    box.style.backgroundImage = "url(" + images[index] + ")";
    index++;
    function newImage() {
        box.style.backgroundImage = "url(" + images[index] + ")";
        index = (index + 1) % ArrayLength;
    }
    setInterval(newImage, 5000);

}

ImageChange();

