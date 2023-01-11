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
            this.NiedoczynnoscTarczycy = (int)NiedoczynnoscTarczycy*100;
            this.ChorobaAlzheimera = (int)ChorobaAlzheimera * 100;
            this.ChorobaNerek = (int)ChorobaNerek * 100;
            this.StwardnienieRozsianePoczatkowe = (int)StwardnienieRozsianePoczatkowe * 100;
            this.StwardnienieRozsianeZaawansowane = (int)StwardnienieRozsianeZaawansowane * 100;
            this.Depresja = (int)Depresja * 100;
            this.ZapalenieUcha = (int)ZapalenieUcha * 100;
            this.ChorobaWiencowa = (int)ChorobaWiencowa * 100;
            this.Ciaza = (int)Ciaza * 100;
            this.OspaWieczna = (int)OspaWieczna * 100;
            this.ChorobaTrzustki = (int)ChorobaTrzustki * 100;
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
