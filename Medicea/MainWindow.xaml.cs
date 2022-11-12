using Medicea.DatabaseSQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Medicea
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateSymptomGrid();
        }

        public void UpdateSymptomGrid()
        {
            DatabaseSQLiteSerializer db = new DatabaseSQLiteSerializer();
            var docs = from d in db.Symptoms
                       select new
                       {
                           ID = d.ID,
                           NazwaObjawu = d.NazwaObjawu,
                           NiedoczynnoscTarczycy = d.WagiNiedoczynnoscTarczycy,
                           ChorobaNerek = d.WagiChorobaNerek,
                           ChorobaAlzheimera = d.WagiChorobaAlzheimera,
                           StwardnienieRozsianePoczatkowe = d.WagiStwardnienieRozsianePoczatkowe,
                           StwardnienieRozsianeZaawansowane = d.WagiStwardnienieRozsianeZaawansowane,
                           Depresja = d.WagiDepresja,
                           ZapalenieUcha = d.WagiZapalenieUcha,
                           ChorobaWiencowa = d.WagiChorobaWiencowa,
                           Ciaza = d.WagiCiaza,
                           OspaWieczna = d.WagiOspaWieczna,
                           ChorobaTrzustki = d.WagiChorobaTrzustki
                       };
            this.SymptomGrid.ItemsSource = docs.ToList();
        }
    }
}
