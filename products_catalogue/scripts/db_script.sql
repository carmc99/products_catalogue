CREATE DATABASE Catalogue;

CREATE TABLE Categories (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2 NOT NULL
);

CREATE TABLE Products (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    CategoryId UNIQUEIDENTIFIER NOT NULL,
    Image NVARCHAR(MAX) NULL,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2 NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

INSERT INTO Categories (Id, Name, Description, CreatedDate, UpdatedDate)
VALUES ('af8619d2-e7f1-4f2b-8f1d-09e4f4c4a137', 'Electronics', 'Category for electronic devices', '2023-04-13', '2023-04-13');

INSERT INTO Categories (Id, Name, Description, CreatedDate, UpdatedDate)
VALUES ('99a38a11-1420-4082-b871-116a17cdd1c7', 'Clothing', 'Category for clothing items', '2023-04-13', '2023-04-13');

INSERT INTO Categories (Id, Name, Description, CreatedDate, UpdatedDate)
VALUES ('ec73e6cb-7211-42af-bb24-6b2d1c3d5013', 'Home & Garden', 'Category for home and garden products', '2023-04-13', '2023-04-13');

INSERT INTO Categories (Id, Name, Description, CreatedDate, UpdatedDate)
VALUES ('c7d8c30e-67c5-4e2d-aa31-2d54fca1a7f3', 'Toys & Games', 'Category for toys and games', '2023-04-13', '2023-04-13');

INSERT INTO Categories (Id, Name, Description, CreatedDate, UpdatedDate)
VALUES ('f9eb1bf7-295a-4260-bcd2-77e61e8d1de1', 'Sports & Outdoors', 'Category for sports and outdoor products', '2023-04-13', '2023-04-13');



INSERT INTO Products (Id, Name, Description, CategoryId, Image, CreatedDate, UpdatedDate)
VALUES ('85d48eb8-6a1c-44e2-b03e-6a44b5ab5f5c', 'iPhone 13', 'Latest smartphone from Apple', 'af8619d2-e7f1-4f2b-8f1d-09e4f4c4a137', 'iphone-13.jpg', '2023-04-13', '2023-04-13');

INSERT INTO Products (Id, Name, Description, CategoryId, Image, CreatedDate, UpdatedDate)
VALUES ('8e06b1fc-2cfc-4d07-a5ce-9f825b9ec188', 'Samsung Galaxy S22', 'Upcoming smartphone from Samsung', 'af8619d2-e7f1-4f2b-8f1d-09e4f4c4a137', 'samsung-galaxy-s22.jpg', '2023-04-13', '2023-04-13');

INSERT INTO Products (Id, Name, Description, CategoryId, Image, CreatedDate, UpdatedDate)
VALUES ('b53c2d70-3c3f-4a8b-bc72-23ef84d7e0f5', 'Adidas UltraBoost 6', 'Latest running shoes from Adidas', '99a38a11-1420-4082-b871-116a17cdd1c7', 'adidas-ultraboost-6.jpg', '2023-04-13', '2023-04-13');

INSERT INTO Products (Id, Name, Description, CategoryId, Image, CreatedDate, UpdatedDate)
VALUES ('7d0e0d22-7f1b-4a36-bd18-789b8888c71a', 'Philips Hue Smart Bulb', 'Smart bulb that can be controlled with a smartphone', 'ec73e6cb-7211-42af-bb24-6b2d1c3d5013', 'philips-hue.jpg', '2023-04-13', '2023-04-13');

INSERT INTO Products (Id, Name, Description, CategoryId, Image, CreatedDate, UpdatedDate)
VALUES ('c2f0a03a-d1d7-4df8-8c80-9ed9b5af7e99', 'Weber Genesis II Gas Grill', 'High-quality gas grill for outdoor cooking', 'ec73e6cb-7211-42af-bb24-6b2d1c3d5013', 'weber-grill.jpg', '2023-04-13', '2023-04-13');

INSERT INTO Products (Id, Name, Description, CategoryId, Image, CreatedDate, UpdatedDate)
VALUES ('0a19c8f1-0df0-462a-bb7d-8d39d51f1f63', 'LEGO Star Wars Millennium Falcon', 'Iconic LEGO set for Star Wars fans', 'c7d8c30e-67c5-4e2d-aa31-2d54fca1a7f3', 'lego-millennium-falcon.jpg', '2023-04-13', '2023-04-13');

INSERT INTO Products (Id, Name, Description, CategoryId, Image, CreatedDate, UpdatedDate)
VALUES ('f8b8d103-3849-4f48-a7a8-24f1a7a0c425', 'Nintendo Switch', 'Popular gaming console from Nintendo', 'c7d8c30e-67c5-4e2d-aa31-2d54fca1a7f3', 'nintendo-switch.jpg', '2023-04-13', '2023-04-13');

INSERT INTO Products (Id, Name, Description, CategoryId, Image, CreatedDate, UpdatedDate)
VALUES ('85b239d4-7ebc-4ef7-894e-bd122c48eb7b', 'YETI Tundra 65 Cooler', 'High-end cooler for outdoor activities', 'f9eb1bf7-295a-4260-bcd2-77e61e8d1de1', 'yeti-cooler.jpg', '2023-04-13', '2023-04-13');