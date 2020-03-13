using LinqToDB.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignStudyGrad
{
        public class DbSettings : IConnectionStringSettings
        {
            public string ConnectionString { get; set; }
            public string Name { get; set; }
            public string ProviderName { get; set; }
            public bool IsGlobal => false;
        }

        public class MySettings : ILinqToDBSettings
        {
            public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

            public string DefaultConfiguration => "PostgreSQL";
            public string DefaultDataProvider => "PostgreSQL";
            public string ConnString;

            public IEnumerable<IConnectionStringSettings> ConnectionStrings
            {
                get
                {
                    yield return
                        new DbSettings
                        {
                            Name = "PostgreSQL",
                            ProviderName = "PostgreSQL",
                            ConnectionString = ConnString
                        };
                }
            }
        }
}
