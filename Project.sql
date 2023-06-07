create database project
--------DATABASE OF PROJECT------------------
----Student Management System--------------------------
----I have 7 tables in my database----------
--Batch----
--Std_Reg---
--Course---
--StdInfo----
--teacher---
---Users----
--ExamInfo------
==================================================================================================================

Create table Student_Registration
(
Id int not null,
FirstName varchar(20),
LastName varchar(20) ,
Email varchar(20),
TeleNo varchar(20),
CreateDate date,
DeleteDate date,
IsActive bit,
Primary key (Id),
Course_id int Foreign Key references Course(Id),
Batch_id int Foreign Key references Batch(Id),
);

alter table Student_Registration
add  Batch_id int Foreign Key references Batch(Id)

select * from Student_Registration

select * from Users
drop column Batch_id

select * from Student_Registration
=========================================================================================================

Create table Course
(Id int not null,
CourseName varchar(30),
Duration varchar(30),
CreateDate date,
DeleteDate date,
IsActive bit,
Primary key (Id),
);
select * from Course
==========================================================================================================

create table teacher(
Id int primary key not null,
TeacherName varchar(50) unique,
CourseName1 varchar(50),
CourseName2 varchar(50),
CourseName3 varchar(50),
Total_Duration varchar(50),
)

select * from teacher
insert into teacher values (1,'Hassan','Oop','DBMS','PF','12')
insert into teacher values (2,'Zubair','Oop','DBMS','PF','12')
drop table Course
drop table Student_Registration

=============================================================================================================

Create table Batch(
Id int not null,
Primary key (Id),
Batch varchar(20),
Year varchar(20),
IsActive bit,
);
=============================================================================================================
select * from Course

Create table Users
(Id int not null,
UserName varchar(30) unique,
FirstName varchar(30)unique,
LastName varchar (30)unique,
Password varchar(30),
Primary key (Id),
);
Select * from Users

Select * from Course
===================================================================================================================

Create table Exam__Info
(
Id int not null,
Primary key (Id),
Exam_Name varchar(30),
RoomNo int,
Teacher_Name varchar(30),
);

====================================================================================================================

----------TRIGGERS-----------------
------IN DATABASE-------------------

--DDL trigger(insert-update-del)
--after
--instead of

--SHOw table--\\

=======================================================================================================================

create table ShowInfo
(
id int primary key identity,
ShowInfo varchar(max)
);
select * from ShowInfo  
======================================================================================================================
--DDL trigger(create,alter,drop_)

----Insert Trigger---------

create trigger Tr_std_Reg
on
Student_Registration
after insert
as
begin
Declare @id int
select @id = id from inserted
insert into ShowInfo
values('depart with id  ' +CAST( @id as varchar(50))+ 'Is Inserted' + CAST(GETDATE() as varchar(50)));
end
insert into

========================================================================================================================

-------DELETED Trigger-----------------

create trigger tr_Std_deleted
on Student_Registration
after delete
as
begin
Declare @id int
select @id = id from deleted
insert into ShowInfo
values('depart with id  ' +CAST( @id as varchar(50))+ 'Is Deleted' + CAST(GETDATE() as varchar(50)));
end

========================================================================================================================

--------RISTRICTION ON DB-----------
----create,alter delete-------------

create trigger tr_ddl_create1
on database 
for CREATE_TABLE
as
begin
rollback
print 'You cannot create table';
end
----------------UPDATE-================================
=====================================================================================================================
create trigger tr_Update_Reg
on Student_Registration
after update
as 
begin
select*from inserted
select*from deleted
end
================================================================================================================
create trigger tr_Update_Course
on Course
after update
as 
begin
select*from inserted
select*from deleted
end


disable trigger   tr_ddl_create on database

select * from Exam__Info

-----UPDATE-------------------

create trigger tr_Update
on Student_Registration
after update
as 
begin
select*from inserted
select*from deleted
end
=======================================================================================================================
update  Student_Registration set FirstName= 'Khan' where Id =2
=======================================================================================================================
----------Stored Procedure----------------------

create procedure sp_reg
as
begin
Select FirstName , LastName, Email ,TeleNo  from Student_Registration
end
------Execuion------------------
sp_reg
=============================================================================
create procedure sp_Course
as
begin
Select CourseName , Duration  from Course
end
------Execuion------------------
sp_Course
============================================================================================

create procedure sp_teacher
as
begin
Select TeacherName , Total_Duration  from teacher
end
------Execuion------------------
sp_teacher
========================================================================================================================
-------------------------------------------------------------------
-----Input Output Procedure by full join-------------------------------

create procedure Sp_reg_Join
 as
 begin
select  FirstName ,LastName, CourseName From Student_Registration
full join Course on 
Student_Registration.FirstName = Course.CourseName
end

------Execuion------------------
Sp_reg_Join
=======================================================================================================================


---------BRIDGE TABLE----------------------

create table std_Info
(id int primary key identity,
 Batch_id int Foreign Key references Batch(Id),
 Course_id int Foreign Key references Course(Id),
)
select * from std_Info
select* from ShowInfo
==========================================================================================================================
create table abc1(
name varchar(50)
)
drop database project