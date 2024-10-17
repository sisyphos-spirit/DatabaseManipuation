USE [LeagueOfLegendsDB]
GO

/****** Object:  Table [dbo].[HistorialJugadorCampeon]    Script Date: 17/10/2024 11:32:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HistorialJugadorCampeon](
	[ID_Historial] [int] IDENTITY(1,1) NOT NULL,
	[ID_Jugador] [int] NULL,
	[ID_Campeon] [int] NULL,
	[VecesJugado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Historial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[HistorialJugadorCampeon]  WITH CHECK ADD FOREIGN KEY([ID_Campeon])
REFERENCES [dbo].[Campeones] ([ID_Campeon])
GO

ALTER TABLE [dbo].[HistorialJugadorCampeon]  WITH CHECK ADD FOREIGN KEY([ID_Jugador])
REFERENCES [dbo].[Jugadores] ([ID_Jugador])
GO

