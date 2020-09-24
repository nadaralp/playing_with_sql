using CsvHelper;
using CsvHelper.Configuration;
using PlayingWithSql.LoadCsv.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithSql.LoadCsv
{
    public class ReadDataFromCsv
    {
        public IEnumerable<dynamic> ReadData(string path)
        {
            CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = " ",
                HeaderValidated = null,
                MissingFieldFound = null
            };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                IEnumerable<dynamic> records = csv.GetRecords<dynamic>();
                var rec = records.ToList();
                return rec;
            }
        }
    }
}
