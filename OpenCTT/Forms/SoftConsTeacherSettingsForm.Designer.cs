namespace OpenCTT
{
    partial class SoftConsTeacherSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftConsTeacherSettingsForm));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._maxDaysPerWeekTextBox = new System.Windows.Forms.TextBox();
            this._maxHDailyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._maxHContinuouslyTextBox = new System.Windows.Forms.TextBox();
            this._overrideMaxHoursContCheckBox = new System.Windows.Forms.CheckBox();
            this._overrideMaxHoursDailyCheckBox = new System.Windows.Forms.CheckBox();
            this._overrideMaxDaysPerWeekCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._cancelButton, "_cancelButton");
            this._cancelButton.Name = "_cancelButton";
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this._okButton, "_okButton");
            this._okButton.Name = "_okButton";
            // 
            // _maxDaysPerWeekTextBox
            // 
            resources.ApplyResources(this._maxDaysPerWeekTextBox, "_maxDaysPerWeekTextBox");
            this._maxDaysPerWeekTextBox.Name = "_maxDaysPerWeekTextBox";
            this._maxDaysPerWeekTextBox.TextChanged += new System.EventHandler(this.allTextBoxs_TextChanged);
            // 
            // _maxHDailyTextBox
            // 
            resources.ApplyResources(this._maxHDailyTextBox, "_maxHDailyTextBox");
            this._maxHDailyTextBox.Name = "_maxHDailyTextBox";
            this._maxHDailyTextBox.TextChanged += new System.EventHandler(this.allTextBoxs_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _maxHContinuouslyTextBox
            // 
            resources.ApplyResources(this._maxHContinuouslyTextBox, "_maxHContinuouslyTextBox");
            this._maxHContinuouslyTextBox.Name = "_maxHContinuouslyTextBox";
            this._maxHContinuouslyTextBox.TextChanged += new System.EventHandler(this.allTextBoxs_TextChanged);
            // 
            // _overrideMaxHoursContCheckBox
            // 
            resources.ApplyResources(this._overrideMaxHoursContCheckBox, "_overrideMaxHoursContCheckBox");
            this._overrideMaxHoursContCheckBox.Name = "_overrideMaxHoursContCheckBox";
            this._overrideMaxHoursContCheckBox.UseVisualStyleBackColor = true;
            this._overrideMaxHoursContCheckBox.CheckedChanged += new System.EventHandler(this._overrideMaxHoursContCheckBox_CheckedChanged);
            // 
            // _overrideMaxHoursDailyCheckBox
            // 
            resources.ApplyResources(this._overrideMaxHoursDailyCheckBox, "_overrideMaxHoursDailyCheckBox");
            this._overrideMaxHoursDailyCheckBox.Name = "_overrideMaxHoursDailyCheckBox";
            this._overrideMaxHoursDailyCheckBox.UseVisualStyleBackColor = true;
            this._overrideMaxHoursDailyCheckBox.CheckedChanged += new System.EventHandler(this._overrideMaxHoursDailyCheckBox_CheckedChanged);
            // 
            // _overrideMaxDaysPerWeekCheckBox
            // 
            resources.ApplyResources(this._overrideMaxDaysPerWeekCheckBox, "_overrideMaxDaysPerWeekCheckBox");
            this._overrideMaxDaysPerWeekCheckBox.Name = "_overrideMaxDaysPerWeekCheckBox";
            this._overrideMaxDaysPerWeekCheckBox.UseVisualStyleBackColor = true;
            this._overrideMaxDaysPerWeekCheckBox.CheckedChanged += new System.EventHandler(this._overrideMaxDaysPerWeekCheckBox_CheckedChanged);
            // 
            // SoftConsTeacherSettingsForm
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this._overrideMaxDaysPerWeekCheckBox);
            this.Controls.Add(this._overrideMaxHoursDailyCheckBox);
            this.Controls.Add(this._overrideMaxHoursContCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._maxDaysPerWeekTextBox);
            this.Controls.Add(this._maxHDailyTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._maxHContinuouslyTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoftConsTeacherSettingsForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SoftConsTeacherSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.TextBox _maxDaysPerWeekTextBox;
        private System.Windows.Forms.TextBox _maxHDailyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _maxHContinuouslyTextBox;
        private System.Windows.Forms.CheckBox _overrideMaxHoursContCheckBox;
        private System.Windows.Forms.CheckBox _overrideMaxHoursDailyCheckBox;
        private System.Windows.Forms.CheckBox _overrideMaxDaysPerWeekCheckBox;
    }
}