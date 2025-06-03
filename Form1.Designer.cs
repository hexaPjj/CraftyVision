namespace CraftyVision
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            ProgressBar = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            label1 = new Label();
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            ProgressT = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.AnimateWindow = true;
            guna2BorderlessForm1.BorderRadius = 20;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockForm = false;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ProgressBar
            // 
            ProgressBar.BackColor = Color.Transparent;
            ProgressBar.FillColor = Color.FromArgb(200, 213, 218, 223);
            ProgressBar.FillThickness = 7;
            ProgressBar.Font = new Font("Segoe UI", 12F);
            ProgressBar.ForeColor = Color.White;
            ProgressBar.Image = (Image)resources.GetObject("ProgressBar.Image");
            ProgressBar.Location = new Point(54, 45);
            ProgressBar.Minimum = 0;
            ProgressBar.Name = "ProgressBar";
            ProgressBar.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Solid;
            ProgressBar.ProgressColor = Color.FromArgb(41, 127, 240);
            ProgressBar.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            ProgressBar.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            ProgressBar.ProgressThickness = 7;
            ProgressBar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            ProgressBar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            ProgressBar.Size = new Size(158, 158);
            ProgressBar.TabIndex = 1;
            ProgressBar.Text = "guna2CircleProgressBar1";
            ProgressBar.UseTransparentBackground = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.FromArgb(41, 127, 240);
            label1.Location = new Point(86, 9);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 2;
            label1.Text = "CraftyVision";
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.TargetControl = this;
            guna2DragControl1.TransparentWhileDrag = false;
            // 
            // ProgressT
            // 
            ProgressT.Tick += ProgressT_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(267, 248);
            Controls.Add(label1);
            Controls.Add(ProgressBar);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Crafty Vision";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2CircleProgressBar ProgressBar;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Timer ProgressT;
    }
}
