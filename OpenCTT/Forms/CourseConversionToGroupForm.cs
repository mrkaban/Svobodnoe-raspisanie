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
	/// Summary description for CourseConversionToGroupForm
	/// </summary>
	public class CourseConversionToGroupForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private TextBox [,] _allTBoxes=new TextBox[7,3];
		private Course _course;
		private System.Windows.Forms.Label _topLabel;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown _numericUpDown1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CourseConversionToGroupForm(Course course)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.CourseConversionToGroupForm",this.GetType().Assembly);
			}

			_course=course;

			_topLabel.Text+=" "+_course.getFullName()+"\n";			
			_topLabel.Text+=RES_MANAGER.GetString("numofenrolledstudents.text")+" "+_course.getNumberOfEnrolledStudents().ToString();
			
			groupBox1.Controls.Clear();

			int rowY1=48;
			int rowYStep=24;

			int posX1=10;
			int posX2=26;
			int posX3=171;

			Size size1=new Size(16,22);
			Size size2=new Size(145,22);
			Size size3=new Size(64,22);

			for(int n=0;n<7;n++)
			{
				TextBox tb1=new TextBox();
				tb1.Location = new Point(posX1, rowY1+n*rowYStep);				
				tb1.ReadOnly = true;
				tb1.Size = size1;				
				tb1.TabStop = false;
				tb1.Text = (n+1)+".";
				_allTBoxes[n,0]=tb1;

				TextBox tb2=new TextBox();
				tb2.Location = new Point(posX2, rowY1+n*rowYStep);				
				tb2.ReadOnly = false;
				tb2.Size = size2;				
				tb2.TabStop = true;
				tb2.TabIndex=n*2+1;
				tb2.TextChanged += new System.EventHandler(tb_TextChanged);
				_allTBoxes[n,1]=tb2;

				TextBox tb3=new TextBox();
				tb3.Location = new Point(posX3, rowY1+n*rowYStep);				
				tb3.ReadOnly = false;
				tb3.TextAlign=System.Windows.Forms.HorizontalAlignment.Right;
				tb3.Size = size3;	
				tb3.TabStop = true;
				tb3.TabIndex=n*2+2;
				tb3.TextChanged += new System.EventHandler(tb_TextChanged);
				_allTBoxes[n,2]=tb3;
				
			}

			showTBoxes();		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseConversionToGroupForm));
            this._topLabel = new System.Windows.Forms.Label();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // _topLabel
            // 
            this._topLabel.BackColor = System.Drawing.Color.Gainsboro;
            this._topLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this._topLabel, "_topLabel");
            this._topLabel.Name = "_topLabel";
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _numericUpDown1
            // 
            resources.ApplyResources(this._numericUpDown1, "_numericUpDown1");
            this._numericUpDown1.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this._numericUpDown1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._numericUpDown1.Name = "_numericUpDown1";
            this._numericUpDown1.ReadOnly = true;
            this._numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // CourseConversionToGroupForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._topLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CourseConversionToGroupForm";
            this.ShowInTaskbar = false;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CourseConversionToGroupForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		

		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
			groupBox1.Controls.Clear();

			int udv=(int)_numericUpDown1.Value;
			switch(udv)
			{
				case 2:
					groupBox1.Height=104;
					this.Height=304;
					_okButton.Location=new Point(_okButton.Location.X,232);
					_cancelButton.Location=new Point(_cancelButton.Location.X,232);
					break;

				case 3:
					groupBox1.Height=128;
					this.Height=328;
					_okButton.Location=new Point(_okButton.Location.X,256);
					_cancelButton.Location=new Point(_cancelButton.Location.X,256);
					break;
				
				case 4:
					groupBox1.Height=152;
					this.Height=362;
					_okButton.Location=new Point(_okButton.Location.X,280);
					_cancelButton.Location=new Point(_cancelButton.Location.X,280);
					break;

				case 5:
					groupBox1.Height=176;
					this.Height=386;
					_okButton.Location=new Point(_okButton.Location.X,304);
					_cancelButton.Location=new Point(_cancelButton.Location.X,304);
					break;

				case 6:
					groupBox1.Height=200;
					this.Height=410;
					_okButton.Location=new Point(_okButton.Location.X,328);
					_cancelButton.Location=new Point(_cancelButton.Location.X,328);
					break;
				case 7:
					groupBox1.Height=224;
					this.Height=434;
					_okButton.Location=new Point(_okButton.Location.X,362);
					_cancelButton.Location=new Point(_cancelButton.Location.X,362);
					break;
			}

			showTBoxes();		
			checkOkButtonState();
			
		}		

		private void showTBoxes()
		{
			Label label = new Label();		
			label.Text=RES_MANAGER.GetString("groupname.text");
			label.Location=new Point(62,28);
			label.Size=new Size(96,20);
			groupBox1.Controls.Add(label);

			label = new Label();		
			label.Text=RES_MANAGER.GetString("numofstudents.text");
			label.Location=new Point(176,28);
			label.Size=new Size(60,20);
			groupBox1.Controls.Add(label);

			for(int j=0;j<_numericUpDown1.Value;j++)
			{
				for(int k=0;k<3;k++)
				{
					TextBox tb=(TextBox)_allTBoxes[j,k];			
					groupBox1.Controls.Add(tb);
			
				}
			}

			
		}

		private void CourseConversionToGroupForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.DialogResult==DialogResult.OK)
			{			
				ArrayList allGroupsList=new ArrayList();
				int totNumOfStud=0;
				for(int n=0;n<_numericUpDown1.Value;n++)
				{
					string gName=((TextBox)_allTBoxes[n,1]).Text.Trim();
					if(!allGroupsList.Contains(gName))
					{
						allGroupsList.Add(gName);                        
					}					

					int numOfStud=System.Convert.ToInt32(((TextBox)_allTBoxes[n,2]).Text.Trim());
					totNumOfStud+=numOfStud;
				}

				if(totNumOfStud!=_course.getNumberOfEnrolledStudents())
				{
					e.Cancel = true;
					
					string message1= RES_MANAGER.GetString("Form_Closing.msb.groupsnotcreated.numofstuderror.message");
				
                    string caption1= RES_MANAGER.GetString("Form_Closing.msb.groupsnotcreated.numofstuderror.caption");

					MessageBoxButtons buttons1 = MessageBoxButtons.OK;					
	
					MessageBox.Show(this, message1, caption1, buttons1,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				}
				else if(allGroupsList.Count!=_numericUpDown1.Value)
				{
					e.Cancel = true;
					
					string message2= RES_MANAGER.GetString("Form_Closing.msb.groupsnotcreated.groupnameerror.message");
				
					string caption2= RES_MANAGER.GetString("Form_Closing.msb.groupsnotcreated.groupnameerror.caption");

					MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
	
					MessageBox.Show(this, message2, caption2, buttons2,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				}				

			}
		}

		private void tb_TextChanged(object sender, System.EventArgs e)
		{
			checkOkButtonState();		
		}
	
		private void checkOkButtonState()
		{
			bool isEnab=true;
			for(int j=0;isEnab & j< _numericUpDown1.Value;j++)
			{
				for(int k=1;isEnab & k<3;k++)
				{
					TextBox tb=(TextBox)_allTBoxes[j,k];
					if(k==1)
					{
						if(tb.Text.Trim()=="")
						{
							isEnab=false;                        
						}		
					}
					else
					{
						try
						{
							int st=System.Convert.ToInt32(tb.Text);
							if(st<1) isEnab=false;
						}
						catch						
						{
							isEnab=false;                        
						}

					}
				}
			}

			if(isEnab)
			{
				_okButton.Enabled=true;
			}
			else
			{
				_okButton.Enabled=false;
			}

		}

		public TextBox[,] AllTextBox
		{
			get
			{
				return _allTBoxes;
			}
        
		}

		public int NumberOfGroups
		{
			get
			{
				return (int)_numericUpDown1.Value;

			}
		}
			
		
	}
}
