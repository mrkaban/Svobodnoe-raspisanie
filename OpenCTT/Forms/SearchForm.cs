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
	/// Summary description for SearchForm.
	/// </summary>
	public class SearchForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private static bool _instanceFlag=false;		
		private static string LAST_SEARCHED_FOR;
		private static int LAST_SEARCHED_TYPE;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _findButton;
		private System.Windows.Forms.TextBox _searchForTextBox;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.ListView _resultsListView;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SearchForm()
		{			
			if(_instanceFlag)
			{
				throw new Exception();
			}
			else
			{				
				InitializeComponent();
				_instanceFlag=true;
				LAST_SEARCHED_FOR="";
				LAST_SEARCHED_TYPE=-1;

				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.SearchForm",this.GetType().Assembly);

				if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
				{				
					radioButton1.Text= RES_MANAGER.GetString("radioButton1.university.Text");

				}
				else
				{			
					radioButton1.Text= RES_MANAGER.GetString("radioButton1.school.Text");
				}
		
				
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
				_instanceFlag=false;				
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this._searchForTextBox = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._findButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _searchForTextBox
            // 
            resources.ApplyResources(this._searchForTextBox, "_searchForTextBox");
            this._searchForTextBox.Name = "_searchForTextBox";
            this._searchForTextBox.TextChanged += new System.EventHandler(this._searchForTextBox_TextChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabStop = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton3);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // _findButton
            // 
            resources.ApplyResources(this._findButton, "_findButton");
            this._findButton.Name = "_findButton";
            this._findButton.Click += new System.EventHandler(this._findButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._cancelButton, "_cancelButton");
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // SearchForm
            // 
            this.AcceptButton = this._findButton;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._findButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._searchForTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void _cancelButton_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void _findButton_Click(object sender, System.EventArgs e)
		{	
			this.ClientSize = new System.Drawing.Size(528, 410);

			if(_resultsListView==null)
			{				
				_resultsListView = new ListView();
				ColumnHeader  columnHeader1=new ColumnHeader();

				_resultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  columnHeader1});
				_resultsListView.FullRowSelect = true;
				_resultsListView.GridLines = true;
				_resultsListView.Location = new System.Drawing.Point(24, 192);
				_resultsListView.MultiSelect = false;
				_resultsListView.Name = "_resultsListView";
				_resultsListView.Size = new System.Drawing.Size(488, 195);
				_resultsListView.TabIndex = 10;
				_resultsListView.View = System.Windows.Forms.View.Details;
				
 
				
				columnHeader1.Width = 484;

				this._resultsListView.SmallImageList=AppForm.getAppForm().getTreeImageList();

				this._resultsListView.SelectedIndexChanged += new System.EventHandler(this._resultsListView_SelectedIndexChanged);				
			
				this.Controls.Add(_resultsListView);
			}
			else
			{
				_resultsListView.Items.Clear();
			}

			LAST_SEARCHED_FOR=_searchForTextBox.Text.Trim();

			if(radioButton1.Checked)
			{
				LAST_SEARCHED_TYPE=0;
			}
			else if(radioButton2.Checked)
			{
				LAST_SEARCHED_TYPE=1;

			}else LAST_SEARCHED_TYPE=2;
			
			_findButton.Enabled=false;
		
			ModelOperations.searchForStringInDocument(_searchForTextBox.Text.Trim(),_resultsListView,LAST_SEARCHED_TYPE);
            			
			_resultsListView.Columns[0].Text=RES_MANAGER.GetString("_resultsListView.Column.Text1")+" "+_resultsListView.Items.Count+" - "+RES_MANAGER.GetString("_resultsListView.Column.Text2")+" '"+_searchForTextBox.Text.Trim()+"'";
			
		}

		private void _searchForTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_searchForTextBox.Text.Trim()!=LAST_SEARCHED_FOR && _searchForTextBox.Text.Trim()!="")
			{
				_findButton.Enabled=true;				
			}
			else
			{
				_findButton.Enabled=false;
			}
		}

		private void _resultsListView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(_resultsListView.SelectedItems.Count>0)
			{
				ListViewItem lvi=_resultsListView.SelectedItems[0];
				TreeNode tn=(TreeNode)lvi.Tag;
				if(LAST_SEARCHED_TYPE==0)
				{
					AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
					AppForm.getAppForm().getCoursesTreeView().SelectedNode=tn;
				}
				else if(LAST_SEARCHED_TYPE==1)
				{		
					AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;
					AppForm.getAppForm().getTeachersTreeView().SelectedNode=tn;
				}
				else if(LAST_SEARCHED_TYPE==2)
				{
					AppForm.getAppForm().getTreeTabControl().SelectedIndex=2;
					AppForm.getAppForm().getRoomsTreeView().SelectedNode=tn;
				}
			}
		
		}

		private void radioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			int type;
			if(radioButton1.Checked)
			{
				type=0;
			}
			else if(radioButton2.Checked)
			{
                type=1;
			}
			else
			{
				type=2;
			}

			if(type!=LAST_SEARCHED_TYPE || (_searchForTextBox.Text.Trim()!=LAST_SEARCHED_FOR && _searchForTextBox.Text.Trim()!=""))
			{
				_findButton.Enabled=true;
			}
			else
			{
				_findButton.Enabled=false;
			}
		
		}

		
		
	}
}
