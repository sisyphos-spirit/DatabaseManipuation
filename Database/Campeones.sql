USE [LeagueOfLegendsDB]
GO

/****** Object:  Table [dbo].[Campeones]    Script Date: 17/10/2024 11:29:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Campeones](
	[ID_Campeon] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Rol] [nvarchar](50) NULL,
	[Region] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Campeon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

