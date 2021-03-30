#region Open Course Timetabler - An application for school and university course timetabling
//
// Author:
//   Ivan Æurak (mailto:Ivan.Curak@fesb.hr)
//
// Copyright (c) 2007 Ivan Æurak, Split, Croatia
//
// http://www.openctt.org
//
//This file is part of Open Course Timetabler.
//
//Open Course Timetabler is free software;
//you can redistribute it and/or modify it under the terms of the GNU General Public License
//as published by the Free Software Foundation; either version 2 of the License,
//or (at your option) any later version.
//
//Open Course Timetabler is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
//or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
//You should have received a copy of the GNU General Public License along with
//Open Course Timetabler; if not, write to the Free Software Foundation, Inc., 51 Franklin St,
//Fifth Floor, Boston, MA  02110-1301  USA

#endregion


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace OpenCTT
{
	/// <summary>
	/// Summary description for AddDaysForm.
	/// </summary>
	public class AddDaysForm : System.Windows.Forms.Form
	{		

		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.CheckBox _checkBox1;
		private System.Windows.Forms.CheckBox _checkBox2;
		private System.Windows.Forms.CheckBox _checkBox7;
		private System.Windows.Forms.CheckBox _checkBox6;
		private System.Windows.Forms.CheckBox _checkBox5;
		private System.Windows.Forms.CheckBox _checkBox4;
		private System.Windows.Forms.CheckBox _checkBox3;
		private System.Windows.Forms.GroupBox _groupBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddDaysForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();			

			String[] dayText = AppForm.getDayText();
			this._checkBox1.Text = dayText[0];
			this._checkBox2.Text = dayText[1];
			this._checkBox3.Text = dayText[2];
			this._checkBox4.Text = dayText[3];
			this._checkBox5.Text = dayText[4];
			this._checkBox6.Text = dayText[5];
			this._checkBox7.Text = dayText[6];
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDaysForm));
            this._checkBox1 = new System.Windows.Forms.CheckBox();
            this._checkBox2 = new System.Windows.Forms.CheckBox();
            this._checkBox7 = new System.Windows.Forms.CheckBox();
            this._checkBox6 = new System.Windows.Forms.CheckBox();
            this._checkBox5 = new System.Windows.Forms.CheckBox();
            this._checkBox4 = new System.Windows.Forms.CheckBox();
            this._checkBox3 = new System.Windows.Forms.CheckBox();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _checkBox1
            // 
            resources.ApplyResources(this._checkBox1, "_checkBox1");
            this._checkBox1.Name = "_checkBox1";
            // 
            // _checkBox2
            // 
            resources.ApplyResources(this._checkBox2, "_checkBox2");
            this._checkBox2.Name = "_checkBox2";
            // 
            // _checkBox7
            // 
            resources.ApplyResources(this._checkBox7, "_checkBox7");
            this._checkBox7.Name = "_checkBox7";
            // 
            // _checkBox6
            // 
            resources.ApplyResources(this._checkBox6, "_checkBox6");
            this._checkBox6.Name = "_checkBox6";
            // 
            // _checkBox5
            // 
            resources.ApplyResources(this._checkBox5, "_checkBox5");
            this._checkBox5.Name = "_checkBox5";
            // 
            // _checkBox4
            // 
            resources.ApplyResources(this._checkBox4, "_checkBox4");
            this._checkBox4.Name = "_checkBox4";
            // 
            // _checkBox3
            // 
            resources.ApplyResources(this._checkBox3, "_checkBox3");
            this._checkBox3.Name = "_checkBox3";
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._checkBox1);
            this._groupBox1.Controls.Add(this._checkBox2);
            this._groupBox1.Controls.Add(this._checkBox3);
            this._groupBox1.Controls.Add(this._checkBox4);
            this._groupBox1.Controls.Add(this._checkBox5);
            this._groupBox1.Controls.Add(this._checkBox6);
            this._groupBox1.Controls.Add(this._checkBox7);
            resources.ApplyResources(this._groupBox1, "_groupBox1");
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.TabStop = false;
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this._okButton, "_okButton");
            this._okButton.Name = "_okButton";
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._cancelButton, "_cancelButton");
            this._cancelButton.Name = "_cancelButton";
            // 
            // AddDaysForm
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDaysForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.AddDaysForm_Load);
            this._groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		private void AddDaysForm_Load(object sender, System.EventArgs e)
		{
			for(int n=0;n<7;n++)
			{
				if(AppForm.CURR_OCTT_DOC.getIsDayIncluded(n)==true)
				{
					this._groupBox1.Controls[n].Enabled=false;
					((CheckBox)this._groupBox1.Controls[n]).Checked=true;					
				}
			}
		}

		public GroupBox getGroup()
		{
			return _groupBox1;
		}



	}
}

		
	
