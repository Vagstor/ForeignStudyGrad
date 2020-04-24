using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(8)]
    public class QuestionsTableMigration_08 : Migration
    {
        public override void Apply()
        {
            var script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[questions]    Script Date: 24.04.2020 12:57:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[questions](
	[test_id] [uniqueidentifier] NOT NULL,
	[question_id] [uniqueidentifier] NOT NULL,
	[question_body] [varchar](50) NOT NULL,
 CONSTRAINT [PK_questions] PRIMARY KEY CLUSTERED 
(
	[question_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[questions]  WITH CHECK ADD  CONSTRAINT [FK_questions_tests] FOREIGN KEY([test_id])
REFERENCES [dbo].[tests] ([test_id])
GO

ALTER TABLE [dbo].[questions] CHECK CONSTRAINT [FK_questions_tests]
GO



";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"USE [foreignstudy]
GO

/****** Object:  Table [dbo].[questions]    Script Date: 24.04.2020 12:57:18 ******/
DROP TABLE [dbo].[questions]
GO


";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
