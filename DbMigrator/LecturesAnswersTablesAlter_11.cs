using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(11)]
    public class LecturesAnswersTablesAlter_11 : Migration
    {
        public override void Apply()
        {
            var script = $@"ALTER TABLE foreignstudy.lectures
  ADD COLUMN lecture_filelink character varying;
ALTER TABLE foreignstudy.answers
   ADD COLUMN answer_ifcorrect boolean;";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"ALTER TABLE foreignstudy.lectures
  DROP COLUMN lecture_filelink;
ALTER TABLE foreignstudy.answers
   DROP COLUMN answer_ifcorrect;
";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
