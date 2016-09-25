


# Hair Salon Stylist and Client List

#### Site allows users to see stylists and clients for each stylist

#### _Created 09.23.2016.  Last update 09.23.2016._

#### By _**Jonathan Buchner**_

## Description

This site was made to fulfill the **Week Three Epicodus Friday independent project requirement for the C# block**.  Project outline:

Create an app for a hair salon. The owner should be able to add to a list of the stylists, and for each stylist, add clients who see that stylist. The stylists work independently, so each client only belongs to a single stylist.

Additional Requirements
+ For this code review, use the following names for your databases:
  + Production Database: hair_salon
  + Development Database: hair_salon_test
  + Resource names will be clients and stylists
+ In your README, include setup instructions with database names and tables (example below from To Do application):

```sql
In SQLCMD:

CREATE DATABASE to_do;
GO
USE to_do;
GO
CREATE TABLE categories (id INT IDENTITY(1,1), name VARCHAR(255));
CREATE TABLE tasks (id INT IDENTITY(1,1), description VARCHAR(255));
GO
```

+ Create tests in xUnit and use them to first create a class called Stylist (English specs are not necessary for this problem). Your class should have the following methods: a constructor, an Equals override, Save, GetAll, DeleteAll, Find, Update, and Delete.
+ Remember to commit as you go, and do not start writing your Nancy app until after you have made all your tests pass for your first class. After you've written the routes in Nancy for the Stylist class, then stop working on your Nancy app and start working on your second class, and just focus on testing.
+ Your second class should be called Client. You should have the same methods for this class as for the Stylist class.
+ The Stylist class should be updated to contain a method to retrieve all of the clients for that stylist.
+ After you are finished writing your methods for the Client class, finish your Nancy app to demonstrate it working. At this point your app should have 2 pages. The first one should present the user with a form for adding a stylist and it should list out all of the stylists at this hair salon. The second page should be for when a user clicks on a stylist and this page should display all of the clients that this stylist has and a form for adding more clients to this stylist.
+ Now add in the edit and delete functionality to your Nancy app for these two classes as well. You'll need one more page for each class so that you can present an edit form.
+ When you're finished, export two .sql files holding the information from both your hair_salon and hair_salon_test databases (see instructions in the Migrating databases with SSMS lesson, creating both production and test databases). Please commit them with your project.

#### Objectives
Your teachers will evaluate your project with you based on the following criteria:

+ Do the database table and column names follow proper naming conventions?
+ Do you have thorough test coverage?
+ Are all tests passing?
+ Is a one-to-many relationship set up correctly in the database and application?
+ Has CRUD functionality for each class been built in Nancy?
+ Were RESTful routes used in Nancy?
+ Are the commands on how to setup the database in the README? Did you include the .sql files?
+ Have the previous weeks' objectives been met?
+ Does the project demonstrate understanding of this week's concepts? If prompted, are you able to discuss the flow of your code with an instructor?
+ Is the project in a polished, portfolio-quality state?

#### Previous Objectives

Make sure to follow all the requirements from last week, too.

+ Was Razor syntax used on view pages where appropriate?
+ Is your logic easy to understand?
+ Did you use descriptive variable names?
+ Does your code have proper indentation and spacing?
+ Did you include a README with a description of the program, setup instructions, a copyright, a license, and your name?
+ Is the project tracked in Git, and did you regularly make commits with clear messages that finish the phrase "This commit will…"?

## Setup/Installation Requirements

* _Clone repository. Then locate folder through command line_
* _cp> dnu restore to load necessary files._
* _cp> dnx kestrel to start the server._
* _Import sql database or using schema below to create databases_
* _Go to localhost:5004 to view the site_
- Get file from: https://github.com/JonathanBuchner/HairSalon

###### Database Schma
```sql
CREATE DATABASE hair_salon
GO
USE hair_salon
GO
CREATE TABLE stylists
(
  id INT IDENTITY (1,1),
  description VARCHAR(255)
);
GO
 CREATE TABLE clients
(
  id INT IDENTITY (1,1),
  description VARCHAR(255),
  stylist INT
);
Go
CREATE DATABASE hair_salon_test
GO
USE hair_salon_test
GO
CREATE TABLE stylists
(
  id INT IDENTITY (1,1),
  description VARCHAR(255)
);
GO
 CREATE TABLE clients
(
  id INT IDENTITY (1,1),
  description VARCHAR(255),
  stylist INT
);
Go
```

## Known Bugs and observations
- There is no error checking for inputs site.
  - Names can exceed VarChar(255);
  - Names can empty VarChar(255);
- Limited views.
 - You cannot change a clients stylist.  The client must be recreated.
 - You cannot see a list of all clients.

## Support and contact details
Email me at websites@jonathanbuchner.com

## Technologies Used

+ Mono, Nancy, Razor view engine.
+ cSharp, html, css, sql.

### License

COPRYRIGHT ACCORDING TO MIT LICENSE

Copyright (c) 2016 **_Jonathan Buchner_**

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.*
