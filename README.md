# Online-Student-Grading-System

<div align="center">

  [![description](https://img.shields.io/badge/project-Individual-FFB7C5?style=for-the-badge)](https://github.com/KennardWang/Online-Student-Grading-System)
  &nbsp;
  [![stars](https://img.shields.io/github/stars/KennardWang/Online-Student-Grading-System?style=for-the-badge&color=FDEE21)](https://github.com/KennardWang/Online-Student-Grading-System/stargazers)
  &nbsp;
  [![forks](https://img.shields.io/github/forks/KennardWang/Online-Student-Grading-System?style=for-the-badge&color=white)](https://github.com/KennardWang/Online-Student-Grading-System/forks)
  &nbsp;
  [![contributors](https://img.shields.io/github/contributors/KennardWang/Online-Student-Grading-System?style=for-the-badge&color=8BC0D0)](https://github.com/KennardWang/Online-Student-Grading-System/graphs/contributors)
  
  <img src="https://img.shields.io/badge/windows-0078D6?logo=windows&logoColor=white&style=for-the-badge" />
  &nbsp;
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
  &nbsp;
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  &nbsp;
  <img src="https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white" />
  &nbsp;
  <img src="https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" />
</div>

<br>

It is a project of MUST course ***CS108-Advanced Database System***, which is a simple database for grading students.



## Table of Contents

- [Development Environment](#development-environment)
- [Install](#install)
- [Usage](#usage)
- [Highlights](#highlights)
- [Design](#design)
- [SQL Code](#sql-code)
- [Maintainers](#maintainers)
- [Contributing](#contributing)
- [License](#license)



## Development Environment

|       <!-- -->      |                    <!-- -->                         |
| :-----------------: | :-------------------------------------------------: |
|       System        |                   Windows 10 x64                    |
| Front-end Framework |                    ASP.NET 4.7.2                    |
|  Back-end Language  |                         C#                          |
|         IDE         |        Visual Studio Community 2019 v16.7.5         |
|    Database Tool    |   SQL Server Management Studio (SSMS) v18.7.1       |



## Install

1. Import the project
    1. Create an empty ASP.NET web application (.NET framework).
	<br>
 	<div align=center>
  		<img src="https://user-images.githubusercontent.com/57723061/145088795-e6e60d0a-3232-47f8-9c68-aa7e3177c7b9.png" width="35%" />
		&nbsp;
		<img src="https://user-images.githubusercontent.com/57723061/145089048-9c9193b0-ade6-49c8-b5f5-925fb7227042.png" width="35%" />
	</div>

    2. Copy all files in ***OSGS_webpages*** into the root directory of the created project.

      <br>
	<div align=center>
  		<img src="https://user-images.githubusercontent.com/57723061/145089296-44c11586-9ff3-49e2-88ab-0de9f10d4aed.png" width="70%" />
	</div>

    3. Include them in the project.

      <br>
	<div align=center>
	    <img src="https://user-images.githubusercontent.com/57723061/145089722-1c863ba1-b0a0-4f6b-878e-d67cdb22cfd0.png" width="35%" />
	    &nbsp;
	    <img src="https://user-images.githubusercontent.com/57723061/145089749-9b19db0c-b574-45e6-b7f5-f2dbbeed08ae.png" width="35%" />
	</div>  

    4. Click ***IIS Express*** to open the website.
  
      <br>
      <div align=center>
  	     <img src="https://user-images.githubusercontent.com/57723061/145090006-405fc848-a1f5-4613-9485-0a1b1b79bfbc.png" width="70%" />
      </div>


2. Migrate the database
    1. Add a connection string in `Web.config`.
	
 	```
	<connectionStrings>
	    <add name="OSGSConnectionString" connectionString="Data Source=DESKTOP-KV5M48K;Initial Catalog=OSGS;Integrated Security=True"
	      providerName="System.Data.SqlClient" />
	</connectionStrings>
	```

 	<br>
        <div align=center>
  	     <img src="https://user-images.githubusercontent.com/57723061/145090249-cd6fc902-36d3-4511-92f5-956018e017ad.png" width="70%" />
        </div>


    2. Replace the ***Data Source*** value in each `.cs` file and `Web.config` file. Use `Ctrl+H` to replace all. The ***Data Source*** value should be replaced with your SSMS server name, and mine is *DESKTOP-KV5M48K*.
	
 	<br>
        <div align=center>
  	     <img src="https://user-images.githubusercontent.com/57723061/145091477-58de1f83-503a-4a88-baa7-8cbafda5437d.png" height="100px%" />
	     &nbsp;
	     <img src="https://user-images.githubusercontent.com/57723061/145091731-187ab713-9417-49b9-9848-13498b850643.png" height="100px" />
        </div>


    3. Open *SQL Server Configuration Manager*, and change *log on as* to *Local System*. After that, restart the *MSSQLSERVER*.

 	<br>
        <div align=center>
  	     <img src="https://user-images.githubusercontent.com/57723061/145092027-36677010-0aea-4866-b425-9b20d67787bb.png" height="100px%" />
	     &nbsp;
	     <img src="https://user-images.githubusercontent.com/57723061/145092481-09d05326-7852-47ba-ba0f-4df126479d49.png" height="100px" />
        </div>


    4. Open SQL Server Management Studio (SSMS) and connect.

       <br>
        <div align=center>
  	     <img src="https://user-images.githubusercontent.com/57723061/145092631-2e8058e7-a4a7-48f2-989c-edb4e299f5e0.png" width="70%" />
        </div>


    5. Open a ***New Query*** and execute the following SQL.
	
 	```
	EXEC sp_attach_db @dbname = 'OSGS',
	@filename1 = 'yourDir\Online-Student-Grading-System\OSGS.mdf',    
	@filename2 = 'yourDir\Online-Student-Grading-System\OSGSLog.ldf'
	```

	<br>
        <div align=center>
  	     <img src="https://user-images.githubusercontent.com/57723061/145093100-cdb531e2-89ee-4451-a1ca-0a1f61639cdc.png" width="50%" />
        </div>


    6. Test the database.

	```
	USE OSGS
	SELECT * FROM Teacher
	```

	<br>
        <div align=center>
  	     <img src="https://user-images.githubusercontent.com/57723061/145093196-a6fdb406-084f-41c6-baf6-b081807ef436.png" width="70%" />
        </div>


3. Log in OSGS
    1. Click ***IIS Express*** to run, and enter the Teacher ID/Password: ***sllo_stu/123456***.

       <br>
        <div align=center>
  	     <img src="https://user-images.githubusercontent.com/57723061/145093878-ce6ce4e6-2521-4a89-9219-48a3c348f07d.png" width="35%" />
	     &nbsp;
	     <img src="https://user-images.githubusercontent.com/57723061/145093932-84a96cbe-b1b0-4652-89b7-6d995a2b1939.png" width="35%" />
        </div>



## Usage
+ Login page (Login.aspx)

  > The login page must be the initial page which has two different login types, which will handle the login event of both teachers and students. Users can log in with the correct ***ID*** and ***Password***. The teachers' information is assigned by ***SSMS*** and students' information is assigned by the teacher.

  <br>
  <div align=center>
     <img src="https://kennardwang.github.io/Image-Source/Online-Student-Grading-System/login_teacher.png" width="40%" />
     &nbsp;
     <img src="https://kennardwang.github.io/Image-Source/Online-Student-Grading-System/login_student.png" width="40%" />
  </div>


<br>

+ Student account management page (StuOverview.aspx, this page is for the teacher)
  
  > As we all know, a teacher probably has more than one course. For example, Professor Lo has two courses CS101 and CS108. On this page, he can see all the students who take CS108 by choosing the ***DropDownList*** whose value is 'CS108'. By the way, the teacher can also ***Edit*** the information of students (including name, password, and email address) or ***Delete*** it if the student cancels the course.

  <br>
  <div align=center>
  	<img src="https://kennardwang.github.io/Image-Source/Online-Student-Grading-System/student_account_management.png" width="70%" />
  </div>


<br>

+ Assignment management page (AssignmentManagement.aspx, this page is for the teacher)

  > Switching the ***RadioButtonList*** can enter this page. We can see all the assignments the teacher gives to each course, and also about assignment info (name, weight, total question number, deadline, submit state), student info, and grade info (grade and comment). Clicking the ***Select*** button to get more information.

  <br>
  <div align=center>
  	<img src="https://kennardwang.github.io/Image-Source/Online-Student-Grading-System/assignment_management.png" width="70%" />
  </div>


<br>

+ Assignment marking page (AssignmentMarking.aspx, this page is for the teacher)

  > It is a page to mark students' assignments, and all the questions and answers will be displayed. The teacher can give comments and grades, the data will be updated on the previous page.

  <br>
  <div align=center>
  	<img src="https://kennardwang.github.io/Image-Source/Online-Student-Grading-System/assignment_marking.png" width="70%" />
  </div>


<br>

+ Assignment creating page (AddNewAssignment.aspx, this page is for the teacher)

  > To create a new assignment, the teacher can enter information about this assignment, and also choose to add or delete a question, which implements the variability of the question number.

  <br>
  <div align=center>
  	<img src="https://kennardwang.github.io/Image-Source/Online-Student-Grading-System/assignment_add.png" width="70%" />
  </div>


<br>

+ Register page (RegisterNew.aspx, this page is for the teacher)

  > This page is used for course registration or new-student registration, the teacher can select the register type (***Student Register*** for a new student, ***Course Register*** for a student who has not taken the course) and add information to the database.

  <br>
  <div align=center>
     <img src="https://kennardwang.github.io/Image-Source/Online-Student-Grading-System/register_course.png" width="40%" />
     &nbsp;
     <img src="https://kennardwang.github.io/Image-Source/Online-Student-Grading-System/register_student.png" width="40%" />
  </div>


<br>

+ Student assignment page (AssignmentOverview.aspx, this page is for students)

  > After logging in as a student, you will enter into this page. For each course you have taken, you can see each of the assignment info (weight, total question number, deadline, grade, submission state [Y for yes/N for no], teacher's comment) and the ***GPA*** will be computed and displayed automatically.

  <br>
  <div align=center>
  	<img src="https://kennardwang.github.io/Image-Source/Online-Student-Grading-System/student_assignment.png" width="70%" />
  </div>

<br>

+ Student answer page (StudentAnswer.aspx, this page is for students)

  > On this page, students can see the details about their assignment answers or submit their answers. But if students have submitted the answer before, they will not be allowed to update their answers again. The teacher's comments can also be seen.

  <br>
  <div align=center>
  	<img src="https://kennardwang.github.io/Image-Source/Online-Student-Grading-System/student_answer.png" width="70%" />
  </div>



## Highlights
- [x] To be more realistic, I design a dual-login system for both teacher and student, the user can switch the login type to enter the system. After entering the system, the user can click the ***logout*** button to back to the home page. 
- [x] Allow the user to take more than one course and the system will display the information corresponding to the selected course. 
- [x] The question number of each assignment is not fixed, teachers can add or delete questions if they want.
- [x] On ***StuOverview.aspx*** page, the teacher can reset students' login passwords directly by clicking the ***Edit*** button and then the data will be updated.
- [x] The bootstrap framework provides a user-friendly GUI which is supported on most devices.



## Design
+ Class Diagram

  > It is drawn by ***NClass 2.04***, we have 8 ***C#*** classes, corresponding to each front page shown before. For each class, I implement some event functions which can handle all the events (such as Clicking, DropdownList change, Text change, RadioButton changed etc.) taking place on the current page.

  <br>
  <div align=center>
  	<img src="https://kennardwang.github.io/Image-Source/Online-Student-Grading-System/class_diagram.png" width="70%" />
  </div>

<br>

+ ER Diagram 

  + In the design phase, first I find the ***Student Entity*** and the ***Teacher Entity*** have the same attributes like name, password and email address, which reminds me to use the ***ISA*** structure to represent.
  + And then, ***Course Entity*** records the course ID and the course name. It has both relationships with ***Student*** and ***Teacher***, that's why ***stuid*** and ***tid*** are foreign keys of ***Course***.
  + For ***Assignment Entity***, we set **aid*** as the primary key. This entity has lots of attributes but it still has a constraint with ***cid*** of ***Course***. By the way, ***Assignment Entity*** will store some important messages like the assignment name, which course, how many questions does have, weight, and also the deadline.
  + In ***Question Entity***, it records question content and the index of questions, ***aid*** is a foreign key because I consider that many questions might be related to one assignment so that we can find the exact question if we know about the ***aid*** and the ***q_index***.
  + The ***Answer Entity*** has two foreign keys, one is ***qid*** and another is ***stuid*** because for the same question, we need to know which student has answered it. It is the reason why both foreign keys are necessarily required. Additionally, the content of the student's answers and the teacher's comments will be recorded, too.
  + The last entity is ***Submit Entity***, this entity stores the grade information, submission statement and teacher's comment about the whole assignment. ***Submit Entity*** has a relationship with ***Student*** and ***Assignment*** because it records all assignment information of each student.

  <br>
  <div align=center>
  	<img src="https://kennardwang.github.io/Image-Source/Online-Student-Grading-System/ER_Diagram.png" width="70%" />
  </div>

<br>

+ Schema

  <br>
  <div align=center>
  	<img src="https://kennardwang.github.io/Image-Source/Online-Student-Grading-System/schema.png" width="70%" />
  </div>



## SQL Code

+ Database Creation

	```
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
	```

+ Table Creation

	```
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
	```

+ Data Update

  > On StuOverview.aspx, the teacher can edit students' information:

	```
	/* update table */
	UPDATE Student
	SET sName = @sName, psw=@psw, emailAddress=@emailAddress
	WHERE stuid = @stuid
	GO
	```

+ Data Query

  > I use the query of Assignment Management.aspx as an example:
    
	```
	SELECT A.aid, A.aname, S.stuid, S.sName, A.weight AS [weight(%)], 
	A.q_number, A.deadline, SU.stat, SU.grade, SU.comment
	FROM Assignment AS A
	JOIN Submit AS SU 
	ON SU.aid = A.aid 
	JOIN Course AS C
	ON C.cid=A.cid AND C.tid = A.tid AND C.cid = @cid AND 
	C.tid = @tid AND SU.stuid = C.stuid
	JOIN Student AS S
	ON S.stuid = C.stuid
	```

  > We can see that all the columns totally involve 3 tables (Assignment, Submit and Course), so the first operation is definitely joining all three tables. And then, we need to check:

    1. The current teacher exactly teaches this course (probably there are 2 teachers teaching CS108 together).
    2. The students exactly take the course of this teacher. 
    3. The result belongs to currently selected course (if selected CS101, some of the students will miss it).
    4. The submission is corresponding to those students.


+ Data Insertion
  + SQL Connecting
	```
	SqlConnection con = new SqlConnection("Data Source=DESKTOP
	-KV5M48K;Initial Catalog=OSGS;Integrated Security=True");
	
	con.Open();
	```

  + Insertion Method
	```
	// insert, update and delete
	public void sql_insert(string sql, SqlConnection con)
	{
	    SqlCommand cmd = new SqlCommand(sql, con);
	    try
	    {
	        cmd.ExecuteNonQuery();               
	    }
	    catch
	    {
	        halt = true;
	        Response.Write("<script type='text/javascript'>
	        alert('Insert Fail!');</script>");
	    }
	        
	}
	```

  + Insert Question Table
	```
	sql_que = "INSERT INTO Question(qid, q_index, aid, content)
	VALUES (" + qid + ", 1, " + aid + ", '" + Q_one.Text + "')";
	```
    
  + Insert Assignment Table
	```
	sql_assign = "INSERT INTO Assignment(aid, aname, cid, q_number, 
	[weight], tid, deadline) 
	VALUES(" + aid + ", '" + aname.Text + "', '" + cid.Text + 
	"', " + num.ToString() +", " + weight.Text +", '" + tid + 
	"', '" + ddl.Text +"')";
	```
    
  + Insert Answer Table
	```
	sql = "INSERT INTO Answer(ansid, qid, stuid, content, tcomment) 
	VALUES(" + ansid.ToString() + ", " + qid_1 + ", '" + stuid 
	+"', '" + ans.Text + "', '')";
	```
    
  + Insert Submit Table
	```
	sql1 = "INSERT INTO Submit(subid, aid, stuid, grade, comment, 
	stat) 
	VALUES(" + subid.ToString() + ", " + aid + ", '" +
	tmp[0].ToString() + "', 0.0, ' ', 'N')";
	```
    
  + How to assign a new ID as the primary key (like new aid, qid, ansid, subid)
	```
	// get the largest ansid
	sql = "SELECT TOP 1 ansid FROM Answer ORDER BY ansid DESC";
	ansid = int.Parse(sql_command(sql, con));
	
	ansid++; // a new ansid
	```
    
  > In conclusion, all the parameters of previous insertion methods can be divided into 3 types: new ids (aid, qid, ansid, subid), passed by Textbox (has .Text), passed by URL (stuid or tid). They all can be connected as String Type into SQL. 



## Maintainers

![badge](https://img.shields.io/badge/maintenance-NO-EF2D5E) [@KennardWang](https://github.com/KennardWang)



## Contributing

Feel free to [open an issue](https://github.com/KennardWang/Online-Student-Grading-System/issues) or submit [PRs](https://github.com/KennardWang/Online-Student-Grading-System/pulls).



## License

[![license](https://img.shields.io/github/license/KennardWang/Online-Student-Grading-System)](LICENSE) © Kennard Wang ( 2021.1.1 )
