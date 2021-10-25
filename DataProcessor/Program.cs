using System;
using System.Collections.Generic;
using System.IO;

namespace DataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "police_101_call_data.csv";

            var dataReader = new DataReader();
            dataReader.FileName = fileName;
            dataReader.ReadData();

            Console.WriteLine(String.Format("Average total calls: {0}", dataReader.AverageTotalCalls));
            Console.WriteLine(String.Format("Number of rows: {0}", dataReader.NumberOfForces));
            Console.WriteLine("Press enter key to exit");
            Console.ReadLine();
        }
    }

    public class DataReader
    {
        public string FileName { get; set; }

        public int AverageTotalCalls { get; set; }
        public int NumberOfForces { get; set; }

        public void ReadData()
        {
            var totalCallsColumn = 2;
            using (StreamReader reader = new StreamReader(FileName))
            {
                var totalCalls = 0;
                string[] list = { };
                
                var line = reader.ReadLine(); // Read the header line, which doesn't contain data
                while (!reader.EndOfStream)
                {
                    NumberOfForces++;
                    line = reader.ReadLine();
                    var columns = line.Split(",");  // What if there's a comma inside a data column?
                    List<string> sort = new List<string>(columns);
                    sort.RemoveAt(0);
                    int length = columns.Length-1;
                    for(int i=0;i<length;i++)
                    { 
                        if(sort[i].Contains("Not available"))
                        {
                            sort.RemoveAt(i);
                            length -= 1;
                        }
                    }
                    sort.Remove("Not available");
                    totalCalls += int.Parse(sort[1]);  // What if the data doesn't parse properly?
                }
                AverageTotalCalls = totalCalls / NumberOfForces;
            }
        }
    }
        
}
