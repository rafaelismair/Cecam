USE [CECAM]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 05/11/2022 23:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RazaoSocial] [varchar](100) NOT NULL,
	[NomeFantasia] [varchar](100) NULL,
	[CNPJ] [varchar](14) NOT NULL,
	[ExisteIndicacao] [bit] NOT NULL,
	[ExisteContato] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteContato]    Script Date: 05/11/2022 23:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteContato](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCliente] [int] NOT NULL,
	[IDTipoCliente] [int] NOT NULL,
	[Contato] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ClienteContato] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteIndicacao]    Script Date: 05/11/2022 23:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteIndicacao](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCliente] [int] NOT NULL,
	[IDClienteIndicacao] [int] NOT NULL,
 CONSTRAINT [PK_ClienteIndicacao] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoContato]    Script Date: 05/11/2022 23:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoContato](
	[ID] [int] NOT NULL,
	[Descricao] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TipoContato] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClienteContato]  WITH CHECK ADD  CONSTRAINT [FK_ClienteContato_Cliente] FOREIGN KEY([IDCliente])
REFERENCES [dbo].[Cliente] ([ID])
GO
ALTER TABLE [dbo].[ClienteContato] CHECK CONSTRAINT [FK_ClienteContato_Cliente]
GO
ALTER TABLE [dbo].[ClienteContato]  WITH CHECK ADD  CONSTRAINT [FK_ClienteContato_TipoContato] FOREIGN KEY([IDTipoCliente])
REFERENCES [dbo].[TipoContato] ([ID])
GO
ALTER TABLE [dbo].[ClienteContato] CHECK CONSTRAINT [FK_ClienteContato_TipoContato]
GO
ALTER TABLE [dbo].[ClienteIndicacao]  WITH CHECK ADD  CONSTRAINT [FK_ClienteIndicacao_Cliente] FOREIGN KEY([IDCliente])
REFERENCES [dbo].[Cliente] ([ID])
GO
ALTER TABLE [dbo].[ClienteIndicacao] CHECK CONSTRAINT [FK_ClienteIndicacao_Cliente]
GO
ALTER TABLE [dbo].[ClienteIndicacao]  WITH CHECK ADD  CONSTRAINT [FK_ClienteIndicacao_Cliente1] FOREIGN KEY([IDClienteIndicacao])
REFERENCES [dbo].[Cliente] ([ID])
GO
ALTER TABLE [dbo].[ClienteIndicacao] CHECK CONSTRAINT [FK_ClienteIndicacao_Cliente1]
GO
