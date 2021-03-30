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
	/// Summary description for CoursesToHoldTogetherForm.
	/// </summary>
	public class CoursesToHoldTogetherForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private bool _isFormDisabled;

		private ArrayList _thtWorkingList;
		private Course _course;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.ListView _thtCoursesListView;
		private System.Windows.Forms.ListView _thtPickListView;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Label _topLabel;
		private System.Windows.Forms.Label _middleLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CoursesToHoldTogetherForm(Course course, bool isFormDisabled)
		{			
			InitializeComponent();

			if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
			{				
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.CTHTFormUniversity",this.GetType().Assembly);

			}
			else
			{			
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.CTHTFormSchool",this.GetType().Assembly);
			}

			
			columnHeader1.Text=RES_MANAGER.GetString("columnHeader1.Text");
			columnHeader2.Text=RES_MANAGER.GetString("columnHeader2.Text");
			columnHeader3.Text=RES_MANAGER.GetString("columnHeader3.Text");
			columnHeader4.Text=RES_MANAGER.GetString("columnHeader4.Text");
			columnHeader5.Text=RES_MANAGER.GetString("columnHeader5.Text");
			columnHeader6.Text=RES_MANAGER.GetString("columnHeader6.Text");

			label1.Text=RES_MANAGER.GetString("label1.Text");

			            
			_isFormDisabled=isFormDisabled;
			_course=course;
            _thtWorkingList=new ArrayList();
			
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoursesToHoldTogetherForm));
            this._thtCoursesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._thtPickListView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._topLabel = new System.Windows.Forms.Label();
            this._middleLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _thtCoursesListView
            // 
            this._thtCoursesListView.BackColor = System.Drawing.Color.LightSteelBlue;
            this._thtCoursesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this._thtCoursesListView.FullRowSelect = true;
            this._thtCoursesListView.GridLines = true;
            this._thtCoursesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            resources.ApplyResources(this._thtCoursesListView, "_thtCoursesListView");
            this._thtCoursesListView.MultiSelect = false;
            this._thtCoursesListView.Name = "_thtCoursesListView";
            this._thtCoursesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this._thtCoursesListView.UseCompatibleStateImageBehavior = false;
            this._thtCoursesListView.View = System.Windows.Forms.View.Details;
            this._thtCoursesListView.DoubleClick += new System.EventHandler(this._thtCoursesListView_DoubleClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
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
            // _thtPickListView
            // 
            this._thtPickListView.BackColor = System.Drawing.Color.MediumAquamarine;
            this._thtPickListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this._thtPickListView.FullRowSelect = true;
            this._thtPickListView.GridLines = true;
            this._thtPickListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            resources.ApplyResources(this._thtPickListView, "_thtPickListView");
            this._thtPickListView.MultiSelect = false;
            this._thtPickListView.Name = "_thtPickListView";
            this._thtPickListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this._thtPickListView.UseCompatibleStateImageBehavior = false;
            this._thtPickListView.View = System.Windows.Forms.View.Details;
            this._thtPickListView.DoubleClick += new System.EventHandler(this._thtPickListView_DoubleClick);
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // _topLabel
            // 
            resources.ApplyResources(this._topLabel, "_topLabel");
            this._topLabel.Name = "_topLabel";
            // 
            // _middleLabel
            // 
            resources.ApplyResources(this._middleLabel, "_middleLabel");
            this._middleLabel.Name = "_middleLabel";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CoursesToHoldTogetherForm
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._middleLabel);
            this.Controls.Add(this._topLabel);
            this.Controls.Add(this._thtPickListView);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._thtCoursesListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoursesToHoldTogetherForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void Form_Load(object sender, System.EventArgs e)
		{			
			_topLabel.Text=RES_MANAGER.GetString("Form_Load._topLabel.Text1")+" '"+_course.getFullName()+"' "+RES_MANAGER.GetString("Form_Load._topLabel.Text2");
			
			if(_course.getCoursesToHoldTogetherList()!=null)
			{
				_thtWorkingList=(ArrayList)_course.getCoursesToHoldTogetherList().Clone();
			}
	
			foreach(Course tempCourse in _thtWorkingList)
			{
				string [] epgAndEpAndCourse= new string[3];

				EduProgram ep = (EduProgram)tempCourse.Parent;
				EduProgramGroup epg = (EduProgramGroup)ep.Parent;
				
				String textEduProgram=ep.getName()+", "+ep.getCode()+", "+ep.getSemester()+". "+RES_MANAGER.GetString("Form_Load.listView.textEduProgram.sem");

				epgAndEpAndCourse[0]=epg.getName();
				epgAndEpAndCourse[1]=textEduProgram;
				epgAndEpAndCourse[2]=tempCourse.getFullName();				
				
				ListViewItem newLvi= new ListViewItem(epgAndEpAndCourse);
				newLvi.Tag=tempCourse;
				_thtCoursesListView.Items.Add(newLvi);

			}
			
			this.fillPickListView();

			if(_isFormDisabled)
			{
				this._thtPickListView.DoubleClick -= new System.EventHandler(this._thtPickListView_DoubleClick);
				this._thtCoursesListView.DoubleClick -= new System.EventHandler(this._thtCoursesListView_DoubleClick);
			

				this.Text+=" - READ ONLY";
				_okButton.Enabled=false;

				

			}			

		}

		private void _thtPickListView_DoubleClick(object sender, System.EventArgs e)
		{
			ListView lv=(ListView)sender;
			foreach(ListViewItem lvi in lv.SelectedItems)
			{				
				_thtPickListView.Items.Clear();

				_thtWorkingList.Add((Course)lvi.Tag);
				_thtCoursesListView.Items.Add(lvi);
				
				fillPickListView();
			}

			setOKButtonState();
		}

		private void _thtCoursesListView_DoubleClick(object sender, System.EventArgs e)
		{
			ListView lv=(ListView)sender;
			foreach(ListViewItem lvi in lv.SelectedItems)
			{	
				_thtWorkingList.Remove((Course)lvi.Tag);
				lv.Items.Remove(lvi);
								
				_thtPickListView.Items.Clear();
				fillPickListView();
			}

			setOKButtonState();
		
		}

		public ArrayList getTHTWorkingList()
		{
			return _thtWorkingList;
		}

		private void fillPickListView()
		{
			EduProgram selEduProgram=(EduProgram)_course.Parent;

			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
			{				
				foreach(EduProgram ep in epg.Nodes)
				{
					if(ep!=selEduProgram && !isEduProgramInWorkingList(ep))
					{
						foreach(Course tempCourse in ep.Nodes)
						{
							if(!ep.getIsCourseInTimetable(tempCourse))
							{
								if(tempCourse.getTeacher()==_course.getTeacher() && tempCourse.getNumberOfLessonsPerWeek()==_course.getNumberOfLessonsPerWeek())
								{
									if(!_thtWorkingList.Contains(tempCourse))
									{	
										string textEduProgram=ep.getName()+", "+ep.getCode()+", "+ep.getSemester()+". "+RES_MANAGER.GetString("Form_Load.listView.textEduProgram.sem");

										string [] epgAndEpAndCourse= new string[3];
										epgAndEpAndCourse[0]=epg.getName();
										epgAndEpAndCourse[1]=textEduProgram;
										epgAndEpAndCourse[2]=tempCourse.getFullName();
														
										ListViewItem newLvi= new ListViewItem(epgAndEpAndCourse);
										newLvi.Tag=tempCourse;
										_thtPickListView.Items.Add(newLvi);
									}

								}
							}
						}
					}
				}
			}

		}


		private bool isEduProgramInWorkingList(EduProgram thisEP)
		{
			foreach(Course course in _thtWorkingList)
			{
				EduProgram ep=(EduProgram)course.Parent;
				if(ep==thisEP)
				{
					return true;
				}
			}
			return false;

		}

		private void setOKButtonState()
		{
			if(_course.getCoursesToHoldTogetherList()==null || _course.getCoursesToHoldTogetherList().Count==0)
			{
				if(_thtWorkingList.Count>0)
				{
					_okButton.Enabled=true;
				}
				else
				{
					_okButton.Enabled=false;
				}				
			}
			else
			{
				bool containsAll=true;

				foreach(Course course in _course.getCoursesToHoldTogetherList())
				{
					if(!_thtWorkingList.Contains(course))
					{
						containsAll=false;
						_okButton.Enabled=true;
						break;
					}
				}

				if(containsAll)
				{
					if(_course.getCoursesToHoldTogetherList().Count==_thtWorkingList.Count)
					{
						_okButton.Enabled=false;
					}
					else
					{
						_okButton.Enabled=true;
					}

				}
			}
		}
	}
}
