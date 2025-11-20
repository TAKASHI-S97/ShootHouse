namespace ShootHouse
{
    partial class ShootHouse
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
            SuspendLayout();
            // 
            // ShootHouse
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(944, 681);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(960, 720);
            MinimizeBox = false;
            MinimumSize = new Size(960, 720);
            Name = "ShootHouse";
            Text = "ShootHouse";
            FormClosed += ShootHouse_FormClosed;
            Paint += ShootHouse_Paint;
            KeyDown += ShootHouse_KeyDown;
            KeyUp += ShootHouse_KeyUp;
            MouseDown += ShootHouse_MouseDown;
            ResumeLayout(false);
        }

        #endregion
    }
}
