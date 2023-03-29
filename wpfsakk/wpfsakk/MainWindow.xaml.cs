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

namespace wpfsakk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[,] tabla = new string[8, 8];
        Image[,] kepek;
        Button[,] gombok;
        string milep;
        int voltx;
        int volty;
        BitmapImage white_bishop = new BitmapImage(new Uri("/bin/debug/assets/bishop_white.png", UriKind.Relative));
        BitmapImage lep = new BitmapImage(new Uri("/bin/debug/assets/lep.png", UriKind.Relative));
        BitmapImage mt = new BitmapImage(new Uri("/bin/debug/assets/mt.png", UriKind.Relative));
        public MainWindow()
        {
            
            

            InitializeComponent();
            kepek = new Image[8, 8] {
                { Img_a8, Img_b8, Img_c8, Img_d8, Img_e8, Img_f8, Img_g8, Img_h8 },
                { Img_a7, Img_b7, Img_c7, Img_d7, Img_e7, Img_f7, Img_g7, Img_h7 },
                { Img_a6, Img_b6, Img_c6, Img_d6, Img_e6, Img_f6, Img_g6, Img_h6 },
                { Img_a5, Img_b5, Img_c5, Img_d5, Img_e5, Img_f5, Img_g5, Img_h5 },
                { Img_a4, Img_b4, Img_c4, Img_d4, Img_e4, Img_f4, Img_g4, Img_h4 },
                { Img_a3, Img_b3, Img_c3, Img_d3, Img_e3, Img_f3, Img_g3, Img_h3 },
                { Img_a2, Img_b2, Img_c2, Img_d2, Img_e2, Img_f2, Img_g2, Img_h2 },
                { Img_a1, Img_b1, Img_c1, Img_d1, Img_e1, Img_f1, Img_g1, Img_h1 },
            };
            gombok = new Button[8,8] {
                { Btn_a8, Btn_b8, Btn_c8, Btn_d8, Btn_e8, Btn_f8, Btn_g8, Btn_h8 },
                { Btn_a7, Btn_b7, Btn_c7, Btn_d7, Btn_e7, Btn_f7, Btn_g7, Btn_h7 },
                { Btn_a6, Btn_b6, Btn_c6, Btn_d6, Btn_e6, Btn_f6, Btn_g6, Btn_h6 },
                { Btn_a5, Btn_b5, Btn_c5, Btn_d5, Btn_e5, Btn_f5, Btn_g5, Btn_h5 },
                { Btn_a4, Btn_b4, Btn_c4, Btn_d4, Btn_e4, Btn_f4, Btn_g4, Btn_h4 },
                { Btn_a3, Btn_b3, Btn_c3, Btn_d3, Btn_e3, Btn_f3, Btn_g3, Btn_h3 },
                { Btn_a2, Btn_b2, Btn_c2, Btn_d2, Btn_e2, Btn_f2, Btn_g2, Btn_h2 },
                { Btn_a1, Btn_b1, Btn_c1, Btn_d1, Btn_e1, Btn_f1, Btn_g1, Btn_h1 },
            };
            kezdes();
        }
        private void kezdes()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    tabla[i, j] = "-";
                }
            }
            tabla[4, 4] = "futo";
            reload();
        }
        private void lepes(int y, int x)
        {
            switch (tabla[x,y])
            {
                case "-":
                    reload();
                    break;
                case "futo":
                    milep = "futo";
                    voltx = x;
                    volty = y;
                    for (int i = 0; i < 8; i++)
                    {
                        try
                        {
                            if (tabla[x + i, y + i] == "-")
                            {
                                kepek[x + i, y + i].Source = lep;
                                tabla[x + i, y + i] = ".";
                            }
                        }
                        catch (Exception)
                        {


                        }
                        try
                        {
                            if (tabla[x - i, y + i] == "-")
                            {
                                kepek[x - i, y + i].Source = lep;
                                tabla[x - i, y + i] = ".";
                            }
                        }
                        catch (Exception)
                        {

                            
                        }
                        try
                        {
                            if (tabla[x + i, y - i] == "-")
                            {
                                kepek[x + i, y - i].Source = lep;
                                tabla[x + i, y - i] = ".";
                            }
                        }
                        catch (Exception)
                        {


                        }
                        try
                        {
                            if (tabla[x - i, y - i] == "-")
                            {
                                kepek[x - i, y - i].Source = lep;
                                tabla[x - i, y - i] = ".";
                            }
                        }
                        catch (Exception)
                        {


                        }
                    }
                    
                    break;
                case ".":
                    
                    tabla[x, y] = milep;
                    tabla[voltx, volty] = "-";
                    
                    reload();
                    break;
                default:
                    break;
            }

        }
        private void reload()
        {
            milep = "-";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    switch (tabla[i,j])
                    {
                        case "-":
                        case ".":
                            kepek[i,j].Source= mt;
                            tabla[i, j] = "-";
                            break;
                        case "futo":
                            kepek[i, j].Source = white_bishop;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void Btn_a8_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 0);
        }

        private void Btn_a7_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 1);
        }

        private void Btn_a6_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 2);
        }

        private void Btn_a5_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 3);
        }

        private void Btn_a4_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 4);
        }

        private void Btn_a3_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 5);
        }

        private void Btn_a2_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 6);
        }

        private void Btn_a1_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 7);
        }

        private void Btn_b8_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 0);
        }

        private void Btn_b7_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 1);
        }

        private void Btn_b6_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 2);
        }

        private void Btn_b5_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 3);
        }

        private void Btn_b4_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 4);
        }

        private void Btn_b3_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 5);
        }

        private void Btn_b2_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 6);
        }

        private void Btn_b1_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 7);
        }

        private void Btn_c8_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 0);
        }

        private void Btn_c7_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 1);
        }

        private void Btn_c6_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 2);
        }

        private void Btn_c5_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 3);
        }

        private void Btn_c4_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 4);
        }

        private void Btn_c3_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 5);
        }

        private void Btn_c2_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 6);
        }

        private void Btn_c1_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 7);
        }

        private void Btn_d8_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 0);
        }

        private void Btn_d7_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 1);
        }

        private void Btn_d6_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 2);
        }

        private void Btn_d5_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 3);
        }

        private void Btn_d4_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 4);
        }

        private void Btn_d3_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 5);
        }

        private void Btn_d2_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 6);
        }

        private void Btn_d1_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 7);
        }

        private void Btn_e8_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 0);
        }

        private void Btn_e7_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 1);
        }

        private void Btn_e6_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 2);
        }

        private void Btn_e5_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 3);
        }

        private void Btn_e4_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 4);
        }

        private void Btn_e3_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 5);
        }

        private void Btn_e2_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 6);
        }

        private void Btn_e1_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 7);
        }

        private void Btn_f8_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 0);
        }

        private void Btn_f7_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 1);
        }

        private void Btn_f6_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 2);
        }

        private void Btn_f5_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 3);
        }

        private void Btn_f4_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 4);
        }

        private void Btn_f3_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 5);
        }

        private void Btn_f2_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 6);
        }

        private void Btn_f1_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 7);
        }

        private void Btn_g8_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 0);
        }

        private void Btn_g7_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 1);
        }

        private void Btn_g6_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 2);
        }

        private void Btn_g5_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 3);
        }

        private void Btn_g4_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 4);
        }

        private void Btn_g3_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 5);
        }

        private void Btn_g2_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 6);
        }

        private void Btn_g1_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 7);
        }

        private void Btn_h8_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 0);
        }

        private void Btn_h7_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 1);
        }

        private void Btn_h6_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 2);
        }

        private void Btn_h5_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 3);
        }

        private void Btn_h4_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 4);
        }

        private void Btn_h3_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 5);
        }

        private void Btn_h2_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 6);
        }

        private void Btn_h1_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 7);
        }
    }
}
