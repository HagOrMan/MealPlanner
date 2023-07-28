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
    public partial class AddSideForm : Form
    {
        public AddSideForm()
        {
            InitializeComponent();
        }

        //Goes back to the main page.
        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //Adds the side to the doc.
        private void AddSideBtn_Click(object sender, EventArgs e)
        {
            MainWindow.AddSide(NameBox.Text);
            NameBox.Text = "";
            if (ManyMealsBox.Checked == false)
            {
                this.Hide();
            }
        }
    }
}
