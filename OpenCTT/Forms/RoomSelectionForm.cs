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
	/// Summary description for RoomSelectionForm.
	/// </summary>
	public class RoomSelectionForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private Room _currRoom;
		private Label _roomLabel;
		private Object [] _courseAndRoomPair;
		private System.Windows.Forms.ListBox _roomsListBox;
		private System.Windows.Forms.Label _courseLabel;
		private System.Windows.Forms.Label _numOfEnrolledStudentsLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RoomSelectionForm(Label roomLabel,ArrayList possibleRooms, Room currRoom,Course currCourse,Object [] courseAndRoomPair)
		{			
			InitializeComponent();

			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.RoomSelectionForm",this.GetType().Assembly);
			}

			_currRoom=currRoom;

			_roomLabel = roomLabel;
			_courseAndRoomPair=courseAndRoomPair;
			
			foreach(Room tempRoom in possibleRooms)
			{
				_roomsListBox.Items.Add(tempRoom);
			}

			_roomsListBox.SelectedItem=currRoom;
	
			_courseLabel.Text+=" "+currCourse.getName();
			if(currCourse.getIsGroup())
			{			
				_courseLabel.Text+=" "+RES_MANAGER.GetString("_courseLabel.group.text")+" "+currCourse.getGroupName();
			}
			int numOfEnrStudents = currCourse.getNumberOfEnrolledStudents();
			if(currCourse.getCoursesToHoldTogetherList().Count>0)
			{
				foreach(Course course in currCourse.getCoursesToHoldTogetherList())
				{
					numOfEnrStudents+=course.getNumberOfEnrolledStudents();
				}
			}

			_numOfEnrolledStudentsLabel.Text+=" "+numOfEnrStudents.ToString();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomSelectionForm));
            this._roomsListBox = new System.Windows.Forms.ListBox();
            this._courseLabel = new System.Windows.Forms.Label();
            this._numOfEnrolledStudentsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _roomsListBox
            // 
            resources.ApplyResources(this._roomsListBox, "_roomsListBox");
            this._roomsListBox.BackColor = System.Drawing.Color.Gainsboro;
            this._roomsListBox.Name = "_roomsListBox";
            this._roomsListBox.Sorted = true;
            this._roomsListBox.SelectedIndexChanged += new System.EventHandler(this._roomsListBox_SelectedIndexChanged);
            this._roomsListBox.DoubleClick += new System.EventHandler(this._roomsListBox_DoubleClick);
            // 
            // _courseLabel
            // 
            resources.ApplyResources(this._courseLabel, "_courseLabel");
            this._courseLabel.Name = "_courseLabel";
            // 
            // _numOfEnrolledStudentsLabel
            // 
            resources.ApplyResources(this._numOfEnrolledStudentsLabel, "_numOfEnrolledStudentsLabel");
            this._numOfEnrolledStudentsLabel.Name = "_numOfEnrolledStudentsLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            // RoomSelectionForm
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._numOfEnrolledStudentsLabel);
            this.Controls.Add(this._courseLabel);
            this.Controls.Add(this._roomsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomSelectionForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

		}
		#endregion		

		public Room getSelectedRoom()
		{
			Room room = (Room)_roomsListBox.SelectedItem;
			return room;
		}

		private void _roomsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(_roomsListBox.SelectedItem!=_currRoom)
			{
                _okButton.Enabled=true;
			}
			else
			{
                _okButton.Enabled=false;
			}
		
		}

		

		private void _roomsListBox_DoubleClick(object sender, System.EventArgs e)
		{
			if(_okButton.Enabled)
			{
				this.DialogResult=DialogResult.OK;
			}			
		}
	}
}
