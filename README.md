# EPIC SALON

#### BECOME AN OWNER OF THIS EPIC SALON! Add employees and manage their clients! 2/23/2018

#### By **Ernest Bruno**

## Description

This simple website takes advantage of MySQL database to add employees / stylists into the system and manage each stylists' clients!


## Setup/Installation Requirements

1. Clone this repository from GitHub (https://github.com/ebruno94/hair_salon.git)

2. In MySQL:
* CREATE DATABASE ernest_bruno;
* USE ernest_bruno;
* CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), number VARCHAR(35));
* CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), number VARCHAR(35), stylist_id INT);

3. Use terminal and run >dotnet run.

4. Open web browser into localhost:5000/

## Known Bugs
* No known bugs at this time.

## Technologies Used
* C#
* MAMP
* MVC
* HTML
* CSS
* Bootstrap

## Support and contact details

_Email no one with any questions, comments, or concerns._

### License

*{This software is licensed under the MIT license}*

Copyright (c) 2018 **_{Ernest Bruno}_**
