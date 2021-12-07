// Make the review form invisible and visible
function formVisibility(){
    $(document.getElementById("reviewForm")).toggle();
    $(document.getElementById("btnReview")).toggle();
}

// initialize JQuery plugin for text counter on the comment
$('#txtReview').maxlength({
    threshold: 200,
    showCharsTyped: true,
    allowOverMax: false,
    customMaxAttribute: "200"
});

//Make the ratings system appear 
$('#rating-system').rating();

// if star is click chang to the corosponding value
$('#rating-system').on('rating:change', function(event, value, caption) {
    console.log(value);
    let ratingValue = document.getElementById("rating-value");
    ratingValue.value = value;
    console.log(caption);
});

// if clear button on ratings system is clicked clear the value
$('#rating-system').on('rating:clear', function(event) {
    let value = 0;
    let ratingValue = document.getElementById("rating-value");
    ratingValue.value = value;
    console.log("rating:clear");

});
// display the ratings stars 
$(':input[type="number"]').each((index, element) => {
    let something = element.id.split("_")[1];
    console.log(String(something));
    if(something != undefined){
        something = String(something);
        settingRatings(something);    
    }
    
});

// Setting the rating identity to make them unique
function settingRatings(ratingIdentity) {
    console.log("Calling onload");
    console.log(ratingIdentity);
    let rating = document.getElementById("rating-number_"+ratingIdentity);
    console.log(rating);
    $('#ratings_'+ratingIdentity).rating('update', rating.innerText);
}


