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
	/// Summary description for CoursePropertiesForm.
	/// </summary>
	public class CoursePropertiesForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private bool _isAllEnabled;
		private bool _isNew;
		private Course _course;
	
		private bool _isNameOK=true;
		private bool _isNumOfLessonsPerWeekOK=false;
		private bool _isNumOfEnrStudentsOK=false;
		private bool _isGroupNameOK=true;


		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label _groupNameLabel;
		private System.Windows.Forms.TextBox _nameTextBox;
		private System.Windows.Forms.TextBox _numOfLessonsPerWeekTextBox;
		private System.Windows.Forms.TextBox _numOfEnrolledStudentsTextBox;
		private System.Windows.Forms.ComboBox _teacherComboBox;
		private System.Windows.Forms.CheckBox _isGroupCheckBox;
		private System.Windows.Forms.TextBox _groupNameTextBox;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox _shortNameTextBox;
		private System.Windows.Forms.ErrorProvider _errorProvider1;
		private System.Windows.Forms.ErrorProvider _errorProvider2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox _extIDTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox _courseTypeComboBox;
        private IContainer components;

        public CoursePropertiesForm()
		{

			InitializeComponent();
		
			if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
			{				
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.CoursePropertiesFormUniversity",this.GetType().Assembly);

			}
			else
			{			
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.CoursePropertiesFormSchool",this.GetType().Assembly);
			}	

			_isNew=true;
			_isAllEnabled=true;

			_errorProvider1.SetError(_numOfLessonsPerWeekTextBox,"");
			_errorProvider2.SetError(_numOfEnrolledStudentsTextBox,"");
			
			_teacherComboBox.DataSource=AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes;
			_teacherComboBox.DisplayMember="Text";

			_courseTypeComboBox.DataSource=AppForm.CURR_OCTT_DOC.CourseTypesList;

		}

		public CoursePropertiesForm(Course course, bool isAllEnabled):this()
		{
			_course=course;

			_isNew=false;
			_isAllEnabled=isAllEnabled;

			this._nameTextBox.Text=_course.getName();
			this._shortNameTextBox.Text=_course.getShortName();
			this._teacherComboBox.SelectedItem=_course.getTeacher();
			this._numOfLessonsPerWeekTextBox.Text=_course.getNumberOfLessonsPerWeek().ToString();
			this._numOfEnrolledStudentsTextBox.Text=_course.getNumberOfEnrolledStudents().ToString();
			this._isGroupCheckBox.Checked=_course.getIsGroup();
                
			this._extIDTextBox.Text=_course.ExtID;
			this._courseTypeComboBox.SelectedItem=_course.CourseType;

			if(_course.getIsGroup()) 
			{
				this._groupNameLabel.Enabled=true;
				this._groupNameTextBox.Enabled=true;
				this._groupNameTextBox.Text=_course.getGroupName();
			} 
			else 
			{
				this._groupNameLabel.Enabled=false;
				this._groupNameTextBox.Enabled=false;
				this._groupNameTextBox.Text="";
			}

			if(!_isAllEnabled)
			{
				label2.Enabled=false;
				label3.Enabled=false;
				label4.Enabled=false;
				_isGroupCheckBox.Enabled=false;
				_groupNameLabel.Enabled=false;
				_groupNameTextBox.Enabled=false;
				_numOfLessonsPerWeekTextBox.Enabled=false;
				_numOfEnrolledStudentsTextBox.Enabled=false;
				_teacherComboBox.Enabled=false;					

			}
			
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoursePropertiesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._groupNameLabel = new System.Windows.Forms.Label();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._numOfLessonsPerWeekTextBox = new System.Windows.Forms.TextBox();
            this._numOfEnrolledStudentsTextBox = new System.Windows.Forms.TextBox();
            this._teacherComboBox = new System.Windows.Forms.ComboBox();
            this._isGroupCheckBox = new System.Windows.Forms.CheckBox();
            this._groupNameTextBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this._shortNameTextBox = new System.Windows.Forms.TextBox();
            this._errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this._extIDTextBox = new System.Windows.Forms.TextBox();
            this._courseTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this._errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider2)).BeginInit();
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
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // _groupNameLabel
            // 
            resources.ApplyResources(this._groupNameLabel, "_groupNameLabel");
            this._groupNameLabel.Name = "_groupNameLabel";
            // 
            // _nameTextBox
            // 
            resources.ApplyResources(this._nameTextBox, "_nameTextBox");
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.TextChanged += new System.EventHandler(this._nameTextBox_TextChanged);
            // 
            // _numOfLessonsPerWeekTextBox
            // 
            resources.ApplyResources(this._numOfLessonsPerWeekTextBox, "_numOfLessonsPerWeekTextBox");
            this._numOfLessonsPerWeekTextBox.Name = "_numOfLessonsPerWeekTextBox";
            this._numOfLessonsPerWeekTextBox.TextChanged += new System.EventHandler(this._numOfLessPerWeekTextBox_TextChanged);
            // 
            // _numOfEnrolledStudentsTextBox
            // 
            resources.ApplyResources(this._numOfEnrolledStudentsTextBox, "_numOfEnrolledStudentsTextBox");
            this._numOfEnrolledStudentsTextBox.Name = "_numOfEnrolledStudentsTextBox";
            this._numOfEnrolledStudentsTextBox.TextChanged += new System.EventHandler(this._numOfEnrStudentsTextBox_TextChanged);
            // 
            // _teacherComboBox
            // 
            this._teacherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this._teacherComboBox, "_teacherComboBox");
            this._teacherComboBox.Name = "_teacherComboBox";
            this._teacherComboBox.Sorted = true;
            // 
            // _isGroupCheckBox
            // 
            resources.ApplyResources(this._isGroupCheckBox, "_isGroupCheckBox");
            this._isGroupCheckBox.Name = "_isGroupCheckBox";
            this._isGroupCheckBox.CheckedChanged += new System.EventHandler(this._grupaCheckBox_CheckedChanged);
            // 
            // _groupNameTextBox
            // 
            resources.ApplyResources(this._groupNameTextBox, "_groupNameTextBox");
            this._groupNameTextBox.Name = "_groupNameTextBox";
            this._groupNameTextBox.TextChanged += new System.EventHandler(this._groupNameTextBox_TextChanged);
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
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // _shortNameTextBox
            // 
            resources.ApplyResources(this._shortNameTextBox, "_shortNameTextBox");
            this._shortNameTextBox.Name = "_shortNameTextBox";
            this._shortNameTextBox.TextChanged += new System.EventHandler(this._nameTextBox_TextChanged);
            // 
            // _errorProvider1
            // 
            this._errorProvider1.ContainerControl = this;
            this._errorProvider1.DataMember = "";
            resources.ApplyResources(this._errorProvider1, "_errorProvider1");
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // _extIDTextBox
            // 
            resources.ApplyResources(this._extIDTextBox, "_extIDTextBox");
            this._extIDTextBox.Name = "_extIDTextBox";
            // 
            // _courseTypeComboBox
            // 
            resources.ApplyResources(this._courseTypeComboBox, "_courseTypeComboBox");
            this._courseTypeComboBox.Name = "_courseTypeComboBox";
            this._courseTypeComboBox.Sorted = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // _errorProvider2
            // 
            this._errorProvider2.ContainerControl = this;
            this._errorProvider2.DataMember = "";
            resources.ApplyResources(this._errorProvider2, "_errorProvider2");
            // 
            // CoursePropertiesForm
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this.label7);
            this.Controls.Add(this._courseTypeComboBox);
            this.Controls.Add(this._extIDTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._shortNameTextBox);
            this.Controls.Add(this._groupNameTextBox);
            this.Controls.Add(this._numOfEnrolledStudentsTextBox);
            this.Controls.Add(this._numOfLessonsPerWeekTextBox);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._isGroupCheckBox);
            this.Controls.Add(this._teacherComboBox);
            this.Controls.Add(this._groupNameLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoursePropertiesForm";
            this.ShowInTaskbar = false;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void _grupaCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if(_isGroupCheckBox.Checked)
			{
				_groupNameLabel.Enabled=true;
				_groupNameTextBox.Enabled=true;
				if(_groupNameTextBox.Text.Trim()=="")
				{
                    _isGroupNameOK=false;
					_okButton.Enabled=false;
				}
				else
				{
					_isGroupNameOK=true;
				}
			} 
			else 
			{
				_groupNameLabel.Enabled=false;
				_groupNameTextBox.Enabled=false;
				_isGroupNameOK=true;
				if(_isNameOK && _isNumOfEnrStudentsOK && _isNumOfLessonsPerWeekOK)
				{
					_okButton.Enabled=true;
				}
			}
		}
		

		private void Form_Closing (Object sender, CancelEventArgs e)
		{
			if(this.DialogResult==DialogResult.OK)
			{
				string courseType=(string)_courseTypeComboBox.SelectedItem;				
				if(courseType==null)courseType=_courseTypeComboBox.Text.Trim();

				if(_isNew) 
				{
					if(Course.getIsCourseDataOK(null,_nameTextBox.Text.Trim(),_shortNameTextBox.Text.Trim(),courseType, _groupNameTextBox.Text.Trim(), _isGroupCheckBox.Checked))
					{
						e.Cancel=false;
					}
					else
					{
						e.Cancel = true;				
						
						string message1=RES_MANAGER.GetString("Form_Closing.msb.coursenotadded.message");
					
						string caption1=RES_MANAGER.GetString("Form_Closing.msb.coursenotadded.caption");

						MessageBoxButtons buttons1 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message1, caption1, buttons1,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

					}
				}
				else
				{
					if(Course.getIsCourseDataOK(_course,_nameTextBox.Text.Trim(),_shortNameTextBox.Text.Trim(),courseType, _groupNameTextBox.Text.Trim(), _isGroupCheckBox.Checked))
					{
						e.Cancel=false;
					}
					else
					{
						e.Cancel = true;
											
						string message2=RES_MANAGER.GetString("Form_Closing.msb.coursedatanotchanged.message");
					
						string caption2=RES_MANAGER.GetString("Form_Closing.msb.coursedatanotchanged.caption");

						MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message2, caption2, buttons2,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

					}

				}
			}

		}

		private void _nameTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_nameTextBox.Text.Trim()!="" && _shortNameTextBox.Text.Trim()!="" && _teacherComboBox.SelectedItem!=null) 
			{
				_isNameOK=true;

				if(_isNumOfLessonsPerWeekOK && _isNumOfEnrStudentsOK && _isGroupNameOK)
				{
					_okButton.Enabled=true;
				}

			} 
			else
			{
				_isNameOK=false;
				_okButton.Enabled=false;

			}		
		}
		

		private void _numOfLessPerWeekTextBox_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				int x = Int32.Parse(_numOfLessonsPerWeekTextBox.Text);
				if(x<=0 || x>=100)
				{
					_isNumOfLessonsPerWeekOK=false;					
					_errorProvider1.SetError(_numOfLessonsPerWeekTextBox,RES_MANAGER.GetString("_numOfLessPerWeekTextBox_TextChanged._errorProvider1.errortext"));
					_okButton.Enabled=false;
				}
				else
				{
					_isNumOfLessonsPerWeekOK=true;
					_errorProvider1.SetError(_numOfLessonsPerWeekTextBox,"");
					if(_isNameOK && _isNumOfEnrStudentsOK && _isGroupNameOK)
					{
						_okButton.Enabled=true;
					}
				}
			}
			catch
			{
				_isNumOfLessonsPerWeekOK=false;				
				_errorProvider1.SetError(_numOfLessonsPerWeekTextBox,RES_MANAGER.GetString("_numOfLessPerWeekTextBox_TextChanged._errorProvider1.errortext"));
				_okButton.Enabled=false;
			}
		
		}

		private void _numOfEnrStudentsTextBox_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				int x = Int32.Parse(_numOfEnrolledStudentsTextBox.Text);
				if(x<=0)
				{
					_isNumOfEnrStudentsOK=false;					
					_errorProvider2.SetError(_numOfEnrolledStudentsTextBox,RES_MANAGER.GetString("_numOfEnrStudentsTextBox_TextChanged._errorProvider2.errortext"));
					_okButton.Enabled=false;
				}
				else
				{
					_isNumOfEnrStudentsOK=true;
					_errorProvider2.SetError(_numOfEnrolledStudentsTextBox,"");
					if(_isNameOK && _isNumOfLessonsPerWeekOK && _isGroupNameOK)
					{
						_okButton.Enabled=true;
					}
				}
			}
			catch
			{
				_isNumOfEnrStudentsOK=false;				
				_errorProvider2.SetError(_numOfEnrolledStudentsTextBox,RES_MANAGER.GetString("_numOfEnrStudentsTextBox_TextChanged._errorProvider2.errortext"));
				_okButton.Enabled=false;
			}
		
		}

		private void _groupNameTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_groupNameTextBox.Text.Trim()=="")
			{
				_isGroupNameOK=false;
				_okButton.Enabled=false;
			}
			else
			{
				_isGroupNameOK=true;

				if(_isNameOK && _isNumOfEnrStudentsOK && _isNumOfLessonsPerWeekOK)
				{
					_okButton.Enabled=true;
				}
				else
				{
                    _okButton.Enabled=false;
				}
			}	
		}
	
		public TextBox NameTextBox
		{
			get
			{
				return _nameTextBox;
			}
		}

		public TextBox ShortNameTextBox
		{
			get
			{
				return _shortNameTextBox;
			}
		}

		public TextBox NumOfLessonsPerWeekTextBox
		{
			get
			{
				return _numOfLessonsPerWeekTextBox;
			}
		}

		public TextBox NumOfEnrolledStudentsTextBox
		{
			get
			{
				return _numOfEnrolledStudentsTextBox;
			}
		}

		public TextBox GroupNameTextBox
		{
			get
			{
				return _groupNameTextBox;
			}
		}

		public TextBox ExtIDTextBox
		{
			get
			{
				return _extIDTextBox;
			}
		}

		public ComboBox TeacherComboBox
		{
			get
			{
				return _teacherComboBox;
			}
		}	

		public ComboBox CourseTypeComboBox
		{
			get
			{
				return _courseTypeComboBox;
			}
		}	

		public CheckBox IsGroupCheckBox
		{
			get
			{
				return _isGroupCheckBox;
			}
		}

		
	}
}
