USE [School]
GO

/****** Object:  Table [dbo].[stsub]    Script Date: 8/13/2023 1:16:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[stsub](
	[stid] [int] NOT NULL,
	[subid] [int] NOT NULL,
	[Grade] [float] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[stsub]  WITH CHECK ADD  CONSTRAINT [FK_stsub_Students] FOREIGN KEY([stid])
REFERENCES [dbo].[Students] ([id])
GO

ALTER TABLE [dbo].[stsub] CHECK CONSTRAINT [FK_stsub_Students]
GO

ALTER TABLE [dbo].[stsub]  WITH CHECK ADD  CONSTRAINT [FK_stsub_Subject] FOREIGN KEY([subid])
REFERENCES [dbo].[Subject] ([id])
GO

ALTER TABLE [dbo].[stsub] CHECK CONSTRAINT [FK_stsub_Subject]
GO



USE [School]
GO

/****** Object:  Table [dbo].[Students]    Script Date: 8/13/2023 1:18:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students](
	[id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




USE [School]
GO

/****** Object:  Table [dbo].[Subject]    Script Date: 8/13/2023 1:18:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Subject](
	[id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Insert random values into [dbo].[Students]
INSERT INTO [dbo].[Students] ([id], [Name])
VALUES
    (1, 'John Doe'),
    (2, 'Jane Smith'),
    (3, 'Michael Johnson'),
    (4, 'Emily Brown'),
    (5, 'Daniel Davis');

-- Insert random values into [dbo].[Subject]
INSERT INTO [dbo].[Subject] ([id], [Name])
VALUES
    (1, 'Mathematics'),
    (2, 'English'),
    (3, 'Science'),
    (4, 'History'),
    (5, 'Art');

-- Insert random values into [dbo].[stsub]
-- We'll randomly assign subjects to students and provide random grades (between 1 and 10)
-- Note: This assumes that the [stid] and [subid] values correspond to existing records in [dbo].[Students] and [dbo].[Subject] tables.
INSERT INTO [dbo].[stsub] ([stid], [subid], [Grade])
VALUES
    (1, 1, ROUND(RAND() * 9 + 1, 2)), -- Student 1, Math
    (1, 2, ROUND(RAND() * 9 + 1, 2)), -- Student 1, English
    (1, 3, ROUND(RAND() * 9 + 1, 2)), -- Student 1, Science
    (2, 2, ROUND(RAND() * 9 + 1, 2)), -- Student 2, English
    (2, 4, ROUND(RAND() * 9 + 1, 2)), -- Student 2, History
    (3, 3, ROUND(RAND() * 9 + 1, 2)), -- Student 3, Science
    (4, 1, ROUND(RAND() * 9 + 1, 2)), -- Student 4, Math
    (4, 4, ROUND(RAND() * 9 + 1, 2)), -- Student 4, History
    (5, 5, ROUND(RAND() * 9 + 1, 2)); -- Student 5, Art

