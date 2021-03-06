/****** Object:  Table [dbo].[tb_users_roles]    Script Date: 20/10/2020 23:52:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_users_roles]') AND type in (N'U'))
DROP TABLE [dbo].[tb_users_roles]
GO
/****** Object:  Table [dbo].[tb_users]    Script Date: 20/10/2020 23:52:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_users]') AND type in (N'U'))
DROP TABLE [dbo].[tb_users]
GO
/****** Object:  Table [dbo].[tb_roles]    Script Date: 20/10/2020 23:52:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_roles]') AND type in (N'U'))
DROP TABLE [dbo].[tb_roles]
GO
/****** Object:  Table [dbo].[tb_roles]    Script Date: 20/10/2020 23:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_tb_roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_users]    Script Date: 20/10/2020 23:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login_name] [varchar](20) NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_tb_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_users_roles]    Script Date: 20/10/2020 23:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_users_roles](
	[id_role] [int] NOT NULL,
	[id_user] [int] NOT NULL
) ON [PRIMARY]
GO
