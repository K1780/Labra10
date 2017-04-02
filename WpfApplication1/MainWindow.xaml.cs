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

namespace App1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeMyStuff();
        }

        private void InitializeMyStuff()
        {
            //kootaan tähän metodiin kaikki kontrollien alustukset
            //lisätään comboboxiin tavaroita
            cbMagazines.Items.Add("");
            cbMagazines.Items.Add("Fitness");
            cbMagazines.Items.Add("Cosmopolitan");
            cbMagazines.Items.Add("Aku Ankka");
            cbMagazines.Items.Add("Iltalehti");
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            //tutkitaan mitä kontrolleja käyttäjä valinnut
            string msg = "";

            //kontrolli kerrallaan
            /*if ((bool)chkBanana.IsChecked)
            {
                msg += "banaaneja 1kg\n";
            }
            if ((bool)chkBread.IsChecked)
            {
                msg += "leipää 1kg\n";
            }*/

            //versio 2: käydään kaikki kontrollit loopissa läpi
            foreach (object control in spList.Children)
            {
                if (control is CheckBox)
                {
                    CheckBox cb = (CheckBox)control;
                    if ((bool)cb.IsChecked)
                    {
                        msg += cb.Content + "\n";
                    }
                }
            }
            //tutkitaan onko comboxista valittu jokin lehti
            if (cbMagazines.SelectedIndex > 0)
            {
                msg += cbMagazines.SelectedValue;
            }
            else
            {
                msg += "Ei oteta lehteä";
            }
            //ostokset näkyviin
            txtList.Text = msg;
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            //kutsutaan näkyviin about ikkuna
            about win = new about ();
            //kaksi tapaa näyttää, modaalinen ja ei modaalinen
            //win.Show();
            win.ShowDialog();
        }
    }
}