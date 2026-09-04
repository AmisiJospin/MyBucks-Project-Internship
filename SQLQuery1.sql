-- These are the steps to follow to create a database

use NFBDataBase;

drop database NFBDataBase;

drop table Extensions;

-- Creating table Employee

CREATE TABLE Employee(
    ID INT PRIMARY KEY IDENTITY (1, 1),
    Name VARCHAR (50) NOT NULL,
    Gender VARCHAR (10) NOT NULL,
    Extension VARCHAR (30) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL,
    Location VARCHAR(20) NOT NULL,
	Role VARCHAR(20) NOT NULL,
	Profile Text NOT NULL

);

-- Creating table Employee

CREATE TABLE Extensions(
    ID INT PRIMARY KEY IDENTITY (1, 1),
    Extension VARCHAR (30) NOT NULL,
    Location VARCHAR(20) NOT NULL,
);

-- Insert into Employee 

INSERT INTO Employee VALUES ("1", "Jospin", "Male", "104", "0992129078", "City Center", "IT Officer", "Employee 34");

-- Insert into Extensions

INSERT INTO Extensions VALUES ("2", "109", "Old Town");

-- Select table Employee

Select * from Employee;

-- Updating table Employee

UPDATE name FROM Employee WHERE ID = 5;

-- Deleting table Employee

DELETE age FROM Employee WHERE name = 'Jospin';
