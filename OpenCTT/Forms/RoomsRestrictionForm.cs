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
	/// Summary description for RoomsRestrictionForm.
	/// </summary>
	public class RoomsRestrictionForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.ListBox _possibleRoomsListBox;
		private System.Windows.Forms.ListBox _choosedRoomsListBox;
		private System.Windows.Forms.Button _moveRightButton;
		private System.Windows.Forms.Button _moveLeftButton;
		
		private ArrayList _possibleRoomsFromModelList;
		private System.Windows.Forms.Label _topLabel;
		private System.Windows.Forms.Label _hideLabel;

		private int _numOfEnrStudents;
		private System.Windows.Forms.Label _possibleRoomsLabel;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RoomsRestrictionForm(ArrayList possibleRoomsFromModelList, string labelText, int numOfEnrStudents)
		{			
			InitializeComponent();
							
			RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.RoomsRestrictionForm",this.GetType().Assembly);
			
            this.Text+=" "+RES_MANAGER.GetString("for.text")+" "+labelText;

			_numOfEnrStudents=numOfEnrStudents;

			_possibleRoomsFromModelList=possibleRoomsFromModelList;

			this.Closing += new CancelEventHandler(this.Form_Closing);

			
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomsRestrictionForm));
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._possibleRoomsListBox = new System.Windows.Forms.ListBox();
            this._choosedRoomsListBox = new System.Windows.Forms.ListBox();
            this._moveRightButton = new System.Windows.Forms.Button();
            this._moveLeftButton = new System.Windows.Forms.Button();
            this._topLabel = new System.Windows.Forms.Label();
            this._hideLabel = new System.Windows.Forms.Label();
            this._possibleRoomsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // _possibleRoomsListBox
            // 
            resources.ApplyResources(this._possibleRoomsListBox, "_possibleRoomsListBox");
            this._possibleRoomsListBox.Name = "_possibleRoomsListBox";
            this._possibleRoomsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this._possibleRoomsListBox.Sorted = true;
            // 
            // _choosedRoomsListBox
            // 
            resources.ApplyResources(this._choosedRoomsListBox, "_choosedRoomsListBox");
            this._choosedRoomsListBox.Name = "_choosedRoomsListBox";
            this._choosedRoomsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this._choosedRoomsListBox.Sorted = true;
            // 
            // _moveRightButton
            // 
            resources.ApplyResources(this._moveRightButton, "_moveRightButton");
            this._moveRightButton.Name = "_moveRightButton";
            this._moveRightButton.Click += new System.EventHandler(this._moveRightButton_Click);
            // 
            // _moveLeftButton
            // 
            resources.ApplyResources(this._moveLeftButton, "_moveLeftButton");
            this._moveLeftButton.Name = "_moveLeftButton";
            this._moveLeftButton.Click += new System.EventHandler(this._moveLeftButton_Click);
            // 
            // _topLabel
            // 
            resources.ApplyResources(this._topLabel, "_topLabel");
            this._topLabel.Name = "_topLabel";
            // 
            // _hideLabel
            // 
            this._hideLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this._hideLabel, "_hideLabel");
            this._hideLabel.ForeColor = System.Drawing.Color.Green;
            this._hideLabel.Name = "_hideLabel";
            // 
            // _possibleRoomsLabel
            // 
            resources.ApplyResources(this._possibleRoomsLabel, "_possibleRoomsLabel");
            this._possibleRoomsLabel.Name = "_possibleRoomsLabel";
            // 
            // RoomsRestrictionForm
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this._possibleRoomsLabel);
            this.Controls.Add(this._hideLabel);
            this.Controls.Add(this._choosedRoomsListBox);
            this.Controls.Add(this._topLabel);
            this.Controls.Add(this._moveLeftButton);
            this.Controls.Add(this._moveRightButton);
            this.Controls.Add(this._possibleRoomsListBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomsRestrictionForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.RoomsRestrictionForm_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void RoomsRestrictionForm_Load(object sender, System.EventArgs e)
		{			
			
			if(_possibleRoomsFromModelList!=null)
			{				
				foreach(Room room in _possibleRoomsFromModelList)
				{
					_choosedRoomsListBox.Items.Add(room);
				}
			}
			
			
			foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes)
			{
				if(room.getRoomCapacity()>=_numOfEnrStudents)
				{
					if(_possibleRoomsFromModelList!=null)
					{
						if(!_possibleRoomsFromModelList.Contains(room))
						{
							_possibleRoomsListBox.Items.Add(room);
						}
					} 
					else 
					{
						_possibleRoomsListBox.Items.Add(room);
					}
				}
			}

			checkWhatIsVisible();
		
		}

		private void _moveLeftButton_Click(object sender, System.EventArgs e)
		{	
			ArrayList tempList = new ArrayList();
			foreach(Room room in _possibleRoomsListBox.SelectedItems)
			{	
				tempList.Add(room);				
				
			}

			foreach(Room roomForMove in tempList)
			{
				_possibleRoomsListBox.Items.Remove(roomForMove);												
				_choosedRoomsListBox.Items.Add(roomForMove);
			}

			checkWhatIsVisible();
			setOKButtonState();
		}

		private void _moveRightButton_Click(object sender, System.EventArgs e)
		{
			ArrayList tempList = new ArrayList();
			foreach(Room room in _choosedRoomsListBox.SelectedItems)
			{	
				tempList.Add(room);				
				
			}

			foreach(Room roomForMove in tempList)
			{
				_choosedRoomsListBox.Items.Remove(roomForMove);												
				_possibleRoomsListBox.Items.Add(roomForMove);
			}

			checkWhatIsVisible();
			setOKButtonState();
		
		}


		private void checkWhatIsVisible()
		{
			if(_choosedRoomsListBox.Items.Count==0)
			{
				_hideLabel.Visible=true;
				_choosedRoomsListBox.Visible=false;
				_moveRightButton.Visible=false;

			}
			else
			{
				_hideLabel.Visible=false;
				_choosedRoomsListBox.Visible=true;
				_moveRightButton.Visible=true;

			}

		}

		public ListBox getChoosedRoomsListBox()
		{
			return _choosedRoomsListBox;			
		}

		private void Form_Closing (Object sender, CancelEventArgs e) 
		{
			if(this.DialogResult==DialogResult.OK)
			{
				if (_numOfEnrStudents>-1) //course
				{
					if(!this.getIsRoomRelCourseOK())
					{
						e.Cancel = true;
					
						string message1 = RES_MANAGER.GetString("Form_Closing.msb.course.restrictions_not_changed.message");
					
						string caption1 = RES_MANAGER.GetString("Form_Closing.msb.course.restrictions_not_changed.caption");

						MessageBoxButtons buttons1 = MessageBoxButtons.OK;			
		
						MessageBox.Show(this, message1, caption1, buttons1,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
					else
					{
                        e.Cancel=false;
					}
				}
				else //teacher
				{
					if(!this.getIsRoomRelTeacherOK())
					{
						e.Cancel = true;
					
                        string message2 = RES_MANAGER.GetString("Form_Closing.msb.teacher.restrictions_not_changed.message");
											
						string caption2 = RES_MANAGER.GetString("Form_Closing.msb.teacher.restrictions_not_changed.caption");

						MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message2, caption2, buttons2,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
					else
					{
						e.Cancel=false;
					}						
				}
			}
		}

		private bool getIsRoomRelCourseOK()
		{
			ArrayList [,] mytt = AppForm.CURR_OCTT_DOC.ShownEduProgram.getTimetable();
			Course selCourse = (Course)AppForm.getAppForm().getSelectedCourse();
			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++) 
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++) 
				{					
					ArrayList lessonsInOneTimeSlot = mytt[j,k];
					if(lessonsInOneTimeSlot!=null) 
					{
						foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
						{							
							Course course = (Course)courseAndRoomPair[0];
							if(course==selCourse)
							{
								Room room = (Room)courseAndRoomPair[1];
								if(!(_choosedRoomsListBox.Items.Contains(room)|| _choosedRoomsListBox.Items.Count==0)) return false;
							}
						}
					}					
				}


			}

			return true;
		}

		private bool getIsRoomRelTeacherOK()
		{
			Teacher selTeacher=AppForm.getAppForm().getSelectedTeacher();

			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++) 
			{				
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++) 
				{	
					foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
					{
						foreach(EduProgram ep in epg.Nodes)
						{
							ArrayList [,] mytt = ep.getTimetable();
							ArrayList lessonsInOneTimeSlot = mytt[j,k];
							if(lessonsInOneTimeSlot!=null) 
							{
								foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
								{	
									Course course = (Course)courseAndRoomPair[0];
									Teacher teacherFromModel=course.getTeacher();	
									if(teacherFromModel==selTeacher)
									{
										Room room = (Room)courseAndRoomPair[1];
										if(!(_choosedRoomsListBox.Items.Contains(room) || _choosedRoomsListBox.Items.Count==0)) return false;
									}
								}
							}
						}
					}
					
				}


			}

			return true;
		}

		private void setOKButtonState()
		{
			if(_possibleRoomsFromModelList==null || _possibleRoomsFromModelList.Count==0)
			{
				if(_choosedRoomsListBox.Items.Count>0)
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

				foreach(Room room in _possibleRoomsFromModelList)
				{
					if(!_choosedRoomsListBox.Items.Contains(room))
					{
						containsAll=false;
						_okButton.Enabled=true;
						break;
					}
				}

				if(containsAll)
				{
					if(_possibleRoomsFromModelList.Count==_choosedRoomsListBox.Items.Count)
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
