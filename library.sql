create table loginTable(
id int NOT NULL IDENTITY(1,1) primary key,
username varchar(150) not null,
pass varchar(150) not null,
)

insert into loginTable (username,pass) values ('NgoPhanTamBao','abc') 
insert into loginTable (username,pass) values ('PhanQuocTri','abc') 
insert into loginTable (username,pass) values ('PhanPhuocNguyen','abc') 
insert into loginTable (username,pass) values ('1','1') 
insert into loginTable (username,pass) values ('2','2') 
insert into loginTable (username,pass) values ('3','3') 
insert into loginTable (username,pass) values ('4','4') 
insert into loginTable (username,pass) values ('5','5') 
insert into loginTable (username,pass) values ('6','6') 
insert into loginTable (username,pass) values ('7','7')  

select * from loginTable


create table NewBook(
bid int NOT NULL IDENTITY(1,1) primary key,
bName varchar (250) not null,
bAuthor varchar(250) not null,
bPubl varchar(250) not null,
bPDate varchar(250) not null,
bPrice bigint not null,
bQuan bigint not null,
)

insert into NewBook (bName, bAuthor, bPubl, bPDate, bPrice, bQuan) values ('Data Structure', 'JK Signgh kumar', 'R and D', 'Monday, April 20, 2020', '5000', '45') 
insert into NewBook (bName, bAuthor, bPubl, bPDate, bPrice, bQuan) values ('Oops', 'JK patel', 'rk publication', 'Monday, April 20, 2020', '800', '24')
insert into NewBook (bName, bAuthor, bPubl, bPDate, bPrice, bQuan) values ('Java', 'PK Singh', 'RK Publication', 'Monday, April 20, 2020', '532', '30')

select * from NewBook

Create table Student(
stt int NOT NULL Identity(1,1),
sname varchar(250) not null,
studentid varchar(250) primary key,
major varchar(250) not null,
semester varchar(250) not null,
contact bigint not null,
email varchar(250) not null,
)

insert into Student(sname, studentid, major, semester, contact, email) values ('TamBao', '2002123', 'CSE', '2', '999988887', 'abc@gmail.com') 
select * from Student

Create table IRBook(
id int NOT NULL IDENTITY(1,1) primary key,
std_id varchar(250) not null,
std_major varchar(250) not null,
std_sem varchar(250) not null,
std_contact bigint not null,
std_email varchar(250) not null,
book_name varchar(1250) not null,
book_issue_date varchar(250) not null,
book_return_date varchar(250),
);
select * from IRBook

select * from IRBook where std_id = '1234' and book_return_date IS NULL


