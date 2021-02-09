DROP TABLE IF EXISTS Hold, Availability, AdvisementSession, Student, Advisor, Login

CREATE TABLE Login (
	username VARCHAR (15) NOT NULL PRIMARY KEY,
	password VARCHAR (20) NOT NULL
)

CREATE TABLE Advisor (
  advisorID INT NOT NULL IDENTITY PRIMARY KEY,
  firstName VARCHAR(45) NOT NULL,
  lastName VARCHAR(45) NOT NULL,
  isFacultyAdvisor BIT NOT NULL,
  email VARCHAR(45) NOT NULL UNIQUE,
  username VARCHAR (15) NOT NULL UNIQUE,
  gender VARCHAR (10),
  CONSTRAINT fk_advisor_username
    FOREIGN KEY (username)
    REFERENCES Login (username)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

CREATE TABLE Student (
  studentID INT NOT NULL IDENTITY PRIMARY KEY,
  firstName VARCHAR(45) NOT NULL,
  lastName VARCHAR(45) NOT NULL,
  email VARCHAR(45) NOT NULL UNIQUE,
  advisorGeneralID INT NOT NULL,
  advisorFacultyID INT NOT NULL,
  username VARCHAR (15) NOT NULL UNIQUE,
  gender VARCHAR (10),
  CONSTRAINT fk_student_advisorGeneralID
    FOREIGN KEY (advisorGeneralID)
    REFERENCES Advisor (advisorID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_student_advisorFacultyID
    FOREIGN KEY (advisorFacultyID)
    REFERENCES Advisor (advisorID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_student_username
    FOREIGN KEY (username)
    REFERENCES Login (username)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

CREATE TABLE Hold (
  holdID INT NOT NULL IDENTITY PRIMARY KEY,
  reason VARCHAR(100) NULL,
  dateAdded DATETIME2(0) NOT NULL,
  isActive BIT NOT NULL,
  studentID INT UNIQUE NOT NULL,
  CONSTRAINT fk_hold_studentID
    FOREIGN KEY (studentID)
    REFERENCES Student (studentID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

CREATE TABLE AdvisementSession (
  sessionID INT NOT NULL IDENTITY PRIMARY KEY,
  studentID INT NOT NULL,
  advisorID INT NOT NULL,
  sessionDate DATETIME2(0) NOT NULL UNIQUE,
  stage SMALLINT NOT NULL,
  completed BIT NOT NULL,
  notes VARCHAR(2000) NULL,
  CONSTRAINT fk_session_studentID
    FOREIGN KEY (studentID)
    REFERENCES Student (studentID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_session_advisorID
    FOREIGN KEY (advisorID)
    REFERENCES Advisor (advisorID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

CREATE TABLE Availability (
  availabilityID INT NOT NULL IDENTITY PRIMARY KEY,
  timeBegin DATETIME2(0) NOT NULL,
  timeEnd DATETIME2(0) NOT NULL,
  advisorID INT NOT NULL,
  CONSTRAINT fk_availability_advisorID
    FOREIGN KEY (advisorID)
    REFERENCES Advisor (advisorID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

INSERT INTO Login(username, password) VALUES
('wkala', 's3cret'),
('terichsen', 'password1'),
('bhart', 'p@$$w0rD1234'),
('jothewood', 'password1'),
('gsmith', 'password1'),
('hHill', 'password1'),
('kSmith', 'password1'),
('jWood', 'password1'),
('dMcCollum', 'password1'),
('bThatcher', 'password1'),
('hAnderson', 'password1'),
('cBrooks', 'password1')

INSERT INTO Advisor (firstName, lastName, isFacultyAdvisor, email, username, gender) VALUES
('Wilman', 'Kala', 0, 'wkala@askj.net', 'wkala', 'male'),
('Tom', 'Erichsen', 1, 'terichsen@askj.net', 'terichsen', 'male'),
('Jenny', 'Othewood', 0, 'jothewood@askj.net', 'jothewood', 'female'),
('Bob', 'Hart', 0, 'bhart@askj.net', 'bhart', 'male'),
('Gina', 'Smith', 1, 'gsmith@askj.net', 'gsmith', 'female')

INSERT INTO Student (firstName, lastName, email, advisorGeneralID, advisorFacultyID, username, gender) VALUES
('Hank', 'Hill', 'hhill@my.askj.net', 1, 2, 'hHill', 'male'),
('Katie', 'Smith', 'ksmith@my.askj.net', 1, 2, 'kSmith', 'female'),
('Jerry', 'Wood', 'jwood@my.askj.net', 2, 5, 'jWood', 'male'),
('Derek', 'McCollum', 'dwilson@my.askj.net', 3, 5, 'dMcCollum', 'male'),
('Brenda', 'Thatcher', 'btchatch@my.askj.net', 3, 5, 'bThatcher', 'female'),
('Harry', 'Anderson', 'handerson@my.askj.net', 4, 2, 'hAnderson', 'male'),
('Cody', 'Brooks', 'cbrooks@my.askj.net', 5, 2, 'cBrooks', 'male')

INSERT INTO Hold (reason, dateAdded, isActive, studentID) VALUES
('registration', '1-16-2021', 1, 1),
('fees not paid', '12-20-2020', 1, 2),
('advisement', '11-20-2020', 1, 3),
('need to meet with dept advisor', '1-16-2021', 1, 4),
('need to meet with faculty advisor', '1-16-2021', 1, 5),
('ready to register', '1-16-2021', 1, 6),
('need to meet with faculty advisor', '1-16-2021', 1, 7)

INSERT INTO AdvisementSession (studentID, advisorID, sessionDate, stage, completed, notes) VALUES
(1, 1, '11-16-2020', 0, 0, 'Works full time this semester'),
(2, 3, '11-22-2020', 0, 0, 'Trying to stay under 16 credit hours'),
(4, 3, '11-30-2020', 0, 0, '')

INSERT INTO Availability (timeBegin, timeEnd, advisorID) VALUES
('2020-11-23 07:30:00', '2020-11-23 10:00:00', 1),
('2020-11-23 09:30:00', '2020-11-23 12:15:00', 2),
('2020-11-23 13:00:00', '2020-11-23 16:45:00', 3),
('2020-11-23 10:30:00', '2020-11-23 11:45:00', 3),
('2020-11-23 12:30:00', '2020-11-23 14:00:00', 3),
('2020-11-23 07:30:00', '2020-11-23 11:30:00', 4),
('2020-11-23 13:00:00', '2020-11-23 15:45:00', 5)