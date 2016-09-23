
###### Database Set Up Instructions
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
