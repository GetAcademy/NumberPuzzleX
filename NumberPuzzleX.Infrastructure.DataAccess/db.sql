-- Lag en database selv manuelt
-- Opprett så tabellen Game med koden under. 
-- Husk å endre connection string i GameModelRepository

CREATE TABLE [dbo].[Game](
	[Id] [uniqueidentifier] NOT NULL,
	[Numbers] [char](9) NOT NULL,
	[PlayCount] [int] NOT NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
