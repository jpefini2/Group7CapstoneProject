CREATE TABLE UserProfile (
  profileID INT NOT NULL IDENTITY PRIMARY KEY,
  firstName VARCHAR(45) NOT NULL,
  lastName VARCHAR(45) NOT NULL,
  email VARCHAR(45) NOT NULL UNIQUE,
  picturePath VARCHAR(45) NULL,
  gender VARCHAR(10) NULL
)

CREATE TABLE Advisor (
  advisorID INT NOT NULL IDENTITY PRIMARY KEY,
  firstName VARCHAR(45) NOT NULL,
  lastName VARCHAR(45) NOT NULL,
  isFacultyAdvisor SMALLINT NOT NULL,
  profileID INT NOT NULL,
  email VARCHAR(45) NOT NULL UNIQUE,
  CONSTRAINT fk_advisor_profileID
    FOREIGN KEY (profileID)
    REFERENCES UserProfile (profileID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

CREATE TABLE Student (
  studentID INT NOT NULL IDENTITY PRIMARY KEY,
  first_name VARCHAR(45) NOT NULL,
  last_name VARCHAR(45) NOT NULL,
  email VARCHAR(45) NOT NULL UNIQUE,
  advisorGeneralID INT NOT NULL,
  advisorFacultyID INT NOT NULL,
  profileID INT NOT NULL,
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
  CONSTRAINT fk_student_profileID
    FOREIGN KEY (profileID)
    REFERENCES UserProfile (profileID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

CREATE TABLE Hold (
  holdID INT NOT NULL IDENTITY PRIMARY KEY,
  reason VARCHAR(100) NULL,
  dateAdded DATETIME2(0) NOT NULL,
  isActive SMALLINT NOT NULL,
  studentID INT NOT NULL,
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
  completed SMALLINT NOT NULL,
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

CREATE TABLE Notification (
  notificationID INT NOT NULL IDENTITY PRIMARY KEY,
  message VARCHAR(500) NOT NULL,
  profileID INT NOT NULL,
  CONSTRAINT fk_notification_profileID
    FOREIGN KEY (profileID)
    REFERENCES UserProfile (profileID)
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