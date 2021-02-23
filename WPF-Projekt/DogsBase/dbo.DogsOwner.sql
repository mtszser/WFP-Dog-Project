CREATE TABLE [dbo].[DogsOwner] (
    [User_id] INT          NOT NULL,
    [Username]     VARCHAR (20) NOT NULL,
    [Password]  VARCHAR (20) NOT NULL,
	[Name] Varchar (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([User_id] ASC)
);

