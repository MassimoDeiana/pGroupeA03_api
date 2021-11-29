use dbgroupeA03;

IF EXISTS (SELECT * FROM sysobjects WHERE name='course' and xtype='U')
DROP TABLE course;

IF EXISTS (SELECT * FROM sysobjects WHERE name='participatemeeting' and xtype='U')
DROP TABLE participatemeeting;

IF EXISTS (SELECT * FROM sysobjects WHERE name='note' and xtype='U')
DROP TABLE note;

IF EXISTS (SELECT * FROM sysobjects WHERE name='teacher' and xtype='U')
DROP TABLE teacher;


IF EXISTS (SELECT * FROM sysobjects WHERE name='student' and xtype='U')
DROP TABLE student;

IF EXISTS (SELECT * FROM sysobjects WHERE name='meeting' and xtype='U')
DROP TABLE meeting;

IF EXISTS (SELECT * FROM sysobjects WHERE name='schoolclass' and xtype='U')
DROP TABLE schoolclass;

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

create table student(
idstudent int identity primary key,
name varchar(50) not null,
firstname varchar(50) not null,
birthdate date not null,
mail nvarchar(50) not null,
idclass int not null
);

alter table student
add constraint fkstudentclass foreign key(idclass) references schoolclass(idclass);

create table course(
idcourse int identity,
day date not null,
hour time not null,
duration tinyint not null,
subject varchar(50) not null,
idteacher int not null foreign key(idteacher) references teacher(idteacher),
idclass int not null,
primary key(subject,day,hour)
);

alter table course
add constraint fkcourseclass foreign key(idclass) references schoolclass(idclass);

create table meeting(
idmeeting int identity,
subject varchar(50) not null,
primary key(idmeeting)
);

create table participatemeeting(
idmeeting int not null,
idteacher int not null foreign key(idteacher) references teacher(idteacher),
datemeeting date not null,
primary key(idmeeting,idteacher,datemeeting)
);

create table note(
idnote int identity,
idteacher int not null,
idstudent int not null foreign key(idstudent) references student(idstudent),
datenote datetime not null,
message varchar(80),
primary key(idteacher,idstudent,datenote),
);