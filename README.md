# Online-Student-Grading-System

### Demo
+ Login Page ( Login.aspx )

> The login page must be the initial page which has two different login types, which will handle the login event of both teachers and students. Users can login with correct ***ID*** and ***Password***. The teachers' information is assigned by ***SSMS*** and students' information is assigned by a teacher.

![login_teacher](https://kennardwang.github.io/ImageSource/Online-Student-Grading-System/login_teacher.png)

![login_student](https://kennardwang.github.io/ImageSource/Online-Student-Grading-System/login_student.png)

<br>

+ Student Account Management Page ( StuOverview.aspx, forteacher )
  
> As we all known, a teacher probably have more than one courses. For example, Professor Lo has two courses CS101 and CS108. In this page, he can see all the students who take CS108 by choosing the ***DropDownList*** whose value is 'CS108'. By the way, teacher can also ***Edit*** the information of students ( including Name, Password, Email Address ) or ***Delete*** it if the student cancel the course.

![student_account_management](https://kennardwang.github.io/ImageSource/Online-Student-Grading-System/student_account_management.png)

<br>

+ Assignment Management Page ( AssignmentManagement.aspx, for teacher )

> Switching the ***RadioButtonList*** can enter into this page. We can see all the assignments that the teacher gives to each course, and also about assignment info ( name, weight, total question number, deadline, submit state ), student info, gradeinfo ( grade and comment ). Clicking the ***Select*** button to get more information.

![assignment_management](https://kennardwang.github.io/ImageSource/Online-Student-Grading-System/assignment_management.png)

<br>

+ Assignment Marking Page ( AssignmentMarking.aspx, for teacher )

> It is about assignment and student information, all the questions and studentanswers ( if have ) will be displayed. The teacher can give comment and a grade, the data will be updated in the previous page.

![assignment_marking](https://kennardwang.github.io/ImageSource/Online-Student-Grading-System/assignment_marking.png)

<br>

+ Assignment Creating Page ( AddNewAssignment.aspx, for teacher )

> To create a new assignment, the teacher can enter information about this assignment, also choose to add or delete a question, which implements the variability of the question number.

![assignment_add](https://kennardwang.github.io/ImageSource/Online-Student-Grading-System/assignment_add.png)

<br>

+ Register Page ( RegisterNew.aspx, for teacher )

> The page is used for course register or a new student register, the teacher can select the register type ( Student Register for a new student, Course Register for a student who have not taken the course ) and add information into the database.

![register_course](https://kennardwang.github.io/ImageSource/Online-Student-Grading-System/register_course.png)

![register_student](https://kennardwang.github.io/ImageSource/Online-Student-Grading-System/register_student.png)

<br>

+ Student Assignment Page ( AssignmentOverview.aspx, for student )

> After logging in as a student, you will enter into this page. For each course you have taken, you can see each of the assignment info ( weight, total question number, deadline, grade, submission state [ Y for yes/N for no ], teacher's comment ) and the ***GPA*** will be computed and displayed automatically.

![student_assignment](https://kennardwang.github.io/ImageSource/Online-Student-Grading-System/student_assignment.png)

<br>

+ Student Answer Page ( StudentAnswer.aspx, for student )

> In this page, students can see the details about their assignment answers or submit their answers. But if the student has submitted the answer before, he or she will not be allowed to update their answers again. The teacher's comment can also be seen in this page ( if has ).

![student_answer](https://kennardwang.github.io/ImageSource/Online-Student-Grading-System/student_answer.png)

------

### Physical Design
+ Class Diagram

> It is drawn by ***NClass 2.04***, we have 8 ***C#*** classes, corresponding to each front page shown before. For each class, I implement some event functions which can handle all the events ( such as ***Clicking***, ***DropdownList*** Changed, ***Text*** Changed, ***RadioButton*** Changed etc.) taking place in the current page.

![class_diagram](https://kennardwang.github.io/ImageSource/Online-Student-Grading-System/class_diagram.png)

<br>

+ ER Diagram 

  + In design phase, I firstly find the ***Student Entity*** and the ***Teacher Entity*** has the same attributes like name, password and email address, which reminds me to use ***ISA*** structure to represent.
  + And then, ***Course Entity*** records the course ID and the course name. It has both relationship with ***Student*** and ***Teacher***, that's why ***stuid*** and ***tid*** are foreign keys of ***Course***.
  + For ***Assignment Entity***, we set **aid*** as the primary key. This entity has lots of attributes but it still has a constraint with ***cid*** of ***Course***. By the way, ***Assignment Entity*** will store some important messages like assignment name, which course, how many questions does have, weight, and also deadline.
  + In ***Question Entity***, it records question content and the index of question, ***aid*** is a foreign key because I consider that many questions might be related to one assignment so that we can find the exact question if we know about the ***aid*** and the ***q_index***.
  + The ***Answer Entity*** has two foreign keys, one is ***qid*** and another is ***stuid*** because for the same question, we need to know which student has answered it. It is the reason why both foreign keys are necessarily required. Additionally, the content of student's answer and teacher's comment will be recorded, too.
  + The last entity is ***Submit Entity***, this entity stores the grade information, submission statement and teacher's comment about the whole assignment. ***Submit Entity*** has a relationship with ***Student*** and ***Assignment*** because it records all assignment information of each student.

![ER_Diagram](https://kennardwang.github.io/ImageSource/Online-Student-Grading-System/ER_Diagram.png)

<br>

+ Schema

![schema](https://kennardwang.github.io/ImageSource/Online-Student-Grading-System/schema.png)

------

### Features of Design
+ To be more realistic, I design a dual-login system for both teacher and student, the user can switch the login type to enter the system. After entering the system, the user can click ***logout*** button to back to the home page. 
+ I allow the user to take more than one courses and the system will display correct information corresponding to the selected course. 
+ Question number of each assignment is not fixed, teachers can add or delete questions if they want.
+ In ***StuOverview.aspx*** Page, teacher can reset student's login password directly by clicking ***Edit*** button and the data will be updated.
+ The bootstrap framework provides a user-friendly GUI design which is supported at most devices.

------

### Code Fragment
**Database Creation**

```
    -- create database
    CREATE DATABASE OSGS
    ON(
	    NAME='OSGS',
	    FILENAME='C:\EX\OSGS.mdf',
	    SIZE=17MB,
	    FILEGROWTH=5MB
    )
    
    LOG ON
    (	
	    NAME='OSGSLog',
	    FILENAME='C:\EX\OSGSLog.ldf',
	    SIZE=5MB,
	    FILEGROWTH=5MB
    )
```

**Table Creation**

```
    -- create table
    USE OSGS
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
	    stuid varchar(25) NOT NULL FOREIGN KEY REFERENCES 
	    Student(stuid),	
	    tid varchar(25) NOT NULL FOREIGN KEY REFERENCES 
	    Teacher(tid)
    )

    CREATE TABLE Assignment(
        aid INT NOT NULL PRIMARY KEY,
	    aname varchar(15) NOT NULL,
	    cid varchar(10) NOT NULL,
	    q_number INT NOT NULL DEFAULT 0,
	    [weight] INT NOT NULL,	
	    tid varchar(25) NOT NULL FOREIGN KEY REFERENCES 
	    Teacher(tid),
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
	    stuid varchar(25) NOT NULL FOREIGN KEY REFERENCES 
	    Student(stuid),
	    content varchar(100) DEFAULT NULL,
	    tcomment varchar(100) DEFAULT NULL
    )

    CREATE TABLE Submit(
        subid INT NOT NULL PRIMARY KEY,
	    aid INT NOT NULL FOREIGN KEY REFERENCES Assignment(aid),
	    stuid varchar(25) NOT NULL FOREIGN KEY REFERENCES 
	    Student(stuid),
	    grade real DEFAULT 0.0,
	    comment varchar(100) DEFAULT NULL,
	    stat varchar(1) NOT NULL DEFAULT 'N'
    )
```

**Data Update**

>  
    In StuOverview.aspx, the teacher can edit student's information:
```
    UPDATE Student
    SET sName = @sName, psw=@psw, emailAddress=@emailAddress
    WHERE stuid = @stuid
```

**Data Query**

> 
    I use the query of Assignment Management.aspx as an example:
    
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

>   
    We can see that all the columns totally involve 3 tables ( Assignment, Submit and Course ), so the first operation is definitely joining all three tables. And then, we need to check:

    1. The current teacher exactly teaches this course ( probably there are 2 teachers teach CS108 together ).
    2. The students exactly take the course of this teacher. 
    3. The result belongs to current selected course (if selected CS101, some of the students will miss).
    4. The submission is corresponding to those students.

**Data Insertion**
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
    sql_assign = "INSERT Assignment(aid, aname, cid, q_number, 
    [weight], tid, deadline) 
    VALUES(" + aid + ", '" + aname.Text + "', '" + cid.Text + 
    "', " + num.ToString() +", " + weight.Text +", '" + tid + 
    "', '" + ddl.Text +"')";
```
    
+ Insert Answer Table
```
    sql = "INSERT Answer(ansid, qid, stuid, content, tcomment) 
    VALUES(" + ansid.ToString() + ", " + qid_1 + ", '" + stuid 
    +"', '" + ans.Text + "', '')";
```
    
+ Insert Submit Table
```
    sql1 = "INSERT Submit(subid, aid, stuid, grade, comment, 
    stat) 
    VALUES(" + subid.ToString() + ", " + aid + ", '" +
    tmp[0].ToString() + "', 0.0, ' ', 'N')";
```
    
+ How to assign a new ID as primary key ( like new aid, qid, ansid, subid )
```
    // get the largest ansid
    sql = "SELECT TOP 1 ansid FROM Answer ORDER BY ansid DESC";
    ansid = int.Parse(sql_command(sql, con));
    
    ansid++; // a new ansid
```
    
+ In conclusion
> All the parameters of previous insertion methods can be divided into 3 types: new ids ( aid, qid, ansid, subid ), passed by Textbox ( has .Text ), passed by URL ( stuid or tid ). They all can be connected as String Type into SQL. 

------

### Development Environment

|     Description     |                    Specification                    |
| :-----------------: | :-------------------------------------------------: |
|       System        |                     Windows 10                      |
| Front-end Framework |                    ASP.NET 4.7.2                    |
|  Back-end Language  |                         C#                          |
|         IDE         |        Visual Studio Community 2019 v16.7.5         |
|    Database Tool    | SQL Server Management Studio ( SSMS ) v15.0.18358.0 |

------

### License  
+ [MIT License](https://github.com/KennardWang/Online-Student-Grading-System/blob/master/LICENSE)
------

### Author
+ Kennard Wang ( 2021.1.1 )
------
