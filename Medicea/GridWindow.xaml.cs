﻿using Medicea.DatabaseSQLite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Medicea
{
    /// <summary>
    /// Logika interakcji dla klasy GridWindow.xaml
    /// </summary>
    public partial class GridWindow : Window
    {

        List<ToggleButton> toggleButtons = new List<ToggleButton>();
        public List<ToggleButton> ToggleButtons
        {
            get { return toggleButtons; }
            set { toggleButtons = value; }
        }

        List<Symptom> symptoms = new List<Symptom>();

        public float NiedoczynnoscTarczycy = 0.0f;
        public float ChorobaNerek = 0.0f;
        public float ChorobaAlzheimera = 0.0f;
        public float StwardnienieRozsianePoczatkowe = 0.0f;
        public float StwardnienieRozsianeZaawansowane = 0.0f;
        public float Depresja = 0.0f;
        public float ZapalenieUcha = 0.0f;
        public float ChorobaWiencowa = 0.0f;
        public float Ciaza = 0.0f;
        public float OspaWieczna = 0.0f;
        public float ChorobaTrzustki = 0.0f;

        ResultsWindow resultsWindow;

        int gender;


        public GridWindow(int sex_combobox)
        {
            InitializeComponent();
            PrepareDataToDisplayFromDatabase();
            gender = sex_combobox;
        }

        public void PrepareDataToDisplayFromDatabase()
        {
            symptoms = (new DatabaseSQLiteSerializer()).Symptoms.ToList();

            foreach (Symptom i in symptoms)
            {
                var tButton = new ToggleButton()
                {
                    Padding = new Thickness(2.0),
                    Margin = new Thickness(5.0),
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#55FFFFFF")),
                    BorderThickness = new Thickness(3.0),
                    Foreground = new SolidColorBrush(Colors.Black),
                    BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD992B1")),
                    Height = 45,
                };
                toggleButtons.Add(tButton);
            }

            int toggleButtonNumber = 1;
            int column = toggleButtonNumber - 1;
            int row = 0;
            foreach (ToggleButton i in toggleButtons)
            {
                i.Name = "ToggleButton_" + toggleButtonNumber;
                i.Content = new TextBlock()
                {
                    Text = symptoms[toggleButtonNumber - 1].NazwaObjawu,
                    TextAlignment = TextAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    FontFamily = new FontFamily("Arial"),
                };
                Grid.SetColumn(i, column);
                Grid.SetRow(i, row);
                column++;
                if (column % 8 == 0)
                {
                    row++;
                    column = 0;
                }
                toggleButtonNumber++;
            }

            foreach (ToggleButton i in toggleButtons)
            {
                mainGrid.Children.Add(i);
            }

            toggleButtonNumber = 1;
            column = toggleButtonNumber - 1;
            row = 0;
        }

        private void calculatePoint_Click(object sender, RoutedEventArgs e)
        {
            resetPoints();
            foreach(int i in Enumerable.Range(0, toggleButtons.Count))
            {
                if (toggleButtons[i].IsChecked == true) 
                {
                    NiedoczynnoscTarczycy += symptoms[i].WagiNiedoczynnoscTarczycy; 
                    ChorobaNerek += symptoms[i].WagiChorobaNerek; 
                    ChorobaAlzheimera += symptoms[i].WagiChorobaAlzheimera; 
                    StwardnienieRozsianePoczatkowe += symptoms[i].WagiStwardnienieRozsianePoczatkowe; 
                    StwardnienieRozsianeZaawansowane += symptoms[i].WagiStwardnienieRozsianeZaawansowane; 
                    Depresja += symptoms[i].WagiDepresja; 
                    ZapalenieUcha += symptoms[i].WagiZapalenieUcha; 
                    ChorobaWiencowa += symptoms[i].WagiChorobaWiencowa;
                    if (gender == 0)
                    {
                        Ciaza += symptoms[i].WagiCiaza;
                    }
                    else {
                        Ciaza += 0.0f;
                    }
                    OspaWieczna += symptoms[i].WagiOspaWieczna; 
                    ChorobaTrzustki += symptoms[i].WagiChorobaTrzustki;
                }
            }
            resultsWindow = new(
                NiedoczynnoscTarczycy,
                ChorobaNerek,
                ChorobaAlzheimera,
                StwardnienieRozsianePoczatkowe,
                StwardnienieRozsianeZaawansowane,
                Depresja,
                ZapalenieUcha,
                ChorobaWiencowa,
                Ciaza,
                OspaWieczna,
                ChorobaTrzustki
            );
            resultsWindow.Show();
            this.Close();
        }

        private void resetPoints() 
        {
            NiedoczynnoscTarczycy = 0.0f;
            ChorobaNerek = 0.0f;
            ChorobaAlzheimera = 0.0f;
            StwardnienieRozsianePoczatkowe = 0.0f;
            StwardnienieRozsianeZaawansowane = 0.0f;
            Depresja = 0.0f;
            ZapalenieUcha = 0.0f;
            ChorobaWiencowa = 0.0f;
            Ciaza = 0.0f;
            OspaWieczna = 0.0f;
            ChorobaTrzustki = 0.0f;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
