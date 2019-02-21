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

namespace Smash_Up_Randomizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        int[] packs = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        List<string> pot = new List<string>();
        string[] core = { "Aliens", "Dinosaurs", "Ninjas", "Pirates", "Robots", "Tricksters", "Wizards", "Zombies" };
        string[] al9k = { "Bear Cavalry", "Ghosts", "Killer Plants", "Steampunks" };
        string[] ocs = { "Elder Things", "Innsmouth", "Minions of Cthulu", "Miskatonic University" };
        string[] sfdf = { "Cyborg Apes", "Shapeshifters", "Super Spies", "Time Travelers" };
        string[] bgb = { "Geeks" };
        string[] ms = { "Giant Ants", "Mad Scientists", "Vampires", "Werewolves" };
        string[] ppsu = { "Fairies", "Kitty Cats", "Mythic Horses", "Princesses" };
        string[] sum = { "Clerics", "Dwarves", "Elves", "Halflings", "Mages", "Orcs", "Thieves", "Warriors" };
        string[] iyf = { "Dragons", "Mythic Greeks", "Sharks", "Superheroes", "Tornadoes" };
        string[] cad = { "Astroknights", "Changerbots", "Ignobles", "Star Roamers" };
        string[] wwwt = { "Explorers", "Grannies", "Rock Stars", "Teddy Bears" };
        string[] asek = { "All Stars" };
        string[] bij = { "Itty Critters", "Kaiju", "Magical Girls", "Mega Troopers" };
        string[] sp = { "Sheep" };
        string[] t70e = { "Disco Dancers", "Kung Fu Fighters", "Truckers", "Vigilantes" };
        string[] oydia = { "Ancient Egyptians", "Samurai", "Cowboys", "Vikings" };
        string[] wt1 = { "Mounties", "Sumo Wrestlers", "Musketeers", "Luchadors" };
        string[] wtek = { "Penguins" };
        string[] wt2 = { "Unknown", "Unknown", "Unknown", "Unknown" };

        public int randNum(int x)
        {
            int rand = rnd.Next(0, x);
            return rand;
        }

        public void fillPot(string[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                pot.Add(str.ElementAt(i));
            }
        }

        public void fillPot()
        {
            if (Fac1.IsChecked == true)
                fillPot(core);
            if (Fac2.IsChecked == true)
                fillPot(al9k);
            if (Fac3.IsChecked == true)
                fillPot(ocs);
            if (Fac4.IsChecked == true)
                fillPot(sfdf);
            if (Fac5.IsChecked == true)
                fillPot(bgb);
            if (Fac6.IsChecked == true)
                fillPot(ms);
            if (Fac7.IsChecked == true)
                fillPot(ppsu);
            if (Fac8.IsChecked == true)
                fillPot(sum);
            if (Fac9.IsChecked == true)
                fillPot(iyf);
            if (Fac10.IsChecked == true)
                fillPot(cad);
            if (Fac11.IsChecked == true)
                fillPot(wwwt);
            if (Fac12.IsChecked == true)
                fillPot(asek);
            if (Fac13.IsChecked == true)
                fillPot(bij);
            if (Fac14.IsChecked == true)
                fillPot(sp);
            if (Fac15.IsChecked == true)
                fillPot(t70e);
            if (Fac16.IsChecked == true)
                fillPot(oydia);
            /*if (Fac17.IsChecked == true)
                fillPot(wt1);
            if (Fac18.IsChecked == true)
                fillPot(wtek);
            if (Fac19.IsChecked == true)
                fillPot(wt2);*/
        }

        public int ListLength(List<string> str)
        {
            int length = str.ToArray().Length;
            return length;
        }

        public void reset()
        {
            int length = ListLength(pot);
            for (int i = length - 1; i >= 0; i--)
            {
                pot.RemoveAt(i);
            }
        }

        List<string> randomize(List<string> vec, int n, List<string> choices)
        {
            int size = ListLength(vec), x = randNum(size);
            if (n > ListLength(choices))
            {
                choices.Add(vec.ElementAt(x));
                vec.RemoveAt(x);
                return randomize(vec, n, choices);
            }
            else
                return choices;
        }

        public void randomizer(List<string> vec, int n, int o, List<string> choices)
        {
            int p = n * o;
            List<string> vec2;
            string str = "";
            vec2 = randomize(vec, p, choices);
            str += "Your choices are:";
            for (int i = 0; i < n; i++)
            {
                str += "\n\nPlayer " + (i + 1) + ": ";
                /*for (int j = 0; j < ListLength(vec2) - 1; j++)
                {
                    str += vec2.ElementAt(j) + ", ";
                }*/
                for (int j = 0; j < o - 1; j++)
                {
                    str += vec2.ElementAt(j) + ", ";
                }
                str += "and " + vec2.ElementAt(o - 1);
                vec2.RemoveRange(0, o);
            }
            MessageBox.Show(str);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            reset();
            if (NumPlayer.Text == "" || FacPer.Text == "")
            {
                MessageBox.Show("Be sure to fill all text boxes.");
            }
            else
            {
                int numPlay = int.Parse(NumPlayer.Text);
                int facPer = int.Parse(FacPer.Text);


                if (numPlay <= 1 || facPer <= 1)
                {
                    if (numPlay <= 1)
                    {
                        MessageBox.Show("There must be at least 2 players.");
                    }
                    else
                        MessageBox.Show("There must be at least 2 factions per player.");
                }
                else if (numPlay * facPer > 64)
                {
                    MessageBox.Show("There are not enough factions for that many people, please change one of the entries.");
                }
                else
                {
                    //int numPlay = int.Parse(NumPlayer.Text), facPer = int.Parse(FacPer.Text);
                    List<string> choices = new List<string>();
                    if (Fac1.IsChecked == false && Fac2.IsChecked == false && Fac3.IsChecked == false && Fac4.IsChecked == false &&
                        Fac5.IsChecked == false && Fac6.IsChecked == false && Fac7.IsChecked == false && Fac8.IsChecked == false &&
                        Fac9.IsChecked == false && Fac10.IsChecked == false && Fac11.IsChecked == false && Fac12.IsChecked == false &&
                        Fac13.IsChecked == false && Fac14.IsChecked == false && Fac15.IsChecked == false && Fac16.IsChecked == false /*&&
                        Fac17.IsChecked == false && Fac18.IsChecked == false && Fac19.IsChecked == false*/)
                    {
                        MessageBox.Show("Please select one or more expansions.");
                    }
                    else
                    {
                        fillPot();
                        if (ListLength(pot) >= (numPlay * facPer))
                        {
                            randomizer(pot, numPlay, facPer, choices);
                        }
                        else
                        {
                            MessageBox.Show("Not enough factions chosen.");
                        }
                    }
                }
            }
        }

        private void AllFacs_Checked(object sender, RoutedEventArgs e)
        {
            Fac1.IsChecked = true;
            Fac2.IsChecked = true;
            Fac3.IsChecked = true;
            Fac4.IsChecked = true;
            Fac5.IsChecked = true;
            Fac6.IsChecked = true;
            Fac7.IsChecked = true;
            Fac8.IsChecked = true;
            Fac9.IsChecked = true;
            Fac10.IsChecked = true;
            Fac11.IsChecked = true;
            Fac12.IsChecked = true;
            Fac13.IsChecked = true;
            Fac14.IsChecked = true;
            Fac15.IsChecked = true;
            Fac16.IsChecked = true;
            Fac17.IsChecked = true;
            Fac18.IsChecked = true;
            Fac19.IsChecked = true;
        }

        private void AllFacs_Unchecked(object sender, RoutedEventArgs e)
        {
            Fac1.IsChecked = false;
            Fac2.IsChecked = false;
            Fac3.IsChecked = false;
            Fac4.IsChecked = false;
            Fac5.IsChecked = false;
            Fac6.IsChecked = false;
            Fac7.IsChecked = false;
            Fac8.IsChecked = false;
            Fac9.IsChecked = false;
            Fac10.IsChecked = false;
            Fac11.IsChecked = false;
            Fac12.IsChecked = false;
            Fac13.IsChecked = false;
            Fac14.IsChecked = false;
            Fac15.IsChecked = false;
            Fac16.IsChecked = false;
            Fac17.IsChecked = false;
            Fac18.IsChecked = false;
            Fac19.IsChecked = false;
        }

        private void Faction_Unchecked(object sender, RoutedEventArgs e)
        {
            AllFacs.Unchecked -= AllFacs_Unchecked;
            AllFacs.IsChecked = false;
            AllFacs.Unchecked += AllFacs_Unchecked;
        }

        private void All_Factions_Checked(object sender, RoutedEventArgs e)
        {
            if (Fac1.IsChecked == true && Fac2.IsChecked == true && Fac3.IsChecked == true && Fac4.IsChecked == true &&
                    Fac5.IsChecked == true && Fac6.IsChecked == true && Fac7.IsChecked == true && Fac8.IsChecked == true &&
                    Fac9.IsChecked == true && Fac10.IsChecked == true && Fac11.IsChecked == true && Fac12.IsChecked == true &&
                    Fac13.IsChecked == true && Fac14.IsChecked == true && Fac15.IsChecked == true && Fac16.IsChecked == true &&
                    Fac17.IsChecked == true && Fac18.IsChecked == true && Fac19.IsChecked == true)
                AllFacs.IsChecked = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            sheet.Visibility = Visibility.Hidden;
            //DeleteMe.Visibility = Visibility.Hidden;
            NumPlayerBlock1.Visibility = Visibility.Hidden;
            FacPerBlock1.Visibility = Visibility.Hidden;
            AllFacs1.Visibility = Visibility.Hidden;
            Fact1.Visibility = Visibility.Hidden;
            Fact2.Visibility = Visibility.Hidden;
            Fact3.Visibility = Visibility.Hidden;
            Fact4.Visibility = Visibility.Hidden;
            Fact5.Visibility = Visibility.Hidden;
            Fact6.Visibility = Visibility.Hidden;
            Fact7.Visibility = Visibility.Hidden;
            Fact8.Visibility = Visibility.Hidden;
            Fact9.Visibility = Visibility.Hidden;
            Fact10.Visibility = Visibility.Hidden;
            Fact11.Visibility = Visibility.Hidden;
            Fact12.Visibility = Visibility.Hidden;
            Fact13.Visibility = Visibility.Hidden;
            Fact14.Visibility = Visibility.Hidden;
            Fact15.Visibility = Visibility.Hidden;
            Fact16.Visibility = Visibility.Hidden;
            Fact17.Visibility = Visibility.Hidden;
            Fact18.Visibility = Visibility.Hidden;
            Fact19.Visibility = Visibility.Hidden;
            NumPlayerBlock.Visibility = Visibility.Hidden;
            NumPlayerShadow.Visibility = Visibility.Hidden;
            NumPlayer.Visibility = Visibility.Hidden;
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            FacPerBlock.Visibility = Visibility.Hidden;
            FacPerShadow.Visibility = Visibility.Hidden;
            FacPer.Visibility = Visibility.Hidden;
            AllFacs.Visibility = Visibility.Hidden;
            Fac1.Visibility = Visibility.Hidden;
            Fac2.Visibility = Visibility.Hidden;
            Fac3.Visibility = Visibility.Hidden;
            Fac4.Visibility = Visibility.Hidden;
            Fac5.Visibility = Visibility.Hidden;
            Fac6.Visibility = Visibility.Hidden;
            Fac7.Visibility = Visibility.Hidden;
            Fac8.Visibility = Visibility.Hidden;
            Fac9.Visibility = Visibility.Hidden;
            Fac10.Visibility = Visibility.Hidden;
            Fac11.Visibility = Visibility.Hidden;
            Fac12.Visibility = Visibility.Hidden;
            Fac13.Visibility = Visibility.Hidden;
            Fac14.Visibility = Visibility.Hidden;
            Fac15.Visibility = Visibility.Hidden;
            Fac16.Visibility = Visibility.Hidden;
            Fac17.Visibility = Visibility.Hidden;
            Fac18.Visibility = Visibility.Hidden;
            Fac19.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            button3.Visibility = Visibility.Hidden;
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (button2.Visibility == Visibility.Hidden)
            {
                sheet.Visibility = Visibility.Visible;
                //DeleteMe.Visibility = Visibility.Visible;
                NumPlayerBlock1.Visibility = Visibility.Visible;
                FacPerBlock1.Visibility = Visibility.Visible;
                AllFacs1.Visibility = Visibility.Visible;
                Fact1.Visibility = Visibility.Visible;
                Fact2.Visibility = Visibility.Visible;
                Fact3.Visibility = Visibility.Visible;
                Fact4.Visibility = Visibility.Visible;
                Fact5.Visibility = Visibility.Visible;
                Fact6.Visibility = Visibility.Visible;
                Fact7.Visibility = Visibility.Visible;
                Fact8.Visibility = Visibility.Visible;
                Fact9.Visibility = Visibility.Visible;
                Fact10.Visibility = Visibility.Visible;
                Fact11.Visibility = Visibility.Visible;
                Fact12.Visibility = Visibility.Visible;
                Fact13.Visibility = Visibility.Visible;
                Fact14.Visibility = Visibility.Visible;
                Fact15.Visibility = Visibility.Visible;
                Fact16.Visibility = Visibility.Visible;
                Fact17.Visibility = Visibility.Visible;
                Fact18.Visibility = Visibility.Visible;
                Fact19.Visibility = Visibility.Visible;
                NumPlayerBlock.Visibility = Visibility.Visible;
                NumPlayerShadow.Visibility = Visibility.Visible;
                NumPlayer.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Visible;
                button1.Visibility = Visibility.Visible;
                FacPerBlock.Visibility = Visibility.Visible;
                FacPerShadow.Visibility = Visibility.Visible;
                FacPer.Visibility = Visibility.Visible;
                AllFacs.Visibility = Visibility.Visible;
                Fac1.Visibility = Visibility.Visible;
                Fac2.Visibility = Visibility.Visible;
                Fac3.Visibility = Visibility.Visible;
                Fac4.Visibility = Visibility.Visible;
                Fac5.Visibility = Visibility.Visible;
                Fac6.Visibility = Visibility.Visible;
                Fac7.Visibility = Visibility.Visible;
                Fac8.Visibility = Visibility.Visible;
                Fac9.Visibility = Visibility.Visible;
                Fac10.Visibility = Visibility.Visible;
                Fac11.Visibility = Visibility.Visible;
                Fac12.Visibility = Visibility.Visible;
                Fac13.Visibility = Visibility.Visible;
                Fac14.Visibility = Visibility.Visible;
                Fac15.Visibility = Visibility.Visible;
                Fac16.Visibility = Visibility.Visible;
                Fac17.Visibility = Visibility.Visible;
                Fac18.Visibility = Visibility.Visible;
                Fac19.Visibility = Visibility.Visible;
                button2.Visibility = Visibility.Visible;
                button3.Visibility = Visibility.Visible;
                //MessageBox.Show(NumPlayer.ActualWidth.ToString() + "\n" + NumPlayerBlock.ActualHeight.ToString());
            }
        }

        int bg = 1;

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (bg == 0)
            {
                BitmapImage SURB = new BitmapImage(new Uri("C:\\Users\\Jake\\Documents\\Jake's Stuff\\Other\\Random Programs\\Smash Up Randomizer Interactable\\SURBackground.bmp"));
                image.Source = SURB;
                bg = 1;
            }
            else
            {
                BitmapImage SUB = new BitmapImage(new Uri("C:\\Users\\Jake\\Documents\\Jake's Stuff\\Other\\Random Programs\\Smash Up Randomizer Interactable\\SUBackground.bmp"));
                image.Source = SUB;
                bg = 0;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Exit", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
