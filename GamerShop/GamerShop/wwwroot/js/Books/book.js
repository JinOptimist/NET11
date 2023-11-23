var box = document.querySelector('.book-list-container');

var images = [
    "../img/Books/0.jpg",
    "../img/Books/1.jpg",
    "../img/Books/2.jpg",
    "../img/Books/3.jpg",
    "../img/Books/4.jpg"
];


var ArrayLength = images.length; //gets the index length of the array


function ImageChange() {
    let index = 0;

    box.style.backgroundImage = "url(" + images[index] + ")";
    index++;
    function newImage() {
        //the box's background image will be set to the image url with that index
        box.style.backgroundImage = "url(" + images[index] + ")";
        //After some time the index will go up by one and pick the next url, but if the index is = to the imageUrls[] length then it wraps back around to the first index
        index = (index + 1) % ArrayLength;
    }
    //sets amount of time until the next index is picked
    setInterval(newImage, 5000);

}

ImageChange();

