/* create database */
CREATE DATABASE OSGS
ON(
	NAME='OSGS',
	FILENAME='C:\OSGS.mdf',
	SIZE=17MB,
	FILEGROWTH=5MB
)
LOG ON
(	
	NAME='OSGSLog',
	FILENAME='C:\OSGSLog.ldf',
	SIZE=5MB,
	FILEGROWTH=5MB
)
GO


/* enter database */
USE OSGS
GO


/* create table */
CREATE TABLE Teacher(
	tid varchar(25) NOT NULL PRIMARY KEY,
	tName varchar(15) NOT NULL,
	psw varchar(15) NOT NULL,
	emailAddress varchar(30) NOT NULL
)

CREATE TABLE Student(
	stuid varchar(25) NOT NULL PRIMARY KEY,
	sName varchar(15) NOT NULL,
	psw varchar(15) NOT NULL,
	emailAddress varchar(30) NOT NULL
)

CREATE TABLE Course(
    indexNumber INT NOT NULL PRIMARY KEY,
	cid varchar(10) NOT NULL,
	cname varchar(20) NOT NULL,
	stuid varchar(25) NOT NULL FOREIGN KEY REFERENCES Student(stuid),	
	tid varchar(25) NOT NULL FOREIGN KEY REFERENCES Teacher(tid)
)

CREATE TABLE Assignment(
    aid INT NOT NULL PRIMARY KEY,
	aname varchar(15) NOT NULL,
	cid varchar(10) NOT NULL,
	q_number INT NOT NULL DEFAULT 0,
	[weight] INT NOT NULL,	
	tid varchar(25) NOT NULL FOREIGN KEY REFERENCES Teacher(tid),
	deadline varchar(20) NOT NULL,	
)

CREATE TABLE Question(
    qid INT NOT NULL PRIMARY KEY,
	q_index INT NOT NULL,
	aid INT NOT NULL FOREIGN KEY REFERENCES Assignment(aid),
	content varchar(100) DEFAULT NULL
)

CREATE TABLE Answer(
    ansid INT NOT NULL PRIMARY KEY,
	qid INT NOT NULL FOREIGN KEY REFERENCES Question(qid),
	stuid varchar(25) NOT NULL FOREIGN KEY REFERENCES Student(stuid),
	content varchar(100) DEFAULT NULL,
	tcomment varchar(100) DEFAULT NULL
)

CREATE TABLE Submit(
    subid INT NOT NULL PRIMARY KEY,
	aid INT NOT NULL FOREIGN KEY REFERENCES Assignment(aid),
	stuid varchar(25) NOT NULL FOREIGN KEY REFERENCES Student(stuid),
	grade real DEFAULT 0.0,
	comment varchar(100) DEFAULT NULL,
	stat varchar(1) NOT NULL DEFAULT 'N'
)
GO


/* delete table */
DROP TABLE Teacher
DROP TABLE Student
DROP TABLE Course
DROP TABLE Assignment
DROP TABLE Question
DROP TABLE Answer
DROP TABLE Submit
GO


/* insert data */
INSERT INTO Teacher(tid, tName, psw, emailAddress) 
VALUES ('sllo_stu','Kenneth Lo','123456','sllo@must.edu.mo'),
       ('hcwong_stu','Hugo Wong','123456','hcwong@must.edu.mo'),
	   ('pleung_stu','Alex Leung','123456','alexpleung@must.edu.mo')

INSERT INTO Student(stuid, sName, psw, emailAddress) 
VALUES ('1809853J-I011-0013','cyx','cyx666','godkillerchen@must.edu.mo'),
       ('1809853Z-I011-0045','Kennard Wang','wyy1809','wangkennard@gmail.com'),
       ('1809853A-I011-0017','sllo','cs108666','sllo@must.edu.mo')
	  
INSERT INTO Course(indexNumber, cid, cName, stuid, tid) 
VALUES (3, 'CS108', 'Advance Database', '1809853Z-I011-0045', 'sllo_stu'),
       (1, 'CS108', 'Advance Database', '1809853A-I011-0017', 'sllo_stu'),
       (2, 'CS108', 'Advance Database', '1809853Z-I011-0045', 'sllo_stu')

INSERT INTO Assignment(aid, aname, cid, q_number, [weight], tid, deadline) 
VALUES (1, 'Assignment 1','CS108', 2, 20, 'sllo_stu','2020-12-1 23:59'),
       (4, 'Assignment 2','CS108', 3, 30, 'sllo_stu','2020-12-15 23:59'),
	   (6, 'Final Project','CS108', 5, 50, 'sllo_stu','2020-12-31 23:59')

INSERT INTO Question(qid, q_index, aid, content) 
VALUES (11, 1, 6, 'List five aggregate functions.'),
       (8, 2, 6, 'How to create a table?'),
	   (9, 3, 6, 'How to update or delete data from table?'),
       (13, 4, 6, 'Why use subquery sometimes?'),
	   (14, 5, 6, 'What do you think about the window function?')

INSERT INTO Answer(ansid, qid, stuid, content, tcomment) 
VALUES (11, 8, '1809853J-I011-0013', 'CREATE', ''),
	   (12, 9, '1809853J-I011-0013', 'UPDATE, DELETE', ''),
	   (13, 11, '1809853J-I011-0013', 'SUM,COUNT,MIN,MAX,AVG', ''),
	   (14, 13, '1809853J-I011-0013', 'It is a complex way to query.', ''),
	   (15, 14, '1809853J-I011-0013', 'No idea.', ''),

	   (1, 1, '1809853Z-I011-0045', 'Structured Query Language.', 'Good!'),
       (2, 3, '1809853Z-I011-0045', 'SELECT', 'OK.'),
	   (3, 4, '1809853Z-I011-0045', 'Use WHERE clause', 'Great!'),
	   (4, 5, '1809853Z-I011-0045', 'By using GROUP BY', 'Nice!'),
	   (5, 7, '1809853Z-I011-0045', 'ORDER BY', 'Yes!')

INSERT INTO Submit(subid, aid, stuid, grade, comment, stat) 
VALUES (1, 4, '1809853Z-I011-0045', 3.7, 'Do a good job!!', 'Y'),
       (2, 6, '1809853Z-I011-0045', 4.0, 'The best answer I would ever seen.', 'Y'),
	   (3, 1, '1809853Z-I011-0045', 3.7, 'Excellent!', 'Y'),
	   (4, 7, '1809853Z-I011-0045', 0.0, '', 'Y'),
       (5, 1, '1809853J-I011-0013', 0.0, '', 'Y'),
	   (6, 4, '1809853J-I011-0013', 0.0, '', 'N'),
	   (7, 6, '1809853J-I011-0013', 3.7, 'Well Done.', 'Y'),
	   (8, 8, '1909853U-I011-0151', 0.0, '', 'N')
GO


/* delete data */
DELETE FROM Student
WHERE stuid = '1809853A-I011-0017'

DELETE FROM Course
WHERE stuid = '1809853A-I011-0017'

DELETE FROM Question
WHERE aid = 10

DELETE FROM Assignment
WHERE aid = 10

DELETE FROM Answer
WHERE ansid IN (18,19,20,21)

DELETE FROM Submit
WHERE subid = 9
GO


/* update table */
UPDATE Student
SET sName = @sName, psw=@psw, emailAddress=@emailAddress
WHERE stuid = @stuid
GO


/* query */
SELECT *
FROM Teacher

SELECT *
FROM Student

SELECT *
FROM Course

SELECT *
FROM Question

SELECT *
FROM Assignment

SELECT *
FROM Answer

SELECT *
FROM Submit
GO
