create database DemoDatabase;

CREATE TABLE "Surveys" (
    "Id" uuid NOT NULL,
    "Title" text NOT NULL,
    "Description" character varying(255) NULL,
    "CreatedAt" timestamp with time zone NOT NULL DEFAULT now(),
    "StartDate" timestamp with time zone NOT NULL DEFAULT now(),
    "EndDate" timestamp with time zone NOT NULL DEFAULT now(),
    CONSTRAINT "PK_Surveys" PRIMARY KEY ("Id")
);

CREATE TABLE "Interviews" (
    "Id" uuid NOT NULL,
    "InterviewDate" timestamp with time zone NOT NULL DEFAULT now(),
    "SurveyId" uuid NOT NULL,
    CONSTRAINT "PK_Interviews" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Interviews_Surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "Surveys" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Results" (
    "Id" uuid NOT NULL,
    "InterviewId" uuid NOT NULL,
    "Answer" text NOT NULL,
    CONSTRAINT "PK_Results" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Results_Interviews_InterviewId" FOREIGN KEY ("InterviewId") REFERENCES "Interviews" ("Id")  ON DELETE CASCADE
);

CREATE TABLE "Questions" (
    "Id" uuid NOT NULL,
    "Question" text NOT NULL,
    "Type" integer NOT NULL,
    "SurveyId" uuid NOT NULL,
    CONSTRAINT "PK_Questions" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Questions_Surveys_SurveyIdId" FOREIGN KEY ("SurveyId") REFERENCES "Surveys" ("Id")  ON DELETE CASCADE
);

CREATE TABLE "Answers" (
    "Id" uuid NOT NULL,
    "Answer" text NOT NULL,
    "QuestionId" uuid NOT NULL,
    CONSTRAINT "PK_Answers" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Answers_Questions_QuestionId" FOREIGN KEY ("QuestionId") REFERENCES "Questions" ("Id")  ON DELETE CASCADE
);

CREATE INDEX "IX_Answers_Id" ON "Answers" ("Id");
CREATE INDEX "IX_Answers_QuestionId" ON "Answers" ("QuestionId");
CREATE UNIQUE INDEX "UQ_Answers_Answer" ON "Answers" ("Answer");

CREATE INDEX "IX_Interviews_Id" ON "Interviews" ("Id");
CREATE INDEX "IX_Interviews_InterviewDate" ON "Interviews" ("InterviewDate");
CREATE INDEX "IX_Interviews_SurveyId" ON "Interviews" ("SurveyId");

CREATE INDEX "IX_Questions_Id" ON "Questions" ("Id");
CREATE INDEX "IX_Questions_SurveyId" ON "Questions" ("SurveyId");
CREATE UNIQUE INDEX "UQ_Questions_Question" ON "Questions" ("Question");

CREATE INDEX "IX_Results_Id" ON "Results" ("Id");
CREATE INDEX "IX_Results_InterviewId" ON "Results" ("InterviewId");
CREATE UNIQUE INDEX "UQ_Results_Answer" ON "Results" ("Answer");

CREATE INDEX "IX_Surveys_CreatedAt" ON "Surveys" ("CreatedAt");
CREATE INDEX "IX_Surveys_Id" ON "Surveys" ("Id");
CREATE UNIQUE INDEX "UQ_Surveys_Title" ON "Surveys" ("Title");