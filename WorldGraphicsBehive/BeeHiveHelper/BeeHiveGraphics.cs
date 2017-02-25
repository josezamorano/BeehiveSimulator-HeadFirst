using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WorldGraphicsBehive.BeeHiveHelper
{
    public class BeeHiveGraphics
    {
        int formWidth;
        int formHeight;
        public int HiveCornerAX { get; set; }
        public int HiveCornerAY { get; set; }
        public int HiveWidth { get; set; }
        public int HiveHeight { get; set; }
        public int ExitCornerAX { get; set; }
        public int ExitCornerAY { get; set; }
        public int ExitWidth { get; set; }
        public int ExitHeight { get; set; }
        Bitmap insideHive = null;
        public void GetFormWidthAndHeight(int height, int width)
        {
            formHeight = height;
            formWidth  = width;     
        }
        public void PaintInsideHivedForm(PaintEventArgs e)
        {
            HiveCornerAX  = 35;
            HiveCornerAY = 80;
            //Cartoon Images
            ExitCornerAX = 219;
            ExitCornerAY = 225;
            ExitWidth = 10;
            ExitHeight = 40;
            insideHive = WorldGraphicsBehive.Properties.Resources.Hive__inside_;
            e.Graphics.DrawImage(insideHive, new Rectangle(0, 0, formWidth, formHeight));

            HiveHeight = formHeight-90; //210 px
            HiveWidth = formWidth-60;   //240 px
           

            //Draw BEEHIVE Boundaries Begin********************************************************
            //using (Pen pen = new Pen(Color.Red))
            //{
            //    e.Graphics.DrawRectangle(pen, HiveCornerAX, HiveCornerAY, HiveWidth, HiveHeight);
            //}
            //Draw BEEHIVE Boundaries END==========================================================
            //Draw EXIT Boundaries Begin***********************************************************
            //using (Pen pen = new Pen(Color.Red))
            //{
            //    e.Graphics.DrawRectangle(pen, ExitCornerAX, ExitCornerAY, ExitWidth, ExitHeight);

            //}
            //Draw EXIT Boundaries END=============================================================
        }


    }
}
