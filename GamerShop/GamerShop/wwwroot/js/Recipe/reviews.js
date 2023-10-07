$(document).ready(function () {
    const reviewHub = new signalR.HubConnectionBuilder()
        .withUrl('/recipe/review')
        .build();
        
    reviewHub.on("NewReviewAdded", addReviewToRecipe);
    
    reviewHub.start();

    function addReviewToRecipe(username, text, rating, date) {
        const reviewDiv = $("<div>").addClass("review");
        reviewDiv.append($("<h5>").text(username));
        reviewDiv.append($("<p>").text(text));
        reviewDiv.append($("<span>").addClass("rating").text("Rating: " + rating));
        reviewDiv.append($("<span>").addClass("date").text(date));
        $(".review-scrollbar").append(reviewDiv);
    }

});