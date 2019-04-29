	create database Utkrishta_StickyNotes;
 
	use Utkrishta_StickyNotes;

	create table UserType
	(
		UserTypeID int identity(1,1) not null,
		UserTypeName varchar(10),
		constraint pk_UserTypeID primary key(UserTypeID)
	);

	insert into UserType values('Admin');
	insert into UserType values('User');
	select * from UserType

	
	create table Users
	(
		UserID int identity(1,1) not null,
		FirstName varchar(25),
		LastName varchar(25),
		UAddress varchar(30),
		PhoneNumber varchar(25),
		Gender varchar(6),
		Username varchar(15),
		UPassword varchar(15),
		UserTypeID int, 
		constraint pk_UserID primary key(UserID),
		constraint fk_UserTypeID foreign key(UserTypeID) references UserType
	);	


	select * from Users


	create table Category
	(
		CategoryID int identity(1,1) not null,
		CategoryType varchar(30),
		UserID int,
		constraint pk_CategoryID primary key(CategoryID),
		constraint fk_UserID foreign key(UserID) references Users  on delete cascade
	);

	select * from Category;

	delete from Category where CategoryID=2;

	create table Notes
	(
		NoteID int identity(1,1) not null,
		DateCreated date,
		Title varchar(30),
		Contents varchar(255),
		Sticked bit,
		Completed bit,
		UserID int,
		CategoryID int,
		constraint pk_NoteID primary key(NoteID),
		constraint fk_User_ID foreign key(UserID) references Users ,
		constraint fk_Category_ID foreign key(CategoryID) references Category on delete cascade
	);

	select Count(NoteID) from Notes where UserID=1;
		select * from Notes where UserID=2;
			update Notes set Completed=0 where NoteID=4;
				select top 2 * from Users order by userid desc;

			select Count(NoteID) from Notes where Title like '%haha%' and UserID=1; 

select u.UserID,u.FirstName,u.LastName,u.UAddress,u.PhoneNumber,u.Gender,u.Username,u.UPassword,ut.UserTypeName from Users u,UserType ut where u.UserTypeID=ut.UserTypeID and Username='Utkrishta';
select * from Users;


select n.DateCreated,n.Title,n.Contents,n.Sticked,n.Completed,c.CategoryType from Notes n,Category c, Users u where n.CategoryID=c.CategoryID and UserID=1;



 SELECT * FROM Notes WHERE Contents like '%"+ a +"%' and UserID=1;

 select NoteID from Notes where Title like '%ha%' and  UserID=1;

 select (Completed) from Notes where DateCreated>='2017-07-13' and DateCreated<='2018-07-13' and UserID=3;
  select (Completed) from Notes where DateCreated='2018-07-14' and UserID=3;
 delete from Category where CategoryID=2;

 select COUNT(Completed) from Notes Where Completed=1 and UserID=3