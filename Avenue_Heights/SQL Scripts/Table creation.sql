use [Avenue-Workflow]

CREATE TABLE IterationType
(
	IterationTypeID int not null identity(1,1) CONSTRAINT PK_ITERATIONTYPE_ITERATIONTYPEID PRIMARY KEY (ITERATIONTYPEID),
	IterationTypeName varchar(20) not null
)

[dbo].[sp_Create_StoredProcedures_ave] IterationType

CREATE TABLE StoryType
(
	StoryTypeID int not null identity(1,1) CONSTRAINT PK_STORYTYPE_STORYTYPEID PRIMARY KEY (STORYTYPEID),
	StoryTypeName varchar(20) not null
)

[dbo].[sp_Create_StoredProcedures_ave] StoryType

CREATE TABLE TaskStatus
(
	TaskStatusID int not null identity(1,1) CONSTRAINT PK_TASKSTATUS_TASKSTATUSID PRIMARY KEY (TASKSTATUSID),
	TaskStatusName varchar(20) not null
)

[dbo].[sp_Create_StoredProcedures_ave] TaskStatus

CREATE TABLE Theme
(
	ThemeID int not null identity(1,1) CONSTRAINT PK_THEME_THEMEID PRIMARY KEY (THEMEID),
	ThemeName varchar(20) not null
)

[dbo].[sp_Create_StoredProcedures_ave] Theme

CREATE TABLE [User]
(
	UserID int not null identity(1,1) CONSTRAINT PK_USER_USERID PRIMARY KEY (USERID),
	UserFirstName varchar(20),
	UserLastName varchar(30) not null,
	UserName varchar(50) not null,
	UserEmail varchar(50) not null,
	UserThemeID int not null CONSTRAINT FK_USER_USERTHEMEID FOREIGN KEY (USERTHEMEID) REFERENCES THEME(THEMEID),
	UserAspNetMembership uniqueidentifier,
	UserPicture varbinary
)

[dbo].[sp_Create_StoredProcedures_ave] [User]

CREATE TABLE Iteration
(
	IterationID int not null identity(1,1) CONSTRAINT PK_ITERATION_ITERATIONID PRIMARY KEY (ITERATIONID),
	IterationDescription varchar(50) not null,
	IterationTypeID int not null CONSTRAINT FK_ITERATIONTYPE_ITERATIONTYPEID FOREIGN KEY (ITERATIONTYPEID) REFERENCES ITERATIONTYPE(ITERATIONTYPEID),
	DefaultIterationTimePeriod int,
	IterationOwner int not null CONSTRAINT FK_ITERATION_ITERATIONOWNER FOREIGN KEY (ITERATIONOWNER) REFERENCES [USER](USERID)
)

[dbo].[sp_Create_StoredProcedures_ave] Iteration

CREATE TABLE UserIteration
(
	UserIterationID int not null identity(1,1) CONSTRAINT PK_USERITERATION_USERITERATIONID PRIMARY KEY (USERITERATIONID),
	UserID int not null CONSTRAINT FK_USERITERATION_USERID FOREIGN KEY (USERID) REFERENCES [USER](USERID),
	IterationID int not null CONSTRAINT FK_USERITERATION_ITERATIONID FOREIGN KEY (ITERATIONID) REFERENCES ITERATION(ITERATIONID)

	CONSTRAINT CONS_USERITERATION_USERID_ITERATIONID UNIQUE(USERID, ITERATIONID)
)

[dbo].[sp_Create_StoredProcedures_ave] UserIteration

CREATE TABLE IterationTimePeriod
(
	IterationTimePeriodID int not null identity(1,1) CONSTRAINT PK_ITERATIONTIMEPERIOD_ITERATIONTIMEPERIODID PRIMARY KEY (ITERATIONTIMEPERIODID),
	IterationID int not null CONSTRAINT FK_ITERATIONTIMEPERIOD_ITERATIONID FOREIGN KEY (ITERATIONID) REFERENCES ITERATION(ITERATIONID),
	IterationTimePeriodStartDate datetime not null,
	IterationTimePeriodEndDate datetime not null
)

[dbo].[sp_Create_StoredProcedures_ave] IterationTimePeriod

CREATE FUNCTION [dbo].[ave_CheckDateOverlap]
(
  @TableRowId AS INT,
  @DateStart AS DATETIME,
  @DateEnd AS DATETIME
)
RETURNS BIT 
AS
BEGIN
  DECLARE @retval BIT
  /* date range at least one day */
  IF (DATEDIFF(week,@DateStart,@DateEnd) < 1)
    BEGIN
      SET @retval=0
    END
  ELSE
    BEGIN
      IF EXISTS
        (
          SELECT
              *
            FROM [dbo].[IterationTimePeriod]
            WHERE
                @TableRowId <> IterationTimePeriodID
                AND (@DateEnd not between IterationTimePeriodStartDate And IterationTimePeriodEndDate)
                AND (@DateStart not between IterationTimePeriodStartDate And IterationTimePeriodEndDate)
        )
        BEGIN
          SET @retval=0
        END
    ELSE
      BEGIN
        SET @retval=1
      END
    END
  RETURN @retval
END

ALTER TABLE IterationTimePeriod WITH CHECK ADD CONSTRAINT CHK_ITERATIONTIMEPERIOD_DATEOVERLAP CHECK ([dbo].[ave_CheckDateOverlap] (IterationTimePeriodID, IterationTimePeriodStartDate, IterationTimePeriodEndDate) <> (0)) 


CREATE TABLE Story
(
	StoryID int not null identity(1,1) CONSTRAINT PK_STORY_STORYID PRIMARY KEY (STORYID),
	IterationID int not null CONSTRAINT FK_STORY_ITERATIONID FOREIGN KEY (ITERATIONID) REFERENCES ITERATION(ITERATIONID),
	IterationTimePeriodID int CONSTRAINT FK_STORY_ITERATIONTIMEPERIODID FOREIGN KEY (ITERATIONTIMEPERIODID) REFERENCES ITERATIONTIMEPERIOD(ITERATIONTIMEPERIODID),
	StoryDescription varchar(30) not null,
	StoryTypeID int not null CONSTRAINT FK_STORY_STORYTYPEID FOREIGN KEY (STORYTYPEID) REFERENCES STORYTYPE(STORYTYPEID)
)

[dbo].[sp_Create_StoredProcedures_ave] Story

CREATE TABLE Task
(
	TaskID int not null identity(1,1) CONSTRAINT PK_TASK_TASKID PRIMARY KEY (TASKID),
	StoryID int not null CONSTRAINT FK_TASK_STORYID FOREIGN KEY (STORYID) REFERENCES STORY(STORYID),
	TaskDescription varchar(30) not null,
	TaskStartDate datetime,
	TaskEndDate datetime,
	TaskEstimatedTime decimal,
	TaskClockedTime decimal,
	TaskStatusID int not null, CONSTRAINT FK_TASK_TASKSTATUSID FOREIGN KEY (TASKSTATUSID) REFERENCES TASKSTATUS(TASKSTATUSID),
	TaskAssignedUser int not null CONSTRAINT FK_TASK_TASKASSIGNEDUSER FOREIGN KEY (TASKASSIGNEDUSER) REFERENCES [USER](USERID)
)

[dbo].[sp_Create_StoredProcedures_ave] Task