using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

using System.Drawing;
using static System.Math;


namespace Point_Font_Temple
{
    class SimpleFont
    {
        private Bitmap bmp_origin = new Bitmap(15, 16);
        private Graphics g;
        //配置类设置

        public SimpleFont(Graphics _g)
        {
            this.g = _g;
        }

        //刷新 or 更新
        public void OnUpdateDrawing(double width,double height)
        {
            this.g?.Clear(Color.White);
            g.DrawRectangle(SystemPens.Highlight, 0, 0, (float)width - 5, (float)height - 5 );
        }

        //本类实用函数
        private void SetDefaultColor(Bitmap _bitmap)
        {
            //if (_bitmap == null)
            //    return;
            for (int x = 0; x < _bitmap.Width; x++)
            {
                for (int y = 0; y < _bitmap.Height; y++)
                {
                    _bitmap.SetPixel(x, y, Color.White);
                }
            }
        }
        private double CalculateNum(Bitmap _bmp, int _xArray, int _yArray)
        {
            double _num = 0;
            //if (_bmp == null) return _num;
            for (int i = 0; i < 3; i++)
            {
                int x = i + 3 * _xArray;
                double xWeiPow = Pow(256, i);
                for (int j = 1; j <= 8; j++)
                {
                    int y = _bmp.Height - j - 8 * _yArray;
                    //double yWeiPow = Pow(2,j-1);
                    //
                    //_num = _bmp.GetPixel(x, y).GetBrightness();
                    _num += _bmp.GetPixel(x, y).GetBrightness() < 0.5 ? xWeiPow * Pow(2, j - 1) : 0;
                }
            }
            return _num;
        }

        //显示字体并绘制
        private void DoFillFont(Brush _BackGroundColor,Brush _drawBrush,int _width_arrange,int _height_arrange)
        {
            for (int x = 0; x < this.bmp_origin.Width; x++)
            {
                for (int y = 0; y < this.bmp_origin.Height; y++)
                {
                    Color color = this.bmp_origin.GetPixel(x, y);
                    Brush brush = color.GetBrightness() < 0.5 ? _drawBrush : _BackGroundColor;
                    //Brush brush = new SolidBrush(color);
                    g.FillRectangle(brush, new Rectangle(x*5 + 80*_width_arrange + 10, y*5 + 85*_height_arrange + 30, 4, 4));
                }
            }
        }
        //计算数据并格式化
        private String DoDataNum()
        {
            double[,] max = new double[5, 2];
            StringBuilder text = new StringBuilder();
            string[,] maxFormat = new string[2,5]{
                { "F.a=vec3(",",",",",");F.b=vec2(",","},
                { ");F.c=vec3(",",",",",");F.d=vec2(",","}
            };
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    max[i, j] = CalculateNum(this.bmp_origin, i, j);
                    string temp = Convert.ToInt32(max[i, j]).ToString("x8").TrimStart('0');
                    temp = temp == "" ? "0" : "0x" + temp.ToUpper();
                    text.Append(maxFormat[j,i] + temp);
                    //t += maxFormat[j, i] + "0x" + ((int)max[i, j]).ToString("x8");
                }
            }
            return text.ToString();
        }

        /////通用调用函数
        public string DoFont(string _char,int _arrange,int _width_arrange,int _height_arrange)
        {
            // return DoFont(_char,Brushes.Aquamarine,Brushes.Brown,_arrange,_width_arrange, _height_arrange);
            return "";
        }


        public string DoFont(string _inputChar,Brush _BackGroundColor,Brush _drawBrush,int _width_arrange,int _height_arrange)
        {
            //_strBuild = "";
            if (this.bmp_origin == null) return "!!!";
            SetDefaultColor(this.bmp_origin);
            Graphics graph_bmp = Graphics.FromImage(this.bmp_origin);
            Font font = new Font("新宋体", 12f, FontStyle.Regular);
            graph_bmp.DrawString(_inputChar, font, Brushes.Black,-3,0);

            //显示字体
            DoFillFont(_BackGroundColor,_drawBrush,_width_arrange,_height_arrange);

            //计算数据并格式化
            return DoDataNum();
        }

    }
}
