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
	/// Summary description for RoomPropertiesForm.
	/// </summary>
	public class RoomPropertiesForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private bool _isNew;
		private Room _room;

		private bool _isNameOK;
		private bool _isCapacityOK;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox _nameTextBox;
		private System.Windows.Forms.TextBox _capacityTextBox;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.ErrorProvider _errorProvider1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox _extIDTextBox;
        private IContainer components;

        public RoomPropertiesForm()
		{
			InitializeComponent();

			_isNew=true;

			_isNameOK=false;
			_isCapacityOK=false;

			_errorProvider1.SetError(_capacityTextBox,"");

			RES_MANAGER = new System.Resources.ResourceManager(typeof(RoomPropertiesForm));

		}


		public RoomPropertiesForm(Room room):this()
		{	
			_isNew=false;
			_room=room;

			_isNameOK=true;
			_isCapacityOK=true;

			this._nameTextBox.Text=_room.getName();
			this._capacityTextBox.Text=_room.getRoomCapacity().ToString();
			if(_room.ExtID!=null)
			{
				this._extIDTextBox.Text=_room.ExtID;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomPropertiesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._capacityTextBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this._extIDTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider1)).BeginInit();
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
            // _nameTextBox
            // 
            resources.ApplyResources(this._nameTextBox, "_nameTextBox");
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.TextChanged += new System.EventHandler(this._nameTextBox_TextChanged);
            // 
            // _capacityTextBox
            // 
            resources.ApplyResources(this._capacityTextBox, "_capacityTextBox");
            this._capacityTextBox.Name = "_capacityTextBox";
            this._capacityTextBox.TextChanged += new System.EventHandler(this._capacityTextBox_TextChanged);
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
            // _errorProvider1
            // 
            this._errorProvider1.ContainerControl = this;
            resources.ApplyResources(this._errorProvider1, "_errorProvider1");
            // 
            // _extIDTextBox
            // 
            resources.ApplyResources(this._extIDTextBox, "_extIDTextBox");
            this._extIDTextBox.Name = "_extIDTextBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // RoomPropertiesForm
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this.label3);
            this.Controls.Add(this._extIDTextBox);
            this.Controls.Add(this._capacityTextBox);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomPropertiesForm";
            this.ShowInTaskbar = false;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		

		private void Form_Closing (Object sender, CancelEventArgs e) 
		{
			if(_isNew)
			{
				if(this.DialogResult==DialogResult.OK)
				{
					if (!Room.getIsNewNameOK(_nameTextBox.Text)) 
					{
						e.Cancel = true;
					
						string message=RES_MANAGER.GetString("Form_Closing.msb.newroomnotcreated.message");
					
						string caption=RES_MANAGER.GetString("Form_Closing.msb.newroomnotcreated.caption");

						MessageBoxButtons buttons = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message, caption, buttons,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
					else 
					{
						e.Cancel = false;		
					}
				}
			}
			else if(!_isNew)
			{
				if(this.DialogResult==DialogResult.OK)
				{
					if(_nameTextBox.Text.ToUpper()!=_room.getName().ToUpper())
					{
						if (!Room.getIsNewNameOK(_nameTextBox.Text)) 
						{
							e.Cancel = true;
					
							string message2=RES_MANAGER.GetString("Form_Closing.msb.roomdatanotchanged.message");
                    
							string caption2=RES_MANAGER.GetString("Form_Closing.msb.roomdatanotchanged.caption");

							MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
							MessageBox.Show(this, message2, caption2, buttons2,
								MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
						}
						else 
						{							
							checkNewCapacity(e);
						}
					}
					else
					{
						checkNewCapacity(e);
					}
				}

			}
		}


		private void checkNewCapacity(CancelEventArgs e)
		{
			if(System.Convert.ToInt32(_capacityTextBox.Text)>=_room.getRoomCapacity())
			{
				e.Cancel = false;
			}
			else
			{
				//new capacity is smaller
				if(Room.getIsNewCapacityOK(_room,System.Convert.ToInt32(_capacityTextBox.Text)))
				{
					e.Cancel = false;
				}
				else
				{
					e.Cancel = true;
					
					string message3=RES_MANAGER.GetString("Form_Closing.checkNewCapacity.msb.roomdatanotchanged.message");
					
					string caption3=RES_MANAGER.GetString("Form_Closing.checkNewCapacity.msb.roomdatanotchanged.caption");

					MessageBoxButtons buttons3 = MessageBoxButtons.OK;					
		
					MessageBox.Show(this, message3, caption3, buttons3,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				}
			}

		}

		private void _capacityTextBox_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				int x = Int32.Parse(_capacityTextBox.Text);
				if(x<=0)
				{
					_isCapacityOK=false;					
					_errorProvider1.SetError(_capacityTextBox,RES_MANAGER.GetString("capacity.greater.than.zero.text"));
					_okButton.Enabled=false;
				}
				else
				{
					_isCapacityOK=true;
					_errorProvider1.SetError(_capacityTextBox,"");
					if(_isNameOK)
					{
						_okButton.Enabled=true;
					}
					else
					{
						_okButton.Enabled=false;
					}
				}
			}
			catch
			{
				_isCapacityOK=false;				
				_errorProvider1.SetError(_capacityTextBox,RES_MANAGER.GetString("capacity.greater.than.zero.text"));
				_okButton.Enabled=false;
			}
		
		}

		private void _nameTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_nameTextBox.Text.Trim()!="") 
			{
				_isNameOK=true;
				if(_isCapacityOK)
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
				_isNameOK=false;
				_okButton.Enabled=false;

			}
		
		}

		public TextBox NameTextBox
		{
			get
			{
				return _nameTextBox;
			}
		}

		public TextBox CapacityTextBox
		{
			get
			{
				return _capacityTextBox;
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
