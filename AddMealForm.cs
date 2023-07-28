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
    public partial class AddMealForm : Form
    {

        //Returns to the main screen.
        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //Adds the text in the fields to the file.
        private void AddMealBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(TimeBox.Text);
                MainWindow.AddMeal(NameBox.Text, TimeBox.Text);
                NameBox.Text = "";
                TimeBox.Text = "";
                if (ManyMealsBox.Checked == false)
                {
                    this.Hide();
                }
            }
            catch (Exception)
            {
                TimeBox.Text = "Not a valid time";
            }
            
        }

        public AddMealForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Accident
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
