USE [GKL]
GO
/****** Object:  Table [dbo].[t_check_result_rireki]    Script Date: 01/15/2019 22:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_check_result_rireki](
	[chk_no] [varchar](20) NOT NULL,
	[nen] [varchar](4) NOT NULL,
	[chk_times] [int] NOT NULL,
	[plan_no] [varchar](20) NULL,
	[line_id] [varchar](10) NOT NULL,
	[make_no] [varchar](20) NOT NULL,
	[code] [varchar](20) NULL,
	[suu] [varchar](10) NULL,
	[temp_id] [varchar](10) NULL,
	[chk_result] [varchar](1) NULL,
	[chk_user] [varchar](20) NULL,
	[yotei_chk_date] [varchar](10) NULL,
	[chk_start_date] [date] NULL,
	[chk_end_date] [date] NULL,
	[parent_chk_no] [varchar](20) NULL,
	[status] [varchar](1) NULL,
	[ins_user] [varchar](20) NULL,
	[ins_date] [date] NULL,
	[dousa] [varchar](20) NULL,
	[upd_user] [varchar](20) NULL,
	[upd_date] [date] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_check_result]    Script Date: 01/15/2019 22:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_check_result](
	[chk_no] [varchar](20) NOT NULL,
	[nen] [varchar](4) NOT NULL,
	[chk_times] [int] NOT NULL,
	[plan_no] [varchar](20) NULL,
	[line_id] [varchar](10) NOT NULL,
	[make_no] [varchar](20) NOT NULL,
	[code] [varchar](20) NULL,
	[suu] [varchar](10) NULL,
	[temp_id] [varchar](10) NULL,
	[chk_result] [varchar](1) NULL,
	[chk_user] [varchar](20) NULL,
	[yotei_chk_date] [varchar](10) NULL,
	[chk_start_date] [date] NULL,
	[chk_end_date] [date] NULL,
	[parent_chk_no] [varchar](20) NULL,
	[status] [varchar](1) NULL,
	[ins_user] [varchar](20) NULL,
	[ins_date] [date] NULL,
 CONSTRAINT [PK_t_check_result] PRIMARY KEY CLUSTERED 
(
	[chk_no] ASC,
	[nen] ASC,
	[chk_times] ASC,
	[line_id] ASC,
	[make_no] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_check_plan]    Script Date: 01/15/2019 22:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_check_plan](
	[plan_no] [varchar](20) NOT NULL,
	[chk_no] [varchar](40) NOT NULL,
	[make_no] [varchar](20) NOT NULL,
	[code] [varchar](20) NOT NULL,
	[line_id] [varchar](10) NOT NULL,
	[suu] [varchar](10) NULL,
	[yotei_chk_date] [varchar](20) NULL,
	[status] [varchar](1) NULL,
	[xiangxian] [varchar](20) NULL,
	[mark] [nvarchar](500) NULL,
 CONSTRAINT [PK_t_check_plan] PRIMARY KEY CLUSTERED 
(
	[plan_no] ASC,
	[chk_no] ASC,
	[make_no] ASC,
	[code] ASC,
	[line_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_check_ms]    Script Date: 01/15/2019 22:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_check_ms](
	[chk_no] [varchar](20) NOT NULL,
	[chk_method_id] [varchar](10) NOT NULL,
	[chk_flg] [varchar](1) NULL,
	[in_1] [varchar](20) NULL,
	[in_2] [varchar](20) NULL,
	[chk_result] [varchar](20) NULL,
	[mark] [varchar](200) NULL,
	[kj_0] [varchar](100) NULL,
	[kj_1] [varchar](20) NULL,
	[kj_2] [varchar](20) NULL,
	[kj_explain] [nvarchar](200) NULL,
	[ins_user] [varchar](20) NULL,
	[ins_date] [date] NULL,
 CONSTRAINT [PK_t_check_ms] PRIMARY KEY CLUSTERED 
(
	[chk_no] ASC,
	[chk_method_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_cd_temp_relation_junbi]    Script Date: 01/15/2019 22:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_cd_temp_relation_junbi](
	[line_id] [varchar](10) NOT NULL,
	[code] [varchar](20) NOT NULL,
	[temp_id] [varchar](10) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_cd_temp_relation]    Script Date: 01/15/2019 22:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_cd_temp_relation](
	[line_id] [varchar](10) NOT NULL,
	[code] [varchar](20) NOT NULL,
	[temp_id] [varchar](10) NOT NULL,
 CONSTRAINT [PK_t_cd_temp_relation] PRIMARY KEY CLUSTERED 
(
	[line_id] ASC,
	[code] ASC,
	[temp_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[m_user]    Script Date: 01/15/2019 22:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[m_user](
	[user_cd] [varchar](10) NOT NULL,
	[line_id] [varchar](10) NULL,
	[user_name] [nvarchar](10) NULL,
 CONSTRAINT [PK_m_user] PRIMARY KEY CLUSTERED 
(
	[user_cd] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[m_tools]    Script Date: 01/15/2019 22:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[m_tools](
	[tool_id] [varchar](40) NOT NULL,
	[line_id] [varchar](10) NOT NULL,
	[project_name] [nvarchar](40) NULL,
	[tool_name] [nvarchar](80) NULL,
 CONSTRAINT [PK_m_tools] PRIMARY KEY CLUSTERED 
(
	[tool_id] ASC,
	[line_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[m_temp_name]    Script Date: 01/15/2019 22:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[m_temp_name](
	[temp_id] [varchar](10) NOT NULL,
	[line_id] [varchar](10) NOT NULL,
	[temp_name] [nvarchar](200) NULL,
 CONSTRAINT [PK_m_temp_name] PRIMARY KEY CLUSTERED 
(
	[temp_id] ASC,
	[line_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[m_temp]    Script Date: 01/15/2019 22:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[m_temp](
	[line_id] [varchar](10) NOT NULL,
	[temp_id] [nvarchar](10) NOT NULL,
	[chk_method_id] [varchar](10) NOT NULL,
	[project_id] [varchar](10) NULL,
	[project_name] [nvarchar](50) NULL,
	[pic_id] [varchar](10) NULL,
	[pic_name] [nvarchar](200) NULL,
	[chk_km_name] [nvarchar](200) NULL,
	[pic_sign] [varchar](10) NULL,
	[chk_id] [varchar](10) NULL,
	[chk_name] [nvarchar](50) NULL,
	[tool_id] [varchar](40) NULL,
	[kj_0] [varchar](100) NULL,
	[kj_1] [varchar](20) NULL,
	[kj_2] [varchar](20) NULL,
	[kj_explain] [nvarchar](200) NULL,
 CONSTRAINT [PK_m_temp] PRIMARY KEY CLUSTERED 
(
	[line_id] ASC,
	[temp_id] ASC,
	[chk_method_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[m_project]    Script Date: 01/15/2019 22:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[m_project](
	[project_id] [varchar](10) NOT NULL,
	[line_id] [varchar](10) NOT NULL,
	[project_name] [nvarchar](40) NULL,
 CONSTRAINT [PK_m_project] PRIMARY KEY CLUSTERED 
(
	[project_id] ASC,
	[line_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[m_picture]    Script Date: 01/15/2019 22:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[m_picture](
	[pic_id] [varchar](10) NOT NULL,
	[line_id] [varchar](10) NOT NULL,
	[pic_name] [nvarchar](200) NULL,
	[pic_conn] [varbinary](max) NULL,
 CONSTRAINT [PK_m_picture] PRIMARY KEY CLUSTERED 
(
	[pic_id] ASC,
	[line_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[m_check_method]    Script Date: 01/15/2019 22:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[m_check_method](
	[chk_id] [varchar](10) NOT NULL,
	[chk_name] [nvarchar](40) NOT NULL,
	[chk_method] [varchar](1) NULL,
	[chk_formula] [nvarchar](80) NULL,
	[verify_method_explain] [nvarchar](200) NULL,
 CONSTRAINT [PK_m_check_method] PRIMARY KEY CLUSTERED 
(
	[chk_id] ASC,
	[chk_name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
