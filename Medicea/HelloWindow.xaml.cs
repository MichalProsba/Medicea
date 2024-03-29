﻿using System;
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
    /// <summary>
    /// Logika interakcji dla klasy HelloWindow.xaml
    /// </summary>
    public partial class HelloWindow : Window
    {
        public HelloWindow()
        {
            InitializeComponent();
        }

        private void cancal_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void accept_btn_Click(object sender, RoutedEventArgs e)
        {
            if(name_tbox.Text.Length > 0 && surname_tbox.Text.Length > 0)
            {
                GridWindow gw = new(sex_combobox.SelectedIndex);
                gw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nie wpisano wszystkich danych");
            }
            
        }
    }
}
