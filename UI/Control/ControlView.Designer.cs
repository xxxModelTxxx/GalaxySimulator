using PhysicsEngine;

namespace UI
{
    partial class ControlView
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
            gravityTextBox = new TextBox();
            gravityLabel = new Label();
            lightSpeedLabel = new Label();
            lightSpeedTextBox = new TextBox();
            lightSpeedRatioLabel = new Label();
            lightSpeedRatioTextBox = new TextBox();
            timeStepTextBox = new TextBox();
            timeStepLabel = new Label();
            SuspendLayout();
            // 
            // gravityTextBox
            // 
            gravityTextBox.Location = new Point(66, 6);
            gravityTextBox.Name = "gravityTextBox";
            gravityTextBox.Size = new Size(134, 23);
            gravityTextBox.TabIndex = 0;
            gravityTextBox.Text = PhysicalConstants.GravityConstant.ToString();
            gravityTextBox.TextAlign = HorizontalAlignment.Right;
            gravityTextBox.TextChanged += gravityTextBox_TextChanged;
            // 
            // gravityLabel
            // 
            gravityLabel.AutoSize = true;
            gravityLabel.Location = new Point(45, 9);
            gravityLabel.Name = "gravityLabel";
            gravityLabel.Size = new Size(15, 15);
            gravityLabel.TabIndex = 1;
            gravityLabel.Text = "G";
            gravityLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lightSpeedLabel
            // 
            lightSpeedLabel.AutoSize = true;
            lightSpeedLabel.Location = new Point(47, 38);
            lightSpeedLabel.Name = "lightSpeedLabel";
            lightSpeedLabel.Size = new Size(13, 15);
            lightSpeedLabel.TabIndex = 1;
            lightSpeedLabel.Text = "c";
            lightSpeedLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lightSpeedTextBox
            // 
            lightSpeedTextBox.Location = new Point(66, 35);
            lightSpeedTextBox.Name = "lightSpeedTextBox";
            lightSpeedTextBox.Size = new Size(134, 23);
            lightSpeedTextBox.TabIndex = 0;
            lightSpeedTextBox.Text = PhysicalConstants.LightSpeed.ToString();
            lightSpeedTextBox.TextAlign = HorizontalAlignment.Right;
            lightSpeedTextBox.TextChanged += lightSpeedTextBox_TextChanged;
            // 
            // lightSpeedRatioLabel
            // 
            lightSpeedRatioLabel.AutoSize = true;
            lightSpeedRatioLabel.Location = new Point(12, 67);
            lightSpeedRatioLabel.Name = "lightSpeedRatioLabel";
            lightSpeedRatioLabel.Size = new Size(48, 15);
            lightSpeedRatioLabel.TabIndex = 1;
            lightSpeedRatioLabel.Text = "Vmax/c";
            lightSpeedRatioLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lightSpeedRatioTextBox
            // 
            lightSpeedRatioTextBox.Location = new Point(66, 64);
            lightSpeedRatioTextBox.Name = "lightSpeedRatioTextBox";
            lightSpeedRatioTextBox.Size = new Size(134, 23);
            lightSpeedRatioTextBox.TabIndex = 0;
            lightSpeedRatioTextBox.Text = PhysicalConstants.NearLightSpeedRatio.ToString();
            lightSpeedRatioTextBox.TextAlign = HorizontalAlignment.Right;
            lightSpeedRatioTextBox.TextChanged += lightSpeedRatioTextBox_TextChanged;
            // 
            // timeStepTextBox
            // 
            timeStepTextBox.Location = new Point(66, 93);
            timeStepTextBox.Name = "timeStepTextBox";
            timeStepTextBox.Size = new Size(134, 23);
            timeStepTextBox.TabIndex = 0;
            timeStepTextBox.Text = PhysicalConstants.TimeStep.ToString();
            timeStepTextBox.TextAlign = HorizontalAlignment.Right;
            timeStepTextBox.TextChanged += timeStepTextBox_TextChanged;
            // 
            // timeStepLabel
            // 
            timeStepLabel.AutoSize = true;
            timeStepLabel.Location = new Point(47, 96);
            timeStepLabel.Name = "timeStepLabel";
            timeStepLabel.Size = new Size(13, 15);
            timeStepLabel.TabIndex = 1;
            timeStepLabel.Text = "T";
            timeStepLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ControlView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(210, 126);
            Controls.Add(timeStepLabel);
            Controls.Add(lightSpeedRatioLabel);
            Controls.Add(lightSpeedLabel);
            Controls.Add(gravityLabel);
            Controls.Add(timeStepTextBox);
            Controls.Add(lightSpeedRatioTextBox);
            Controls.Add(lightSpeedTextBox);
            Controls.Add(gravityTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ControlView";
            Text = "Control Panel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox gravityTextBox;
        private Label gravityLabel;
        private Label lightSpeedLabel;
        private TextBox lightSpeedTextBox;
        private Label lightSpeedRatioLabel;
        private TextBox lightSpeedRatioTextBox;
        private TextBox timeStepTextBox;
        private Label timeStepLabel;
    }
}