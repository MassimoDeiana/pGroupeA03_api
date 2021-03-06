set language us_english;
insert into teacher(name,firstname,birthdate,mail,password) values ('Roland','Thierry','2001-11-14','ThierryRoland@gmail.com', 'password1'),
                                                                   ('Deiana','Massimo','1999-09-15','MassimoDeiana@gmail.com', 'password2'),
                                                                   ('Dugauquier','Dylan','1999-05-27','DylanDugauquier@gmail.com', 'password3');

insert into schoolclass(name,year,nbstudent) values ('1A',1,10),('1B',1,15),('2A',2,9);

insert into student(name,firstname,birthdate,mail,password,idclass) values ('Vincart','Stany','2000-11-04','StanyVincart@gmail.com','password1',3),
                                                                           ('Debuyschere','Adrien','2002-02-04','AdrienD@gmail.com','password2',1),
                                                                           ('Lixon','Allan','2001-07-11','AllanLixon@gmail.com','password2',3);

insert into meeting(subject,starttime,endtime) values ('Data training', '2021-10-04T16:00:00','2021-10-04T18:00:00');

insert into lesson(subject) values ('POO'),
                                   ('ACP'),
                                   ('CPP'),
                                   ('TDD');

insert into course(idlesson,starttime,endtime,idteacher,idclass) values (1,'2021-12-10T13:00:00','2021-12-10T15:00:00',1,1),
                                                                       (2,'2021-12-10T15:30:00','2021-12-10T17:00:00',2,2),
                                                                       (3,'2021-12-10T09:00:00','2021-12-10T11:00:00',3,1);

insert into interrogation(idteacher,idlesson,subject,total) values (1, 1,'Matrix',20),
                                                         (1, 2,'Aggregation',38),
                                                         (2, 3, 'Ajax',10);

insert into note(idteacher,idstudent,idinterro,datenote,result,message) values (1,3,1,'2021-10-12', 3, 'Bad'),
                                                                               (1,3,2,'2021-12-10', 4, 'Keep going !'),
                                                                               (1,3,3,'2021-10-12', 5, 'Above average'),
                                                                               (1,1,1,'2021-10-12', 3, 'Bad'),
                                                                               (1,1,2,'2021-12-10', 4, 'Keep going !'),
                                                                               (1,1,3,'2021-10-12', 5, 'Above average');

insert into admin(mail,password) values ('OrlandoPalermo@gmail.com','password1');

insert into participatemeeting(idmeeting,idteacher) values(1,1);
                                                          