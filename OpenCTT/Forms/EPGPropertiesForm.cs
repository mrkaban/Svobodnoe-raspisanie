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
using System.Globalization;
using System.Resources;


namespace OpenCTT
{
	/// <summary>
	/// Summary description for EPGPropertiesForm.
	/// </summary>
	public class EPGPropertiesForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private EduProgramGroup _epg;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.TextBox _epgNameTextBox;
		private System.Windows.Forms.TextBox _extIDTextBox;

		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		
		

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public EPGPropertiesForm()
		{			
			InitializeComponent();

			if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
			{				
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.EPGPropertiesFormUniversity",this.GetType().Assembly);

			}
			else
			{			
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.EPGPropertiesFormSchool",this.GetType().Assembly);
			}

			this.Text=RES_MANAGER.GetString("this.Text");			
		}


		public EPGPropertiesForm(EduProgramGroup epg):this()
		{			
			_epg=epg;
			_epgNameTextBox.Text=epg.getName();
			_extIDTextBox.Text=epg.ExtID;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EPGPropertiesForm));
            this.label1 = new System.Windows.Forms.Label();
            this._epgNameTextBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._extIDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _epgNameTextBox
            // 
            resources.ApplyResources(this._epgNameTextBox, "_epgNameTextBox");
            this._epgNameTextBox.Name = "_epgNameTextBox";
            this._epgNameTextBox.TextChanged += new System.EventHandler(this._epgNameTextBox_TextChanged);
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
            // _extIDTextBox
            // 
            resources.ApplyResources(this._extIDTextBox, "_extIDTextBox");
            this._extIDTextBox.Name = "_extIDTextBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // EPGPropertiesForm
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this._extIDTextBox);
            this.Controls.Add(this._epgNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EPGPropertiesForm";
            this.ShowInTaskbar = false;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion



		private void _epgNameTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_epgNameTextBox.Text.Trim()!="") 
			{
				_okButton.Enabled=true;

			} 
			else
			{
				_okButton.Enabled=false;

			}
		}

		private void Form_Closing (Object sender, CancelEventArgs e) 
		{
			if(this.DialogResult==DialogResult.OK)
			{
				if(_epg==null)
				{
					if (!EduProgramGroup.checkNewName(_epgNameTextBox.Text)) 
					{
						e.Cancel = true;
					
						string message2 = RES_MANAGER.GetString("Form_Closing.msb.epgnotcreated.message");
					
						string caption2 = RES_MANAGER.GetString("Form_Closing.msb.epgnotcreated.caption");

						MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message2, caption2, buttons2,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
					else 
					{
						e.Cancel = false;		
					}
				}
				else
				{
					if(_epgNameTextBox.Text.ToUpper()!=_epg.getName().ToUpper())
					{
						if (!EduProgramGroup.checkNewName(_epgNameTextBox.Text)) 
						{
							e.Cancel = true;					
							
							string message2 = RES_MANAGER.GetString("Form_Closing.msb.epgdatanotchanged.message");
											
							string caption2 = RES_MANAGER.GetString("Form_Closing.msb.epgdatanotchanged.caption");

							MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
							MessageBox.Show(this, message2, caption2, buttons2,
								MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
						}
						else 
						{
							e.Cancel = false;		
						}
					}

				}
				
			}
		}

		public TextBox EPGNameTextBox
		{
			get
			{
				return _epgNameTextBox;
			}
		}

		public TextBox EPGExtIDTextBox
		{
			get
			{
				return _extIDTextBox;
			}


		}



	}

}
