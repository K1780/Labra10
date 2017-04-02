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
using Lottokone;

namespace Lottokone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeMysStuff();
        }
        private void InitializeMysStuff()
        {
            
            cbPelit.Items.Add(new Perus());
            cbPelit.Items.Add(new Viking());
            cbPelit.Items.Add(new Eurojackpot());
           
            for (int x = 0; x < 20; x++)
            {
                cbRiviAmnt.Items.Add((x + 1).ToString());
            }
        }

        private void btnArvo_Click(object sender, RoutedEventArgs e)
        {
            
            if (cbPelit.SelectedIndex >= 0)
            {
               
                Lotto selectedGame = (Lotto)cbPelit.SelectedItem;
                txtRivit.Text = "";
            
                int selectedNumber = cbRiviAmnt.SelectedIndex + 1;
               
                for (int x = 0; x < selectedNumber; x++)
                {
                    selectedGame.ArvoRivit();
                   
                    txtRivit.Text += String.Format("Rivi {0}: ", x + 1) + selectedGame.LottoriviToString() + "\n";
                
                    selectedGame.ArvotutNumerot.Clear();
                }
            }
        }

        private void btnNollaa_Click(object sender, RoutedEventArgs e)
        {
            txtRivit.Text = "";
        }
    }
    public abstract class Lotto
    {
      
        public abstract string Name { get; }
        public Random rnd = new Random();
        public List<int> ArvotutNumerot = new List<int>();
       
        public abstract void ArvoRivit();
        public string LottoriviToString()
        {
            string s = "";
            foreach (int i in ArvotutNumerot)
            {
                s += i.ToString() + ", ";
            }
            s += "\n";
            return s;
        }
    }
    public class Perus : Lotto
    {
        
        public override string Name { get { return "Lotto"; } }
        
        public override void ArvoRivit()
        {
            bool successfulDraw = false;
            for (int x = 0; x <= 7;)
            {
                while (!successfulDraw)
                {
                    int proposedNumber = rnd.Next(1, 39 + 1);
                    if (!ArvotutNumerot.Contains(proposedNumber))
                    {
                        ArvotutNumerot.Add(proposedNumber);
                        x++;
                    }
                    if (x == 7)
                    {
                        successfulDraw = true;
                    }
                }
                if (successfulDraw)
                {
                    x++;
                }
            }

        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Viking : Lotto
    {
        
        public override string Name { get { return "Viking"; } }
        
        public override void ArvoRivit()
        {
            bool successfulDraw = false;
            for (int x = 0; x <= 6;)
            {
                while (!successfulDraw)
                {
                    int proposedNumber = rnd.Next(1, 48 + 1);
                    if (!ArvotutNumerot.Contains(proposedNumber))
                    {
                        ArvotutNumerot.Add(proposedNumber);
                        x++;
                    }
                    if (x == 6)
                    {
                        successfulDraw = true;
                    }
                }
                if (successfulDraw)
                {
                    x++;
                }
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Eurojackpot : Lotto
    {
       
        public override string Name { get { return "Eurojackpot"; } }
        
        public override void ArvoRivit()
        {
            bool successfulDraw = false;
            for (int x = 0; x <= 7;)
            {
                while (!successfulDraw)
                {
                    int proposedNumber = rnd.Next(1, 50 + 1);
                    if (!ArvotutNumerot.Contains(proposedNumber))
                    {
                        ArvotutNumerot.Add(proposedNumber);
                        x++;
                    }
                    if (x == 7)
                    {
                        successfulDraw = true;
                    }
                }
                if (successfulDraw)
                {
                    x++;
                }
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
