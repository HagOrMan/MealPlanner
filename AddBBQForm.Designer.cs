
namespace WeeklyMealPlannerXMLTest
{
    partial class AddBBQForm
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
            this.ManyMealsBox = new System.Windows.Forms.CheckBox();
            this.AddSideBtn = new System.Windows.Forms.Button();
            this.GoBackBtn = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ManyMealsBox
            // 
            this.ManyMealsBox.AutoSize = true;
            this.ManyMealsBox.Location = new System.Drawing.Point(57, 110);
            this.ManyMealsBox.Name = "ManyMealsBox";
            this.ManyMealsBox.Size = new System.Drawing.Size(229, 21);
            this.ManyMealsBox.TabIndex = 17;
            this.ManyMealsBox.Text = "I am adding multiple BBQ meals";
            this.ManyMealsBox.UseVisualStyleBackColor = true;
            // 
            // AddSideBtn
            // 
            this.AddSideBtn.Location = new System.Drawing.Point(210, 150);
            this.AddSideBtn.Name = "AddSideBtn";
            this.AddSideBtn.Size = new System.Drawing.Size(140, 50);
            this.AddSideBtn.TabIndex = 16;
            this.AddSideBtn.Text = "Add BBQ Meal";
            this.AddSideBtn.UseVisualStyleBackColor = true;
            this.AddSideBtn.Click += new System.EventHandler(this.AddSideBtn_Click);
            // 
            // GoBackBtn
            // 
            this.GoBackBtn.Location = new System.Drawing.Point(45, 150);
            this.GoBackBtn.Name = "GoBackBtn";
            this.GoBackBtn.Size = new System.Drawing.Size(93, 50);
            this.GoBackBtn.TabIndex = 15;
            this.GoBackBtn.Text = "Go Back";
            this.GoBackBtn.UseVisualStyleBackColor = true;
            this.GoBackBtn.Click += new System.EventHandler(this.GoBackBtn_Click);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(109, 65);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(241, 22);
            this.NameBox.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "On this page you can add a new BBQ meal to your meal planner";
            // 
            // AddBBQForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 260);
            this.Controls.Add(this.ManyMealsBox);
            this.Controls.Add(this.AddSideBtn);
            this.Controls.Add(this.GoBackBtn);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddBBQForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ManyMealsBox;
        private System.Windows.Forms.Button AddSideBtn;
        private System.Windows.Forms.Button GoBackBtn;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}