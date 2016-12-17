using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;

using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Drawing;

using static System.Math;

namespace Point_Font_Temple
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void DrawPictureBoxEdge()
        //{
        //    //g = this.winform_picture_box.CreateGraphics();
        //    //g.Dispose();
        //    //g.DrawRectangle(SystemPens.Highlight, 0, 0, (float)Width - 180, (float)Height - 50);
        //}

        //private void SetDefaultColor(Bitmap _bitmap,Color _color)
        //{
        //    if (_bitmap == null)
        //        return;
        //    for (int x = 0; x < _bitmap.Width; x++)
        //    {
        //        for (int y = 0; y < _bitmap.Height; y++)
        //        {
        //            _bitmap.SetPixel(x,y,_color);
        //        }
        //    }
        //}

        //private double CalculateNum(Bitmap _bmp,int _xArray,int _yArray)
        //{
        //    double _num = 0;
        //    if (_bmp == null) return _num;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        int x = i + 3 * _xArray;
        //        double xWeiPow = Pow(256, i);
        //        for (int j = 1; j <= 8; j++)
        //        {
        //            int y = _bmp.Height - j - 8 * _yArray;
        //            //double yWeiPow = Pow(2,j-1);
        //            //
        //            _num += _bmp.GetPixel(x, y).GetBrightness() < 0.5 ? xWeiPow * Pow(2, j - 1) : 0;
        //        }
        //    }
        //    return _num;
        //}

        private void ZH_btn_Click(object sender, RoutedEventArgs e)
        {
            SimpleFont myFont = new SimpleFont(this.winform_picture_box.CreateGraphics());
            
            myFont.OnUpdateDrawing(this.winform_picture_box.Width, this.winform_picture_box.Height);
             
            StringBuilder strbuild = new StringBuilder();
            char[] _chars = this.input_txtbox.Text.ToCharArray();

            for (int i = 0; i < _chars.Length; i++)
            {
                string input_txt = _chars[i].ToString();
                int width_arrange = i % 12;
                int height_arrange = i / 12;
                string out_txt = myFont.DoFont(input_txt, Brushes.Bisque, Brushes.LightCoral, width_arrange, height_arrange);
                strbuild.AppendFormat("#define {0} {1});Font();\n",input_txt,out_txt);
                //strbuild.AppendLine( out_txt );
            }

            this.out_result_block.Text = strbuild.ToString();
        }

        /////////////////////////
        void Click_Link(string link)
        {
            System.Diagnostics.Process.Start(link);
        }

        private void User_Shadertoy_link_Click(object sender, RoutedEventArgs e)
        {
           this.Click_Link("https://www.shadertoy.com/user/834144373");
        }

        private void User_Twitter_link_Click(object sender, RoutedEventArgs e)
        {
           this.Click_Link("https://twitter.com/834144373zhu");
        }

        private void User_Facebook_link_Click(object sender, RoutedEventArgs e)
        {
           this.Click_Link("https://www.facebook.com/834144373TNWX");
        }

        private void User_CSDN_link_Click(object sender, RoutedEventArgs e)
        {
           this.Click_Link("http://blog.csdn.net/baidu_26153715/article/");
        }

        private void User_PowLanguage_link_Click(object sender, RoutedEventArgs e)
        {
            this.Click_Link("https://www.shadertoy.com/view/XsGXzt");
        }
    }
}
