USE [LeagueOfLegendsDB]
GO

/****** Object:  Table [dbo].[Jugadores]    Script Date: 17/10/2024 11:33:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Jugadores](
	[ID_Jugador] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Nivel] [int] NULL,
	[Region] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Jugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

