CREATE TABLE [dbo].[User] (
    [IdUser]   INT          IDENTITY (1, 1) NOT NULL,
    [Username] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,  -- Contraseña hasheada
    [IsActive] BIT          NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([IdUser] ASC)
);

CREATE TABLE [dbo].[Login] (
    [IdLogin]  INT            IDENTITY (1, 1) NOT NULL,
    [User]     VARCHAR (500)  NOT NULL,
    [UserName] VARCHAR (500)  NOT NULL,
    [Password] VARCHAR (1000) NOT NULL,  -- Contraseña hasheada
    [Role]     BIT            NOT NULL,
    CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([IdLogin] ASC)
);
