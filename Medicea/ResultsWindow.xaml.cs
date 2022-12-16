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
using System.Windows.Shapes;

namespace Medicea
{
 
    public partial class ResultsWindow : Window
    {

        private float NiedoczynnoscTarczycy;
        private float ChorobaNerek;
        private float ChorobaAlzheimera;
        private float StwardnienieRozsianePoczatkowe;
        private float StwardnienieRozsianeZaawansowane;
        private float Depresja;
        private float ZapalenieUcha;
        private float ChorobaWiencowa;
        private float Ciaza;
        private float OspaWieczna;
        private float ChorobaTrzustki;

        public ResultsWindow( 
             float NiedoczynnoscTarczycy,
             float ChorobaNerek,
             float ChorobaAlzheimera,
             float StwardnienieRozsianePoczatkowe,
             float StwardnienieRozsianeZaawansowane,
             float Depresja,
             float ZapalenieUcha,
             float ChorobaWiencowa,
             float Ciaza,
             float OspaWieczna,
             float ChorobaTrzustki
        ){
            this.NiedoczynnoscTarczycy = NiedoczynnoscTarczycy;
            this.ChorobaAlzheimera = ChorobaAlzheimera;
            this.ChorobaNerek = ChorobaNerek;
            this.StwardnienieRozsianePoczatkowe = StwardnienieRozsianePoczatkowe;
            this.StwardnienieRozsianeZaawansowane = StwardnienieRozsianeZaawansowane;
            this.Depresja = Depresja;
            this.ZapalenieUcha = ZapalenieUcha;
            this.ChorobaWiencowa = ChorobaWiencowa;
            this.Ciaza = Ciaza;
            this.OspaWieczna = OspaWieczna;
            this.ChorobaTrzustki = ChorobaTrzustki;
            InitializeComponent();
            generateLabelsFromRetrivetData();
        }



        private void generateLabelsFromRetrivetData()
        {
            nt_lbl.Content = NiedoczynnoscTarczycy.ToString() + "%";
            cn_lbl.Content = ChorobaNerek.ToString() + "%";
            ca_lbl.Content = ChorobaAlzheimera.ToString() + "%";
            srp_lbl.Content = StwardnienieRozsianePoczatkowe.ToString() + "%";
            srz_lbl.Content = StwardnienieRozsianeZaawansowane.ToString() + "%";
            d_lbl.Content = Depresja.ToString() + "%";
            zu_lbl.Content = ZapalenieUcha.ToString() + "%";
            cw_lbl.Content = ChorobaWiencowa.ToString() + "%";
            c_lbl.Content = Ciaza.ToString() + "%";
            ow_lbl.Content = OspaWieczna.ToString() + "%";
            ct_lbl.Content = ChorobaTrzustki.ToString() + "%";

        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
