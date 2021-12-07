-- Host: localhost:3306
-- Generation Time: Sep 25, 2016 at 10:48 PM
-- Server version: 5.6.33
-- PHP Version: 5.6.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

CREATE TABLE IF NOT EXISTS `tblReview` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `rating` int(5) NOT NULL,
  `firstName` varchar(25),
  `lastName` varchar(25),
  `comment` varchar(200),
  `date` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `tblGrades`
--

INSERT INTO `tblReview` (`id`, `rating`, `firstName`, `lastName`, `comment`, `date`) VALUES
(1, 5, 'Ethan', 'Farrell', 'Awesome bicycle! This is the best one I have ever owned', '2021-10-12');