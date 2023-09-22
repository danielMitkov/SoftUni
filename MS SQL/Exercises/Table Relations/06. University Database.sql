CREATE TABLE [Subjects]
(
    [SubjectID] 
        INT 
        PRIMARY KEY IDENTITY,
    [SubjectName] 
        VARCHAR(50) NOT NULL
)
CREATE TABLE [Majors]
(
    [MajorID] 
        INT 
        PRIMARY KEY IDENTITY,
    [Name] 
        VARCHAR(50) NOT NULL
)
CREATE TABLE [Students]
(
    [StudentID] 
        INT 
        PRIMARY KEY IDENTITY,
    [StudentNumber] 
        INT NOT NULL,
    [StudentName] 
        VARCHAR(50) NOT NULL,
    [MajorID] 
        INT 
        FOREIGN KEY REFERENCES [Majors]([MajorID])
)
CREATE TABLE [Payments]
(
    [PaymentID] 
        INT 
        PRIMARY KEY IDENTITY,
    [PaymentData] 
        DATETIME2 NOT NULL,
    [PaymentAmount] 
        DECIMAL(7, 2) NOT NULL,
    [StudentID] 
        INT 
        FOREIGN KEY REFERENCES [Students]([StudentID])
)
CREATE TABLE [Agenda] 
(
    [StudentID] 
        INT NOT NULL 
        FOREIGN KEY REFERENCES [Students]([StudentID]),
    [SubjectID] 
        INT NOT NULL 
        FOREIGN KEY REFERENCES [Subjects]([SubjectID]),
    CONSTRAINT PK_Agenda
        PRIMARY KEY ([StudentID], [SubjectID])
)