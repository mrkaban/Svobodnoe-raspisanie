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
	/// Summary description for EduProgramPropertiesForm.
	/// </summary>
	public class EduProgramPropertiesForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private EduProgram _ep;
        private bool _isNew;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox _codeTextBox;
		private System.Windows.Forms.TextBox _nameTextBox;
		private System.Windows.Forms.TextBox _semesterTextBox;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox _extIDTextBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public EduProgramPropertiesForm()
		{
			InitializeComponent();
			_isNew=true;

			if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
			{				
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.EPPropertiesFormUniversity",this.GetType().Assembly);

			}
			else
			{			
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.EPPropertiesFormSchool",this.GetType().Assembly);
			}
			//
			this.Text=RES_MANAGER.GetString("this.Text");
			this.label3.Text=RES_MANAGER.GetString("label3.Text");
            //

		}

		public EduProgramPropertiesForm(EduProgram ep):this()
		{
			_ep=ep;
			_isNew=false;

			this._codeTextBox.Text=_ep.getCode();
			this._nameTextBox.Text=_ep.getName();
			this._semesterTextBox.Text=_ep.getSemester();
			this._extIDTextBox.Text=_ep.ExtID;
			
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EduProgramPropertiesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._codeTextBox = new System.Windows.Forms.TextBox();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._semesterTextBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._extIDTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _codeTextBox
            // 
            resources.ApplyResources(this._codeTextBox, "_codeTextBox");
            this._codeTextBox.Name = "_codeTextBox";
            // 
            // _nameTextBox
            // 
            resources.ApplyResources(this._nameTextBox, "_nameTextBox");
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.TextChanged += new System.EventHandler(this._nameTextBox_TextChanged);
            // 
            // _semesterTextBox
            // 
            resources.ApplyResources(this._semesterTextBox, "_semesterTextBox");
            this._semesterTextBox.Name = "_semesterTextBox";
            this._semesterTextBox.TextChanged += new System.EventHandler(this._nameTextBox_TextChanged);
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
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // _extIDTextBox
            // 
            resources.ApplyResources(this._extIDTextBox, "_extIDTextBox");
            this._extIDTextBox.Name = "_extIDTextBox";
            // 
            // EduProgramPropertiesForm
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this._extIDTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._semesterTextBox);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this._codeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EduProgramPropertiesForm";
            this.ShowInTaskbar = false;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void _nameTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_nameTextBox.Text.Trim()!="" && _semesterTextBox.Text.Trim()!="") 
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
				if(_isNew) 
				{
					if(EduProgram.getIsEduProgramDataOK(null,_codeTextBox.Text.Trim(),_nameTextBox.Text.Trim(),_semesterTextBox.Text.Trim()))
					{
						e.Cancel=false;
					}
					else
					{
						e.Cancel = true;
					
						string message1 = RES_MANAGER.GetString("Form_Closing.msb.epnotcreated.message");
										
						string caption1 = RES_MANAGER.GetString("Form_Closing.msb.epnotcreated.caption");

						MessageBoxButtons buttons1 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message1, caption1, buttons1,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

					}
				}
				else
				{
					if(EduProgram.getIsEduProgramDataOK(_ep,_codeTextBox.Text.Trim(),_nameTextBox.Text.Trim(),_semesterTextBox.Text.Trim()))
					{
						e.Cancel=false;
					}
					else
					{
						e.Cancel = true;
					
						string message2 = RES_MANAGER.GetString("Form_Closing.msb.epdatanotchanged.message");
										
						string caption2 = RES_MANAGER.GetString("Form_Closing.msb.epdatanotchanged.caption");

						MessageBoxButtons buttons2 = MessageBoxButtons.OK;
		
						MessageBox.Show(this, message2, caption2, buttons2,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

					}

				}
			}

		}	


		public TextBox SemesterTextBox
		{
			get
			{
				return _semesterTextBox;
			}
		}

		public TextBox NameTextBox
		{
			get
			{
				return _nameTextBox;
			}
		}


		public TextBox CodeTextBox
		{
			get
			{
				return _codeTextBox;
			}
		}

		public TextBox ExtIDTextBox
		{
			get
			{
				return _extIDTextBox;
			}
		}		
		
	}
}
