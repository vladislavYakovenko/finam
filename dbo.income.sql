CREATE TABLE [dbo].[income] (
    [id income]      INT        IDENTITY (1, 1) NOT NULL,
    [summ]           INT        NOT NULL,
    [month]          NCHAR (10) NOT NULL,
    [comment]        NCHAR (30) NOT NULL,
    [categoryIncome] NCHAR (30) NOT NULL,
    CONSTRAINT [PK_income] PRIMARY KEY CLUSTERED ([id income] ASC)
);

