CREATE TABLE [dbo].[outcome] (
    [id outcome]      INT        IDENTITY (1, 1) NOT NULL,
    [summ]            INT        NOT NULL,
    [month]           NCHAR (10) NOT NULL,
    [comment]         NCHAR (30) NOT NULL,
    [categoryOutcome] NCHAR (30) NOT NULL,
    CONSTRAINT [PK_outcome] PRIMARY KEY CLUSTERED ([id outcome] ASC)
);