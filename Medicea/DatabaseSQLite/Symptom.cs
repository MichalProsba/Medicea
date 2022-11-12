using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Medicea.DatabaseSQLite
{
    public class Symptom
    {
        [Key]

        [Required] public int ID { get; set; }

        [Required] public string NazwaObjawu { get; set; }

        [Required] public float WagiNiedoczynnoscTarczycy { get; set; }

        [Required] public float WagiChorobaNerek { get; set; }

        [Required] public float WagiChorobaAlzheimera { get; set; }

        [Required] public float WagiStwardnienieRozsianePoczatkowe { get; set; }

        [Required] public float WagiStwardnienieRozsianeZaawansowane { get; set; }

        [Required] public float WagiDepresja { get; set; }

        [Required] public float WagiZapalenieUcha { get; set; }

        [Required] public float WagiChorobaWiencowa { get; set; }

        [Required] public float WagiCiaza { get; set; }

        [Required] public float WagiOspaWieczna { get; set; }

        [Required] public float WagiChorobaTrzustki { get; set; }
    }
}
