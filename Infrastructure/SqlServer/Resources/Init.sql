use dbgroupeA03;

IF EXISTS (SELECT * FROM sysobjects WHERE name='note' and xtype='U')
DROP TABLE note;

IF EXISTS (SELECT * FROM sysobjects WHERE name='interrogation' and xtype='U')
DROP TABLE interrogation;

IF EXISTS (SELECT * FROM sysobjects WHERE name='participatemeeting' and xtype='U')
DROP TABLE participatemeeting;

IF EXISTS (SELECT * FROM sysobjects WHERE name='course' and xtype='U')
DROP TABLE course;

IF EXISTS (SELECT * FROM sysobjects WHERE name='student' and xtype='U')
DROP TABLE student;

IF EXISTS (SELECT * FROM sysobjects WHERE name='schoolclass' and xtype='U')
DROP TABLE schoolclass;

IF EXISTS (SELECT * FROM sysobjects WHERE name='meeting' and xtype='U')
DROP TABLE meeting;

IF EXISTS (SELECT * FROM sysobjects WHERE name='teacher' and xtype='U')
DROP TABLE teacher;




create table teacher(
idteacher int identity primary key,
name varchar(50) not null,
firstname varchar(50) not null,
birthdate date not null,
mail nvarchar(50) not null,
password nvarchar(50) not null,
);

create table schoolclass(
idclass int identity primary key,
name varchar(4) not null,
year tinyint not null,
nbstudent int not null
);

create table meeting(
idmeeting int identity primary key,
subject varchar(50) not null,
starttime datetime not null,
endtime datetime not null
);

create table student(
idstudent int identity primary key,
name varchar(50) not null,
firstname varchar(50) not null,
birthdate date not null,
mail nvarchar(50) not null,
password nvarchar(50) not null,
idclass int not null foreign key(idclass) references schoolclass(idclass)
);

create table course(
idcourse int identity primary key,
starttime datetime not null,
endtime datetime not null,
subject varchar(50) not null,
idteacher int not null foreign key(idteacher) references teacher(idteacher),
idclass int not null foreign key(idclass) references schoolclass(idclass),
);


create table participatemeeting(
idmeeting int not null foreign key(idmeeting) references meeting(idmeeting),
idteacher int not null foreign key(idteacher) references teacher(idteacher),
datemeeting date not null,
primary key(idmeeting,idteacher,datemeeting)
);

create table interrogation(
idinterro int identity primary key,
idcourse int not null foreign key(idcourse) references course(idcourse),
subject varchar(50) not null,
total int not null,
);

create table note(
idnote int identity primary key,
idteacher int not null foreign key(idteacher) references teacher(idteacher),
idstudent int not null foreign key(idstudent) references student(idstudent),
idinterro int not null foreign key(idinterro) references interrogation(idinterro),
datenote datetime not null,
result float not null,
message varchar(80),
);