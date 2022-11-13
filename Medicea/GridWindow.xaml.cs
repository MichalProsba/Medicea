using Medicea.DatabaseSQLite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
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

        List<TextBlock> textBlockButtons = new List<TextBlock>();
        public List<TextBlock> TextBlockButtons
        {
            get { return textBlockButtons; }
            set { textBlockButtons = value; }
        }

        public GridWindow()
        {
            InitializeComponent();
            PrepareDataToDisplayFromDatabase();
        }

        public void PrepareDataToDisplayFromDatabase()
        {
            DatabaseSQLiteSerializer db = new DatabaseSQLiteSerializer();

            foreach (Symptom i in db.Symptoms.ToList())
            {
                toggleButtons.Add(new ToggleButton());
                textBlockButtons.Add(new TextBlock());
            }

            int toggleButtonNumber = 1;
            int column = toggleButtonNumber - 1;
            int row = 0;
            foreach (ToggleButton i in toggleButtons)
            {
                i.Name = "ToggleButton_" + toggleButtonNumber;
                i.Foreground = Brushes.Transparent;
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
            foreach (TextBlock i in textBlockButtons)
            {
                i.Name = "TextBlock_" + toggleButtonNumber;
                i.Text = db.Symptoms.ToList()[toggleButtonNumber - 1].NazwaObjawu;
                i.HorizontalAlignment = HorizontalAlignment.Center;
                i.VerticalAlignment = VerticalAlignment.Center;
                i.TextWrapping= TextWrapping.Wrap;
                i.Foreground = Brushes.Black;
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

            foreach (TextBlock i in textBlockButtons)
            {
                mainGrid.Children.Add(i);
            }
        }
    }
}
