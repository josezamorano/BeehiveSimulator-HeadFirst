using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldGraphicsBehive.BeeHiveHelper;

namespace WorldGraphicsBehive
{
    public partial class BeeHiveForm : Form
    {
        Timer _beeAnimationTimer;
        int insideHiveFormWidth = 0;
        int insideHiveFormHeight = 0;
        private BeeHiveGraphics BeehiveGraphsInsideHive;  
        private BeeHive BeehiveFromDashboardForm; 
        private Bee beeObjectFromDashboardForm;

        bool enableForm;
        public BeeHiveForm()
        {
            insideHiveFormWidth = 300;
            insideHiveFormHeight = 310;   

            Point p = new Point();
            p.X = insideHiveFormWidth+20;
            p.Y = insideHiveFormHeight+40;
            this.MinimumSize = new Size(p.X, p.Y);
            this.MaximumSize = new Size(p.X, p.Y);
            InitializeComponent();
            this.Paint += new PaintEventHandler(BeeHiveForm_Paint);
        }
        public void SetBeeObject(Bee bee)
        {
            beeObjectFromDashboardForm = bee;
        }
        public void SetBeeHiveObject(BeeHive beeHive)
        {
            BeehiveFromDashboardForm = beeHive;
        } 
        public void SetBeeHiveGraphicsObject(BeeHiveGraphics graphs)
        {
            BeehiveGraphsInsideHive = graphs;
            BeehiveGraphsInsideHive.GetFormWidthAndHeight(insideHiveFormHeight, insideHiveFormWidth);
        }
        public bool EnableFormHandlersAndTimers(bool command)
        {
            if (command == true) 
            {
                enableForm = true;
                _beeAnimationTimer.Enabled = true;   
            }
            else
            {          
                enableForm = false;
                _beeAnimationTimer.Enabled = false;          
            }
            return enableForm;
        }
        //We Create methods to bring the objects from the Dashboard Form
        public void SetBeeHiveFormTimer(Timer timer)
        {
            _beeAnimationTimer = timer;
            _beeAnimationTimer.Interval = 1;
            _beeAnimationTimer.Start();
            _beeAnimationTimer.Tick += new EventHandler(BeeAnimationTimer_Tick);
        }
        private void BeeHiveForm_Paint(object sender, PaintEventArgs e)
        {
           //Sky
           e.Graphics.FillRectangle(Brushes.LightBlue, 0, 0, insideHiveFormWidth, insideHiveFormHeight);        
           BeehiveGraphsInsideHive.PaintInsideHivedForm(e);

           if (enableForm == false)
           {
               return;
           }
           beeObjectFromDashboardForm.SetExitHiveData(BeehiveGraphsInsideHive);        
           beeObjectFromDashboardForm.PaintAllBees(e,"insideHive");   
        } 
        private void BeeAnimationTimer_Tick(object sender, EventArgs e)
        {
            beeObjectFromDashboardForm.SetBeehiveFromForm(BeehiveFromDashboardForm);
            beeObjectFromDashboardForm.SetBeeListFromBeehive(BeehiveFromDashboardForm.BeeList);
            //Bee Animate Bee
            beeObjectFromDashboardForm.GenerateBeeWingsMovement(BeehiveFromDashboardForm);
            this.Refresh();
            beeObjectFromDashboardForm.SetBeeTarget(BeehiveFromDashboardForm);
            this.Refresh();
        }
    }
}
