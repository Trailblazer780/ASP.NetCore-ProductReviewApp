namespace ProductReview.Models {
    public class Review {
        // This is the review Object that is used to store data about the reviews
        public int reviewID {get;set;}
        public int rating {get;set;}
        public string firstName {get;set;}
        public string lastName {get;set;}
        public string comment {get;set;}
        public string date {get;set;}
    }
}