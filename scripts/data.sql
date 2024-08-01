USE BookStore
GO

INSERT INTO Categories(Name)
VALUES ('programming'),('Educational'),('Drama'),('Fantasy'),('Mistery'),('SciFi'),('Western'),('Contemporary'),('Dystopian')
GO

INSERT INTO Books(CategoryId, Name, Author, Description, Value, PublishDate)
VALUES (1,'Arquitectura limpia: Guía de un artesano para la estructura y el diseño del software','Robert C. Martin','Practical Software Architecture Solutions from the Legendary Robert C. Martin (“Uncle Bob”).', '152.99', '2017-09-10')
GO

INSERT INTO Books(CategoryId, Name, Author, Description, Value, PublishDate)
VALUES (1,'Agile Software Development, Principles, Patterns, and Practices','Robert C. Martin','Written by a software developer for software developers, this book is a unique collection of the latest software development methods.', '79.99', '2002-10-15')
GO

INSERT INTO Books(CategoryId, Name, Author, Description, Value, PublishDate)
VALUES (1,'Clean Code: A Handbook of Agile Software Craftsmanship','Robert C. Martin','Even bad code can function. But if code isnt clean, it can bring a development organization to its knees.', '46.99', '2008-08-01')
GO