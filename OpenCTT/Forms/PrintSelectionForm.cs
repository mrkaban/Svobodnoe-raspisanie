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
using System.Data;
using System.Globalization;
using System.Resources;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for PrintSelectionForm.
	/// </summary>
	public class PrintSelectionForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private int _type;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Button _selAllButton;
		private System.Windows.Forms.Button _delAllButton;
		private System.Windows.Forms.TreeView _treeView1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PrintSelectionForm(int type)
		{
            _type=type;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
							
			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.PrintSelectionForm",this.GetType().Assembly);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintSelectionForm));
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._delAllButton = new System.Windows.Forms.Button();
            this._selAllButton = new System.Windows.Forms.Button();
            this._treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            resources.ApplyResources(this._okButton, "_okButton");
            this._okButton.Name = "_okButton";
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._cancelButton, "_cancelButton");
            this._cancelButton.Name = "_cancelButton";
            // 
            // _delAllButton
            // 
            resources.ApplyResources(this._delAllButton, "_delAllButton");
            this._delAllButton.Name = "_delAllButton";
            this._delAllButton.Click += new System.EventHandler(this._delAllButton_Click);
            // 
            // _selAllButton
            // 
            resources.ApplyResources(this._selAllButton, "_selAllButton");
            this._selAllButton.Name = "_selAllButton";
            this._selAllButton.Click += new System.EventHandler(this._selAllButton_Click);
            // 
            // _treeView1
            // 
            this._treeView1.BackColor = System.Drawing.Color.Gainsboro;
            this._treeView1.CheckBoxes = true;
            resources.ApplyResources(this._treeView1, "_treeView1");
            this._treeView1.ItemHeight = 16;
            this._treeView1.Name = "_treeView1";
            this._treeView1.ShowRootLines = false;
            this._treeView1.Sorted = true;
            this._treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this._treeView1_AfterCheck);
            // 
            // PrintSelectionForm
            // 
            resources.ApplyResources(this, "$this");
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._delAllButton);
            this.Controls.Add(this._selAllButton);
            this.Controls.Add(this._treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintSelectionForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.PrintSelectionForm_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void PrintSelectionForm_Load(object sender, System.EventArgs e)
		{
			switch(_type)
			{
				case 1:					
					if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
					{
				        this.Text=RES_MANAGER.GetString("type.ep.university.this.text");

					}
					else
					{			
                        this.Text=RES_MANAGER.GetString("type.ep.school.this.text");
					}				

					fillTreeEduPrograms();
					break;
				case 2:					
					this.Text=RES_MANAGER.GetString("type.teacher.this.text");
					fillTreeTeachers();
					break;
				case 3:					
					this.Text=RES_MANAGER.GetString("type.room.this.text");
					fillTreeRooms();
					break;
			}
		}

		private void fillTreeTeachers()
		{
			_treeView1.BeginUpdate();
			foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes)
			{
				TreeNode tn = new TreeNode(teacher.getTreeText());
				tn.Tag=teacher;
				_treeView1.Nodes.Add(tn);
			}
            _treeView1.ExpandAll();
			_treeView1.EndUpdate();
			this.Refresh();
		}

		private void fillTreeRooms()
		{
			_treeView1.BeginUpdate();
			foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes)
			{
				TreeNode tn = new TreeNode(room.getName());
				tn.Tag=room;
				_treeView1.Nodes.Add(tn);
			}
			_treeView1.ExpandAll();
			_treeView1.EndUpdate();
			this.Refresh();			
		}


		private void fillTreeEduPrograms()
		{
			_treeView1.BeginUpdate();
			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
			{
				TreeNode tn = new TreeNode(epg.getName());
				tn.Tag=epg;				
				
				_treeView1.Nodes.Add(tn);

				foreach(EduProgram ep in epg.Nodes)
				{
					TreeNode tnSub = new TreeNode(ep.Text);
					tnSub.Tag=ep;
					tn.Nodes.Add(tnSub);

				}
			}
            _treeView1.ExpandAll();
			_treeView1.EndUpdate();
			this.Refresh();
		}

		private void _selAllButton_Click(object sender, System.EventArgs e)
		{
			foreach(TreeNode tn in _treeView1.Nodes)
			{
				tn.Checked=true;				
			}
			_treeView1.ExpandAll();
		}

		private void _delAllButton_Click(object sender, System.EventArgs e)
		{
			foreach(TreeNode tn in _treeView1.Nodes)
			{
				tn.Checked=false;				
			}
			_treeView1.ExpandAll();
		}

		private void _okButton_Click(object sender, System.EventArgs e)
		{
			switch(_type)
			{
				case 1:
					printForEduPrograms();
					break;
				case 2:
					printForTeachers();
					break;
				case 3:
					printForRooms();					
					break;
			}
		
		}

		private void printForRooms()
		{
			ArrayList listForPrint = new ArrayList();			

			foreach(TreeNode tn in _treeView1.Nodes)
			{
				if(tn.Checked)
				{
					listForPrint.Add((Room)tn.Tag);
				}
			}

			if(listForPrint.Count>0)
			{
				ArrayList pdfReportDataTablesList = ModelOperations.getPdfSharpReportDataTablesList(listForPrint,3);
				PdfCreator.createPdfDocument(pdfReportDataTablesList);
			}

		}


		private void printForTeachers()
		{
			ArrayList listForPrint = new ArrayList();			

			foreach(TreeNode tn in _treeView1.Nodes)
			{
				if(tn.Checked)
				{
					listForPrint.Add((Teacher)tn.Tag);
				}
			}

			if(listForPrint.Count>0)
			{
				ArrayList pdfReportDataTablesList = ModelOperations.getPdfSharpReportDataTablesList(listForPrint,2);
				PdfCreator.createPdfDocument(pdfReportDataTablesList);
			}

		}


		private void printForEduPrograms()
		{
			ArrayList listForPrint = new ArrayList();			

			foreach(TreeNode tn in _treeView1.Nodes)
			{				
				if(tn.Nodes.Count>0)
				{
					foreach(TreeNode tnSub in tn.Nodes)
					{
						if(tnSub.Checked)
						{
							listForPrint.Add((EduProgram)tnSub.Tag);
						}
					}
				}
			}

			if(listForPrint.Count>0)
			{
				ArrayList pdfReportDataTablesList = ModelOperations.getPdfSharpReportDataTablesList(listForPrint,1);
				PdfCreator.createPdfDocument(pdfReportDataTablesList);
			}

		}

		private void _treeView1_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			TreeNode tn = e.Node;			
			if(tn.Tag is EduProgramGroup)
			{
				if(tn.Checked)
				{
					foreach(TreeNode tnSub in tn.Nodes)
					{
						tnSub.Checked=true;
					}
				}
				else
				{					
					foreach(TreeNode tnSub in tn.Nodes)
					{				
						tnSub.Checked=false;
					}					

				}
			}
			else if(tn.Tag is EduProgram)
			{
				TreeNode tnUp = (TreeNode)tn.Parent;
				bool isALOU=false;
				foreach(TreeNode tnSub in tnUp.Nodes)
				{
					if(!tnSub.Checked)
					{
                        isALOU=true;
						break;
					}
				}

				if(isALOU)
				{
					this._treeView1.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this._treeView1_AfterCheck);
					tnUp.Checked=false;
					this._treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this._treeView1_AfterCheck);
				}
				else
				{
					this._treeView1.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this._treeView1_AfterCheck);
                    tnUp.Checked=true;
					this._treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this._treeView1_AfterCheck);
				}
			}
			
		}
	}
}
