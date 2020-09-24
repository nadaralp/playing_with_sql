using System;

namespace PlayingWithSql.LoadCsv
{
    class Program
    {
        public static ReadDataFromCsv readDataFromCsv = new ReadDataFromCsv();
        static void Main(string[] args)
        {
            var records = readDataFromCsv.ReadData(@"D:\Learning\PlayingWithSql\PlayingWithSql.LoadCsv\records.csv");
        }
    }
}
