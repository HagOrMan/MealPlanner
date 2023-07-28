using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeeklyMealPlannerXMLTest
{
    public partial class AddBBQForm : Form
    {
        public AddBBQForm()
        {
            InitializeComponent();
        }

        //Hides the window.
        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddSideBtn_Click(object sender, EventArgs e)
        {
            MainWindow.AddBbq(NameBox.Text);
            NameBox.Text = "";
            if (ManyMealsBox.Checked == false)
            {
                this.Hide();
            }
        }
    }
}
