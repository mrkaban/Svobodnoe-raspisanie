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
using System.Configuration;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace OpenCTT
{
	/// <summary>
	/// Summary description for DocumentPropertiesForm.
	/// </summary>
	public class DocumentPropertiesForm : System.Windows.Forms.Form
	{		
		private bool _isNew;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.TextBox _schoolYearTextBox;
		private System.Windows.Forms.TextBox _eduInstitutionNameTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox _docTypeComboBox;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DocumentPropertiesForm(bool isNew)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();	
            
			_isNew=isNew;	
			this._docTypeComboBox.DataSource=AppForm.DOCUMENT_TYPES_LIST;
			
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentPropertiesForm));
            this.label1 = new System.Windows.Forms.Label();
            this._schoolYearTextBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._eduInstitutionNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._docTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _schoolYearTextBox
            // 
            resources.ApplyResources(this._schoolYearTextBox, "_schoolYearTextBox");
            this._schoolYearTextBox.Name = "_schoolYearTextBox";
            this._schoolYearTextBox.TextChanged += new System.EventHandler(this._textBox_TextChanged);
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
            // _eduInstitutionNameTextBox
            // 
            resources.ApplyResources(this._eduInstitutionNameTextBox, "_eduInstitutionNameTextBox");
            this._eduInstitutionNameTextBox.Name = "_eduInstitutionNameTextBox";
            this._eduInstitutionNameTextBox.TextChanged += new System.EventHandler(this._textBox_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _docTypeComboBox
            // 
            this._docTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this._docTypeComboBox, "_docTypeComboBox");
            this._docTypeComboBox.Name = "_docTypeComboBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // DocumentPropertiesForm
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this.label3);
            this.Controls.Add(this._docTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._eduInstitutionNameTextBox);
            this.Controls.Add(this._schoolYearTextBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocumentPropertiesForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SchoolYearForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void _textBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_schoolYearTextBox.Text.Trim()!="" && _eduInstitutionNameTextBox.Text.Trim()!="") 
			{
				_okButton.Enabled=true;

			} 
			else 
			{
				_okButton.Enabled=false;

			}
		}		

		public string getSchoolYear()
		{
			return _schoolYearTextBox.Text.Trim();
		}

		public string getEduInstitutionNameInput()
		{
			return _eduInstitutionNameTextBox.Text.Trim();
		}

		public int getDocumentType()
		{	
			return _docTypeComboBox.SelectedIndex+1;
		}

		private void SchoolYearForm_Load(object sender, System.EventArgs e)
		{
			if(!_isNew)
			{				
				this._schoolYearTextBox.Text = AppForm.CURR_OCTT_DOC.SchoolYear;
				this._eduInstitutionNameTextBox.Text = AppForm.CURR_OCTT_DOC.EduInstitutionName;				
				this._docTypeComboBox.SelectedIndex=AppForm.CURR_OCTT_DOC.DocumentType-1;
				
			}
			else
			{				
				this._schoolYearTextBox.Text = Settings.SCHOOL_YEAR_SETT;
				this._eduInstitutionNameTextBox.Text =Settings.EDU_INSTITUTION_NAME_SETT;				
				
			}
		
		}
		
	}
}
