-- Create Users table
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255),
    Email VARCHAR(255) UNIQUE,
    Password VARCHAR(255)
);

-- Create Product table
CREATE TABLE Product (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductTitle VARCHAR(255),
    QuantityTotal INT,
    QuantityBooked INT,
    Price DECIMAL(10, 2)
);

-- Create Customer table
CREATE TABLE Customer (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(255)
);

-- Create TransactionHistory table
CREATE TABLE TransactionHistory (
    TransactionID INT,
    ProductID INT,
    CustomerID INT,
    TransactionDateTime DATETIME,
    TransactionType VARCHAR(3),
    Quantity INT,
    TransactionParentID INT,
    PRIMARY KEY (TransactionID, ProductID, CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (TransactionParentID, ProductID, CustomerID) REFERENCES TransactionHistory(TransactionID, ProductID, CustomerID)
);



