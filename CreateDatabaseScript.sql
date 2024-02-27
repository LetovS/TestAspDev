CREATE DATABASE "AspWebApi";


CREATE TABLE "Interviews" (
    "Id" uuid NOT NULL,
    "InterviewDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Interviews" PRIMARY KEY ("Id")
);


CREATE TABLE "Surveys" (
    "Id" uuid NOT NULL,
    "Title" text NOT NULL,
    "Description" character varying(255) NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Surveys" PRIMARY KEY ("Id")
);



CREATE TABLE "Results" (
    "Id" uuid NOT NULL,
    "QuestionId" integer NOT NULL,
    "InterviewId" integer NOT NULL,
    "Answer" text NOT NULL,
    "InterviewRecordId" uuid NULL,
    CONSTRAINT "PK_Results" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Results_Interviews_InterviewRecordId" FOREIGN KEY ("InterviewRecordId") REFERENCES "Interviews" ("Id")
);


CREATE TABLE "Questions" (
    "Id" uuid NOT NULL,
    "Question" text NOT NULL,
    "Type" integer NOT NULL,
    "SurveyRecordId" uuid NULL,
    CONSTRAINT "PK_Questions" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Questions_Surveys_SurveyRecordId" FOREIGN KEY ("SurveyRecordId") REFERENCES "Surveys" ("Id")
);


CREATE TABLE "Answers" (
    "Id" uuid NOT NULL,
    "Answer" text NOT NULL,
    "QuestionRecordId" uuid NULL,
    CONSTRAINT "PK_Answers" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Answers_Questions_QuestionRecordId" FOREIGN KEY ("QuestionRecordId") REFERENCES "Questions" ("Id")
);


CREATE INDEX "IX_Answers_QuestionRecordId" ON "Answers" ("QuestionRecordId");
CREATE INDEX "IX_Questions_SurveyRecordId" ON "Questions" ("SurveyRecordId");
CREATE INDEX "IX_Results_InterviewRecordId" ON "Results" ("InterviewRecordId");