USE [gpgc]
GO

/****** Object:  Table [dbo].[admin]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[admin](
	[admin_id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[classtbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[classtbl](
	[class_id] [int] IDENTITY(1,1) NOT NULL,
	[class_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_classtbl] PRIMARY KEY CLUSTERED 
(
	[class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[coursestbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[coursestbl](
	[course_id] [int] IDENTITY(1,1) NOT NULL,
	[course_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_coursestbl] PRIMARY KEY CLUSTERED 
(
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[finaltbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[finaltbl](
	[f_id] [int] IDENTITY(1,1) NOT NULL,
	[roll_no] [int] NOT NULL,
	[t_name] [varchar](50) NOT NULL,
	[subject_name] [varchar](50) NOT NULL,
	[absenties] [int] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[fine] [int] NOT NULL,
 CONSTRAINT [PK_finaltbl] PRIMARY KEY CLUSTERED 
(
	[f_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[fineCriteriatbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[fineCriteriatbl](
	[fineC_id] [int] IDENTITY(1,1) NOT NULL,
	[from] [int] NOT NULL,
	[to] [int] NOT NULL,
	[fineOnPerAbsent] [int] NOT NULL,
	[stuckOffOn] [int] NOT NULL,
 CONSTRAINT [PK_fineCriteriatbl] PRIMARY KEY CLUSTERED 
(
	[fineC_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[finetbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[finetbl](
	[f_id] [int] IDENTITY(1,1) NOT NULL,
	[s_id] [int] NOT NULL,
	[s_name] [varchar](50) NOT NULL,
	[teacher_id] [int] NOT NULL,
	[subject_id] [varchar](50) NOT NULL,
	[section_name] [varchar](50) NOT NULL,
	[month] [int] NOT NULL,
	[year] [int] NOT NULL,
	[lec_delivered] [int] NOT NULL,
	[presents] [int] NOT NULL,
	[absenties] [int] NOT NULL,
	[leaves] [int] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[fine] [int] NULL,
	[course_name] [varchar](50) NOT NULL,
	[class_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_finetbl] PRIMARY KEY CLUSTERED 
(
	[f_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[lectureDeliveredtbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[lectureDeliveredtbl](
	[l_d_id] [int] IDENTITY(1,1) NOT NULL,
	[teacher_id] [int] NOT NULL,
	[lect] [int] NOT NULL,
	[month] [int] NOT NULL,
	[year] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[subject_id] [varchar](50) NOT NULL,
 CONSTRAINT [PK_lectureDeliveredtbl] PRIMARY KEY CLUSTERED 
(
	[l_d_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[manualFinetbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[manualFinetbl](
	[f_id] [int] IDENTITY(1,1) NOT NULL,
	[roll_no] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
	[subject_id] [varchar](50) NOT NULL,
	[class_name] [varchar](50) NOT NULL,
	[section_name] [varchar](50) NOT NULL,
	[month] [int] NOT NULL,
	[year] [int] NOT NULL,
	[lec_delivered] [int] NOT NULL,
	[presents] [int] NOT NULL,
	[absenties] [int] NOT NULL,
	[leaves] [int] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[fine] [int] NULL,
 CONSTRAINT [PK_manualFinetbl] PRIMARY KEY CLUSTERED 
(
	[f_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[sectiontbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[sectiontbl](
	[section_id] [int] IDENTITY(1,1) NOT NULL,
	[section_name] [varchar](50) NULL,
 CONSTRAINT [PK_sectiontbl] PRIMARY KEY CLUSTERED 
(
	[section_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[sorttbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[sorttbl](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[roll_no] [int] NOT NULL,
	[t_name] [varchar](50) NOT NULL,
	[subject_name] [varchar](50) NOT NULL,
	[absenties] [int] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[fine] [int] NOT NULL,
 CONSTRAINT [PK_sorttbl] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[studenttbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[studenttbl](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[student_name] [varchar](50) NOT NULL,
	[course_id] [int] NOT NULL,
	[section_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[roll_no] [int] NOT NULL,
	[reg_no] [int] NULL,
 CONSTRAINT [PK_studenttbl] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[subjectAssignedtbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[subjectAssignedtbl](
	[c_a_id] [int] IDENTITY(1,1) NOT NULL,
	[teacher_id] [int] NOT NULL,
	[section_id] [int] NOT NULL,
	[subject_id] [varchar](50) NOT NULL,
	[class_id] [int] NOT NULL,
 CONSTRAINT [PK_subjectAssignedtbl] PRIMARY KEY CLUSTERED 
(
	[c_a_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[subjecttbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[subjecttbl](
	[subject_id] [varchar](50) NOT NULL,
	[subject_name] [varchar](50) NOT NULL,
	[course_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
 CONSTRAINT [PK_subjecttbl] PRIMARY KEY CLUSTERED 
(
	[subject_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[teachertbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[teachertbl](
	[teacher_id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[t_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_teachertbl] PRIMARY KEY CLUSTERED 
(
	[teacher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[virtualtbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[virtualtbl](
	[v_id] [int] IDENTITY(1,1) NOT NULL,
	[roll_no] [int] NOT NULL,
	[t_name] [varchar](50) NOT NULL,
	[subject_name] [varchar](50) NOT NULL,
	[absenties] [int] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[fine] [int] NOT NULL,
 CONSTRAINT [PK_virtualtbl] PRIMARY KEY CLUSTERED 
(
	[v_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[yeartbl]    Script Date: 12/20/2019 9:49:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[yeartbl](
	[y_id] [int] IDENTITY(1,1) NOT NULL,
	[year] [int] NOT NULL,
 CONSTRAINT [PK_yeartbl] PRIMARY KEY CLUSTERED 
(
	[y_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


