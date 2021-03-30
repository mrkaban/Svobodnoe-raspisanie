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
	/// Summary description for AddTermForm.
	/// </summary>
	public class AddTermForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;
		private bool _isNew;
		private int[] _termData;
		private int _myPosInList;

		private System.Windows.Forms.NumericUpDown _fromHUpDown;
		private System.Windows.Forms.NumericUpDown _fromMUpDown;
		private System.Windows.Forms.NumericUpDown _toMUpDown;
		private System.Windows.Forms.NumericUpDown _toHUpDown;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddTermForm(bool isNew, int[] tData)
		{		
			InitializeComponent();

			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.AddTermForm",this.GetType().Assembly);
			}

			_isNew=isNew;
			_termData=tData;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTermForm));
            this._fromHUpDown = new System.Windows.Forms.NumericUpDown();
            this._fromMUpDown = new System.Windows.Forms.NumericUpDown();
            this._toMUpDown = new System.Windows.Forms.NumericUpDown();
            this._toHUpDown = new System.Windows.Forms.NumericUpDown();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this._fromHUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._fromMUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._toMUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._toHUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _fromHUpDown
            // 
            resources.ApplyResources(this._fromHUpDown, "_fromHUpDown");
            this._fromHUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this._fromHUpDown.Name = "_fromHUpDown";
            this._fromHUpDown.Leave += new System.EventHandler(this.UpDown_Leave);
            // 
            // _fromMUpDown
            // 
            resources.ApplyResources(this._fromMUpDown, "_fromMUpDown");
            this._fromMUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this._fromMUpDown.Name = "_fromMUpDown";
            this._fromMUpDown.Leave += new System.EventHandler(this.UpDown_Leave);
            // 
            // _toMUpDown
            // 
            resources.ApplyResources(this._toMUpDown, "_toMUpDown");
            this._toMUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this._toMUpDown.Name = "_toMUpDown";
            this._toMUpDown.Leave += new System.EventHandler(this.UpDown_Leave);
            // 
            // _toHUpDown
            // 
            resources.ApplyResources(this._toHUpDown, "_toHUpDown");
            this._toHUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this._toHUpDown.Name = "_toHUpDown";
            this._toHUpDown.Leave += new System.EventHandler(this.UpDown_Leave);
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
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._fromMUpDown);
            this.groupBox1.Controls.Add(this._fromHUpDown);
            this.groupBox1.Controls.Add(this.label6);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this._toMUpDown);
            this.groupBox2.Controls.Add(this._toHUpDown);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // AddTermForm
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTermForm";
            this.ShowInTaskbar = false;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TermPropertiesForm_Closing);
            this.Load += new System.EventHandler(this.TermPropertiesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._fromHUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._fromMUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._toMUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._toHUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		

		private void TermPropertiesForm_Load(object sender, System.EventArgs e)
		{
			if(!_isNew)
			{
				_fromHUpDown.Value=_termData[0];
				_fromMUpDown.Value=_termData[1];
				_toHUpDown.Value=_termData[2];
				_toMUpDown.Value=_termData[3];
			}			
		}

		public int[] getNewTermData()
		{
			int[] newTermData= new int[4]{System.Convert.ToInt16(_fromHUpDown.Value),System.Convert.ToInt16(_fromMUpDown.Value),System.Convert.ToInt16(_toHUpDown.Value),System.Convert.ToInt16(_toMUpDown.Value)};
			return newTermData;
		}

		private void TermPropertiesForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.DialogResult==DialogResult.OK)
			{
				if(_isNew)
				{
					if(!checkIfTermIsCorrect())
					{
						e.Cancel=true;
						
						string message1 = RES_MANAGER.GetString("TermPropertiesForm_Closing.msb.inputerror.message");
					
						string caption1 = RES_MANAGER.GetString("TermPropertiesForm_Closing.msb.inputerror.caption");

						MessageBoxButtons buttons1 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message1, caption1, buttons1,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
					else if(!checkIfTermIsOKRelOtherTerms())
					{
						e.Cancel=true;
						
						string message2 = RES_MANAGER.GetString("TermPropertiesForm_Closing.msb.overlapping.message");

						string caption2 = RES_MANAGER.GetString("TermPropertiesForm_Closing.msb.overlapping.caption");

						MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message2, caption2, buttons2,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
					else 
					{
						_myPosInList=calculatePosInList();	
					}
				}
			}			
		}

		private bool checkIfTermIsCorrect()
		{
			if(_toHUpDown.Value<_fromHUpDown.Value)
			{
				return false;
			}
			else if(_toHUpDown.Value==_fromHUpDown.Value)
			{
				if(_toMUpDown.Value>_fromMUpDown.Value)
				{
					return true;
				}else return false;
			}else return true;
		}

		private bool checkIfTermIsOKRelOtherTerms()
		{
			if(checkIfTimeIsInsideExistingTerm(System.Convert.ToInt16(_fromHUpDown.Value), System.Convert.ToInt16(_fromMUpDown.Value))) return false;
			if(checkIfTimeIsInsideExistingTerm(System.Convert.ToInt16(_toHUpDown.Value), System.Convert.ToInt16(_toMUpDown.Value))) return false;
			if(checkIfStartInInterspaceAndEndNotBeforeNextTerm()) return false;

			return true;
		}

		private bool checkIfTimeIsInsideExistingTerm(int hour, int min)
		{
			foreach(int[] oneTerm in AppForm.CURR_OCTT_DOC.IncludedTerms)
			{
				if(checkOneTime(hour, min, oneTerm)) return true;
			}

			return false;
		}

		private bool checkOneTime(int hour, int min, int[] oneTerm)
		{
			if(hour>oneTerm[0] || (hour==oneTerm[0]&&min>oneTerm[1]))
			{
				if(hour<oneTerm[2] || (hour==oneTerm[2] && min<oneTerm[3]))
				{
					return true;
				}
			}
			return false;
		}
		

		private bool checkIfStartInInterspaceAndEndNotBeforeNextTerm()
		{
			int [] possTerm = new int[4]{System.Convert.ToInt16(_fromHUpDown.Value),System.Convert.ToInt16(_fromMUpDown.Value),System.Convert.ToInt16(_toHUpDown.Value),System.Convert.ToInt16(_toMUpDown.Value)};
			foreach(int[] oneTerm in AppForm.CURR_OCTT_DOC.IncludedTerms)
			{
				int hour=oneTerm[0];
				int min=oneTerm[1];
				if(checkOneTime(hour, min,possTerm)) return true;

				hour=oneTerm[2];
				min=oneTerm[3];
				if(checkOneTime(hour, min,possTerm)) return true;				
			}

			return false;
		}

		private int calculatePosInList()
		{
			int startH=System.Convert.ToInt16(_fromHUpDown.Value);
			int startM=System.Convert.ToInt16(_fromMUpDown.Value);
            
			int counter=0;
			foreach(int[] oneTerm in AppForm.CURR_OCTT_DOC.IncludedTerms)
			{
				if(oneTerm[0]>startH || (oneTerm[0]==startH && oneTerm[1]>=startM)) return counter;
				counter++;
			}
            
			return counter;
		}

		public int getPosOfNewTerm()
		{
			return _myPosInList;
		}

		private void UpDown_Leave(object sender, System.EventArgs e)
		{
			NumericUpDown ud = (NumericUpDown)sender;
			if(ud.Value>ud.Maximum) ud.Value=ud.Maximum;
		
		}

	}
}
