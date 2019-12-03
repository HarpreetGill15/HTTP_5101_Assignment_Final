-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Dec 03, 2019 at 11:23 PM
-- Server version: 5.7.24-log
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `websites`
--

-- --------------------------------------------------------

--
-- Table structure for table `author`
--

CREATE TABLE `author` (
  `author_id` int(11) NOT NULL,
  `author_name` varchar(50) NOT NULL,
  `author_email` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `author`
--

INSERT INTO `author` (`author_id`, `author_name`, `author_email`) VALUES
(1, 'Harpreet Gill', 'hmail@hmail.ca');

-- --------------------------------------------------------

--
-- Table structure for table `pages`
--

CREATE TABLE `pages` (
  `page_id` int(11) NOT NULL,
  `page_title` varchar(100) NOT NULL,
  `page_body` text NOT NULL,
  `publish_author` int(11) NOT NULL,
  `publish_state` varchar(20) NOT NULL,
  `publish_date` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pages`
--

INSERT INTO `pages` (`page_id`, `page_title`, `page_body`, `publish_author`, `publish_state`, `publish_date`) VALUES
(3, 'More pages', 'Content for this page', 1, 'Published', 'Tuesday, 03 December 2019 3:54 PM'),
(4, 'Index', 'Welcome to this page where i talk to fill the empty space once i get some good content i should add it here but for now i think this should be good. Maybe a little more? Yes we should be good now.', 1, 'Published', 'Tuesday, 03 December 2019 11:32 AM');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `author`
--
ALTER TABLE `author`
  ADD PRIMARY KEY (`author_id`);

--
-- Indexes for table `pages`
--
ALTER TABLE `pages`
  ADD PRIMARY KEY (`page_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `author`
--
ALTER TABLE `author`
  MODIFY `author_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `pages`
--
ALTER TABLE `pages`
  MODIFY `page_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
