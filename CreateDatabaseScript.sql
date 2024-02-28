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
    CONSTRAINT "FK_Results_Interviews_InterviewId" FOREIGN KEY ("InterviewId") REFERENCES "Interviews" ("Id")
);

CREATE TABLE "Questions" (
    "Id" uuid NOT NULL,
    "Question" text NOT NULL,
    "Type" integer NOT NULL,
    "SurveyId" uuid NOT NULL,
    CONSTRAINT "PK_Questions" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Questions_Surveys_SurveyIdId" FOREIGN KEY ("SurveyId") REFERENCES "Surveys" ("Id")
);

CREATE TABLE "Answers" (
    "Id" uuid NOT NULL,
    "Answer" text NOT NULL,
    "QuestionId" uuid NOT NULL,
    CONSTRAINT "PK_Answers" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Answers_Questions_QuestionId" FOREIGN KEY ("QuestionId") REFERENCES "Questions" ("Id")
);

CREATE INDEX idx_surveys_id ON "Surveys" ("Id");
CREATE INDEX idx_questions_id ON "Questions" ("Id");
CREATE INDEX idx_questions_question ON "Questions" ("Question");
CREATE INDEX idx_interviews_id ON "Interviews" ("Id");
CREATE INDEX idx_results_id ON "Results" ("Id");
CREATE INDEX idx_answers_answer ON "Answers" ("Answer");

