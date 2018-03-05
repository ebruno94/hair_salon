-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Mar 05, 2018 at 03:47 AM
-- Server version: 5.6.34-log
-- PHP Version: 7.1.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ernest_bruno`
--
CREATE DATABASE IF NOT EXISTS `ernest_bruno` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `ernest_bruno`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `number` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `name`, `number`) VALUES
(3, 'Rowena', '554345345435'),
(5, 'Eretria', '5656767534'),
(6, 'Alma', '1231234545'),
(7, 'Amberle', '1266767564'),
(8, 'Ingrid', '124554566544'),
(9, 'Indiana', '545443322'),
(10, 'Keanna', '34323231232'),
(11, 'Jeffrey', '543443232'),
(12, 'Blake', '43435434'),
(13, 'Julius', '453443432223'),
(14, 'Kim', '4545342234'),
(15, 'Omega', '12435423456');

-- --------------------------------------------------------

--
-- Table structure for table `client_stylist`
--

CREATE TABLE `client_stylist` (
  `id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `client_stylist`
--

INSERT INTO `client_stylist` (`id`, `client_id`, `stylist_id`) VALUES
(1, 19, 13),
(6, 2, 1),
(7, 3, 1),
(8, 4, 2),
(9, 5, 2),
(10, 6, 5),
(11, 7, 3),
(12, 8, 5),
(13, 9, 1),
(14, 10, 1),
(15, 11, 1),
(16, 12, 2),
(17, 13, 3),
(18, 14, 3),
(19, 15, 4);

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL,
  `specialty` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`id`, `specialty`) VALUES
(1, 'Hair'),
(2, 'Nail'),
(3, 'Nail'),
(4, 'Style'),
(5, 'Massage');

-- --------------------------------------------------------

--
-- Table structure for table `specialty_stylist`
--

CREATE TABLE `specialty_stylist` (
  `id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialty_stylist`
--

INSERT INTO `specialty_stylist` (`id`, `specialty_id`, `stylist_id`) VALUES
(1, 1, 1),
(2, 1, 1),
(3, 2, 2),
(4, 2, 2),
(5, 3, 3),
(6, 3, 3),
(7, 4, 4),
(8, 4, 4),
(9, 5, 5),
(10, 5, 5);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `number` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `name`, `number`) VALUES
(1, 'Ernest Bruno', '425 773 3981'),
(2, 'Georgia', '534534583'),
(3, 'Pipune', '(425) 733-3981'),
(4, 'Ivana', '1838742834'),
(5, 'Tomiko', '1235565656');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `client_stylist`
--
ALTER TABLE `client_stylist`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialty_stylist`
--
ALTER TABLE `specialty_stylist`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT for table `client_stylist`
--
ALTER TABLE `client_stylist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `specialty_stylist`
--
ALTER TABLE `specialty_stylist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
