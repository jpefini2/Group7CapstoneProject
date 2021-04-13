DROP TABLE IF EXISTS Notification, Availability, AdvisementSession, Hold, Student, Advisor, LoginSession, Login

CREATE TABLE Login (
	username VARCHAR (15) NOT NULL PRIMARY KEY,
	passwordHash VARCHAR (60) NOT NULL
)

CREATE TABLE LoginSession (
	username VARCHAR(15) NOT NULL PRIMARY KEY,
	sessionKey VARCHAR (60) NOT NULL,
	expirationDate DATETIME2(0)
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
  holdID INT NOT NULL,
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
    ON UPDATE NO ACTION,
  CONSTRAINT fk_session_holdID
    FOREIGN KEY (holdID)
    REFERENCES Hold (holdID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

CREATE TABLE Availability (
  availabilityID INT NOT NULL IDENTITY PRIMARY KEY,
  dayOfTheWeek INT NOT NULL,
  timeBegin TIME(0) NOT NULL,
  timeEnd TIME(0) NOT NULL,
  advisorID INT NOT NULL,
  CONSTRAINT fk_availability_advisorID
    FOREIGN KEY (advisorID)
    REFERENCES Advisor (advisorID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

CREATE TABLE Notification (
	notificationID INT NOT NULL IDENTITY PRIMARY KEY,
	notifMessage VARCHAR(200) NOT NULL,
    isRemovedFromAdvisor BIT NOT NULL,
	isRemovedFromStudent BIT NOT NULL,
	studentID INT NOT NULL,
	advisorID INT NOT NULL,
  CONSTRAINT fk_notification_studentID
    FOREIGN KEY (studentID)
    REFERENCES Student (studentID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_notification_advisorID
    FOREIGN KEY (advisorID)
    REFERENCES Advisor (advisorID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

INSERT INTO Login(username, passwordHash) VALUES
('wkala', '$2a$12$bHDDjza0WCythx2A7kndf.8C7tH9ZX9Iu0Hq7oaxlNd8ETUL8V3mq'), 			/* s3cret */
('terichsen', '$2a$12$vM8iaJbPvt8z6VHq5AJauOoQiT485WcTerMmUTYH6eVhYIzhSKgrO'), 		/* password1 */
('bhart', '$2a$12$z7PkhUJcfmI/75USop3Dw.CKwdihcUcnTGW/aykwo8LfVTKFbQFma'), 			/* password1 */
('jothewood', '$2a$12$NRWFs2u34PrOPPz8CzIoYuQwXH3xbxZRHvrPUXaBAM7uOjolvb0KC'), 		/* password1 */
('gsmith', '$2a$12$jnd03xkWPH.8JZcYf1nNC.Z/RmpYV5q3VsmRqYjumwLryMHMfBfDS'), 		/* password1 */
('fadvisor', '$2a$12$jnd03xkWPH.8JZcYf1nNC.Z/RmpYV5q3VsmRqYjumwLryMHMfBfDS'), 		/* password1 */
('dadvisor', '$2a$12$jnd03xkWPH.8JZcYf1nNC.Z/RmpYV5q3VsmRqYjumwLryMHMfBfDS'), 		/* password1 */
('hHill', '$2a$12$IjltwHUl7WTdjzEbbfoIgOd1HAWaVGxTfPr9w.t4BLPtNs1kNfFSe'), 			/* password1 */
('kSmith', '$2a$12$NRWFs2u34PrOPPz8CzIoYuQwXH3xbxZRHvrPUXaBAM7uOjolvb0KC'), 		/* password1 */
('jWood', '$2a$12$9CrXSNd7Yt.lM10X4dOnqeJcsWL50Id.FKv5Uv6smnyU9v7MyJMqO'), 			/* p@ssw0rd */
('dMcCollum', '$2a$12$VvHlMGYNoTlZbmBgVmIcGuiujku7W4.ufHbK47jt7NGINwWtFVOPS'), 		/* password1234 */
('bThatcher', '$2a$12$jKNkgEtMuKzgKgbUSFc9YONZiLk.k4N8nIeAEbEbkU7iKjNW3mSeW'), 		/* sup3r_s3cret*/
('hAnderson', '$2a$12$ggkjrW0zrgiMlNUvB/ahX.sckqEvrRNrglqvqZOfzVynaFirLjWVq'), 		/* p@rr0ts */
('cBrooks', '$2a$12$l/qvNATBroETbbfbcgJffeZES/auRjV3vPBy60K0hQctxOpHVFDpK'),		/* password2 */
('student', '$2a$12$l/qvNATBroETbbfbcgJffeZES/auRjV3vPBy60K0hQctxOpHVFDpK'),		/* password2 */
('jmcconn1', '$2a$12$l/qvNATBroETbbfbcgJffeZES/auRjV3vPBy60K0hQctxOpHVFDpK') 		/* password2 */



INSERT INTO Advisor (firstName, lastName, isFacultyAdvisor, email, username, gender) VALUES
('Wilman', 'Kala', 0, 'wkala@askj.net', 'wkala', 'male'),
('Tom', 'Erichsen', 1, 'terichsen@askj.net', 'terichsen', 'male'),
('Jenny', 'Othewood', 0, 'jothewood@askj.net', 'jothewood', 'female'),
('Bob', 'Hart', 0, 'bhart@askj.net', 'bhart', 'male'),
('Gina', 'Smith', 1, 'gsmith@askj.net', 'gsmith', 'female'),
('Department', 'Advisor', 0, 'advisementmanager@gmail.com', 'dadvisor', 'female'),
('Faculty', 'Advisor', 1, 'fadvisor@askj.net', 'fadvisor', 'female')

INSERT INTO Student (firstName, lastName, email, advisorGeneralID, advisorFacultyID, username, gender) VALUES
('Hank', 'Hill', 'hhill@my.askj.net', 1, 2, 'hHill', 'male'),
('Katie', 'Smith', 'ksmith@my.askj.net', 1, 2, 'kSmith', 'female'),
('Jerry', 'Wood', 'jwood@my.askj.net', 3, 5, 'jWood', 'male'),
('Derek', 'McCollum', 'dwilson@my.askj.net', 3, 5, 'dMcCollum', 'male'),
('Brenda', 'Thatcher', 'btchatch@my.askj.net', 3, 5, 'bThatcher', 'female'),
('Harry', 'Anderson', 'handerson@my.askj.net', 4, 2, 'hAnderson', 'male'),
('Cody', 'Brooks', 'cbrooks@my.askj.net', 4, 2, 'cBrooks', 'male'),
('Student', 'Student', 'studen@my.askj.net', 6, 7, 'student', 'male'),
('jmcconn1', 'justin', 'jmcconn1@my.westga.edu', 6, 7, 'jmcconn1', 'male')

INSERT INTO Hold (reason, dateAdded, isActive, studentID) VALUES
('need to meet with faculty advisor', '1-16-2021', 1, 1),
('waiting for hold to be removed', '12-20-2020', 1, 2),
('need to meet with dept advisor', '11-20-2020', 1, 3),
('need to meet with dept advisor', '1-16-2021', 1, 4),
('need to meet with faculty advisor', '1-16-2021', 1, 5),
('need to meet with dept advisor', '1-16-2021', 1, 6),
('need to meet with faculty advisor', '1-16-2021', 1, 7),
('need to meet with dept advisor', '12-26-2020', 1, 8),
('need to meet with dept advisor', '1-28-2021', 1, 9)

INSERT INTO Availability (dayOfTheWeek, timeBegin, timeEnd, advisorID) VALUES
(1, '07:30:00', '10:00:00', 1),
(2, '09:30:00', '12:15:00', 2),
(4, '13:00:00', '16:45:00', 3),
(6, '10:30:00', '11:45:00', 3),
(2, '12:30:00', '14:00:00', 3),
(3, '07:30:00', '11:30:00', 4),
(7, '13:00:00', '15:45:00', 5)
