
namespace WeeklyMealPlannerXMLTest
{
    partial class AddMealForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.GoBackBtn = new System.Windows.Forms.Button();
            this.AddMealBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.TimeBox = new System.Windows.Forms.TextBox();
            this.ManyMealsBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "On this page you can add a new meal to your meal planner";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // GoBackBtn
            // 
            this.GoBackBtn.Location = new System.Drawing.Point(38, 211);
            this.GoBackBtn.Name = "GoBackBtn";
            this.GoBackBtn.Size = new System.Drawing.Size(93, 50);
            this.GoBackBtn.TabIndex = 1;
            this.GoBackBtn.Text = "Go Back";
            this.GoBackBtn.UseVisualStyleBackColor = true;
            this.GoBackBtn.Click += new System.EventHandler(this.GoBackBtn_Click);
            // 
            // AddMealBtn
            // 
            this.AddMealBtn.Location = new System.Drawing.Point(203, 211);
            this.AddMealBtn.Name = "AddMealBtn";
            this.AddMealBtn.Size = new System.Drawing.Size(140, 50);
            this.AddMealBtn.TabIndex = 2;
            this.AddMealBtn.Text = "Add Meal";
            this.AddMealBtn.UseVisualStyleBackColor = true;
            this.AddMealBtn.Click += new System.EventHandler(this.AddMealBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(102, 71);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(241, 22);
            this.NameBox.TabIndex = 5;
            // 
            // TimeBox
            // 
            this.TimeBox.Location = new System.Drawing.Point(102, 119);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.Size = new System.Drawing.Size(241, 22);
            this.TimeBox.TabIndex = 6;
            // 
            // ManyMealsBox
            // 
            this.ManyMealsBox.AutoSize = true;
            this.ManyMealsBox.Location = new System.Drawing.Point(50, 171);
            this.ManyMealsBox.Name = "ManyMealsBox";
            this.ManyMealsBox.Size = new System.Drawing.Size(196, 21);
            this.ManyMealsBox.TabIndex = 7;
            this.ManyMealsBox.Text = "I am adding multiple meals";
            this.ManyMealsBox.UseVisualStyleBackColor = true;
            this.ManyMealsBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // AddMealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 296);
            this.Controls.Add(this.ManyMealsBox);
            this.Controls.Add(this.TimeBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddMealBtn);
            this.Controls.Add(this.GoBackBtn);
            this.Controls.Add(this.label1);
            this.Name = "AddMealForm";
            this.Text = "Add a Meal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GoBackBtn;
        private System.Windows.Forms.Button AddMealBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox TimeBox;
        private System.Windows.Forms.CheckBox ManyMealsBox;
    }
}