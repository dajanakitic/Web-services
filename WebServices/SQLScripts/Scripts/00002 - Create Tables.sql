USE [$DatabaseName$]
GO
	
IF NOT (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_CATALOG = '$DatabaseName$' 
                 AND  TABLE_NAME = 'Entry'))
BEGIN

CREATE TABLE [dbo].[Entry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Api] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Auth] [nvarchar](50) NULL,
	[Https] [nvarchar](50) NULL,
	[Cors] [nvarchar](50) NULL,
	[Link] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	 CONSTRAINT [PK_Entry] PRIMARY KEY CLUSTERED 
	(
	[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

END