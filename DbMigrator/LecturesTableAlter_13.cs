using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(13)]
    public class LecturesTableAlter_13 : Migration
    {
        public override void Apply()
        {
            var script = $@"ALTER TABLE foreignstudy.lectures
   ADD COLUMN lecture_name character varying;";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var script = $@"ALTER TABLE foreignstudy.lectures DROP COLUMN lecture_name";
            Database.ExecuteNonQuery(script);
        }
    }
}