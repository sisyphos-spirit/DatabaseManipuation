USE [LeagueOfLegendsDB]
GO

/****** Object:  Table [dbo].[Habilidades]    Script Date: 17/10/2024 11:31:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Habilidades](
	[ID_Habilidad] [int] IDENTITY(1,1) NOT NULL,
	[ID_Campeon] [int] NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Tipo] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Habilidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Habilidades]  WITH CHECK ADD FOREIGN KEY([ID_Campeon])
REFERENCES [dbo].[Campeones] ([ID_Campeon])
GO

