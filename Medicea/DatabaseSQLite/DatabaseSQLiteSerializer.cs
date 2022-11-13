using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace Medicea.DatabaseSQLite
{
    public class DatabaseSQLiteSerializer : DatabaseSQLiteContext
    {
        public int numbersOfRecords = 0;

        public DatabaseSQLiteSerializer()
        {
            var docs = from d in this.Symptoms select new { ID = d.ID };
            this.numbersOfRecords = docs.Count();
            if (this.numbersOfRecords == 0) { ImportCSVFileToDatabase(); }
        }

        public void SaveSyntom(Symptom symptom)
        {
            this.Symptoms.Add(symptom);
            this.SaveChanges();
        }

        public void ImportCSVFileToDatabase()
        {
            var LineNumber = 0;
            var separator = ';';
            var DocumentsList = new List<Document>();
            Encoding enc = Encoding.UTF8;
            using (StreamReader reader = new StreamReader(@"../../../Objawy.csv", enc))
            {
                while (!reader.EndOfStream)
                {
                    if (LineNumber != 0)
                    {
                        var line = reader.ReadLine();
                        var values = line!.Split(separator);
                        try
                        {
                            this.SaveSyntom(new Symptom()
                            {
                                ID = Int32.Parse(values[0]),
                                NazwaObjawu = values[1].ToString(),
                                WagiNiedoczynnoscTarczycy = float.Parse(values[2]),
                                WagiChorobaNerek = float.Parse(values[3]),
                                WagiChorobaAlzheimera = float.Parse(values[4]),
                                WagiStwardnienieRozsianePoczatkowe = float.Parse(values[5]),
                                WagiStwardnienieRozsianeZaawansowane = float.Parse(values[6]),
                                WagiDepresja = float.Parse(values[7]),
                                WagiZapalenieUcha = float.Parse(values[8]),
                                WagiChorobaWiencowa = float.Parse(values[9]),
                                WagiCiaza = float.Parse(values[10]),
                                WagiOspaWieczna = float.Parse(values[11]),
                                WagiChorobaTrzustki = float.Parse(values[12])
                            });
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        var firstLine = reader.ReadLine();
                        separator = firstLine!.Contains(',') ? ',' : ';';
                    }
                    LineNumber++;
                }
            }
        }
    }
}
