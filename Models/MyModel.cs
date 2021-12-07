using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductReview.Models {

    public class MyModel {

        // Connection string to the database
        private const string CONNECTION_STRING = "Server=localhost;port=3306;Database=ProductReviews;Uid=Trailblazer780;Pwd=1337;SslMode=none;";
        private List<Review> _reviews;
        private Review _reviewDetails;
        private MySqlConnection dbConnection;
        private MySqlCommand dbCommand;
        private MySqlDataReader dbReader;
        private int _count;
        private int _ratingValue;


        public MyModel(){
            // Initilize the DB connection
            dbConnection = new MySqlConnection(CONNECTION_STRING);
            // Set up the command
            dbCommand = new MySqlCommand("", dbConnection); 
            // List of reviews
            _reviews = new List<Review>();
            // 
            _reviewDetails = new Review();
            // Initializing count
            _count = 0;
            // Initializing rating value
            _ratingValue = 1;
        }

        //--------------------------------------------------------------- Gets / Sets
        public List<Review> reviews {
            get {
                return _reviews;
            }
        }

        public Review reviewDetails {
            get {
                return _reviewDetails;
            }
        }

        public int count {
            get {
                return _count;
            }
        }

        public DateTime GetDate {get; set;}
        public int ratingValue {get; set;}

        //--------------------------------------------------------------- Public Methods
        // This function call gets all of the past reviews in the database 
        public void setupMe() {
            getPastReviews();
        }

        public void submitReview() {
            Console.WriteLine(ratingValue.ToString());
        }


        public void getNewReview(int rating, string firstName, string lastName, string comment, string date) {
            // set the rating value
            rating = ratingValue;
            try {
                // open connection to the database
                dbConnection.Open();
                dbCommand.Parameters.Clear();
                // Insert data to the database
                dbCommand.CommandText = "INSERT INTO tblReview (rating, firstName, lastName, comment, date) VALUES (?rating, ?firstName, ?lastName, ?comment, ?date)";
                // add the rating value from 0 to 5 stars 
                dbCommand.Parameters.AddWithValue("?rating", rating);
                // check if first name is null or empty
                if(String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName)){
                    // set the name to anonymous if empty
                    firstName = "Anonymous";
                    lastName = "";
                    dbCommand.Parameters.AddWithValue("?firstName", firstName);
                    dbCommand.Parameters.AddWithValue("?lastName", lastName);
                }
                else {
                    // if not empty add the first name
                    dbCommand.Parameters.AddWithValue("?firstName", firstName);
                    dbCommand.Parameters.AddWithValue("?lastName", lastName);
                }
                
                // if comment is null or empty do nothing and do not submit review
                if (String.IsNullOrEmpty(comment)){
                    return;
                }
                else {
                    // If there is something in the comment add it to the database
                    dbCommand.Parameters.AddWithValue("?comment", comment);
                }
                // add the date
                dbCommand.Parameters.AddWithValue("?date", DateTime.Today);
                // Execute the command 
                dbCommand.ExecuteNonQuery();
            }
            // If run into error 
            catch (Exception e) {
                Console.WriteLine(">>> An error has occured with GetNewReview");
                Console.WriteLine(">>> " + e.Message);
            }

            finally {
                // Close the database connection
                dbConnection.Close();
            }
        }

        //--------------------------------------------------------------- Private Methods

        private void getPastReviews() {
            try {
                dbConnection.Open();
                // getting all reviews from the database and ordering them newest to oldest
                dbCommand.CommandText = "SELECT * FROM tblReview ORDER BY id DESC";
                dbReader = dbCommand.ExecuteReader();
                // Make a review object and add all of the data to its properties
                while(dbReader.Read()) {
                    Review review = new Review();
                    review.reviewID = Convert.ToInt32(dbReader["id"]);
                    review.rating = Convert.ToInt32(dbReader["Rating"]);
                    review.firstName = Convert.ToString(dbReader["FirstName"]);
                    review.lastName = Convert.ToString(dbReader["LastName"]);
                    review.comment = Convert.ToString(dbReader["Comment"]);
                    // get the current date and time
                    DateTime date = Convert.ToDateTime(dbReader["Date"]);
                    // format the date and time 
                    review.date = date.ToString("yyyy-MM-dd");
                    // add this review to the list of reviews
                    _reviews.Add(review);
                }
                // Close the dbreader
                dbReader.Close();
            }
            // If run into error 
            catch(Exception e) {
                Console.WriteLine(">>> An error has occured with getPastReviews");
                Console.WriteLine(">>> " + e.Message);
            }
            // Close the database connection
            finally {
                dbConnection.Close();
            }
        }

    }
}
