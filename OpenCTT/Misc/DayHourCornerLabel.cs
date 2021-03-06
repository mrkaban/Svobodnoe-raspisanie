#region Open Course Timetabler - An application for school and university course timetabling
//
// Author:
//   Ivan ?urak (mailto:Ivan.Curak@fesb.hr)
//
// Copyright (c) 2007 Ivan ?urak, Split, Croatia
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
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using System.Resources;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for DayHourCornerLabel.
	/// </summary>
	public class DayHourCornerLabel:System.Windows.Forms.Label
	{	
		private static ResourceManager RES_MANAGER;	
		private ContextMenu _labelContextMenu;

		public DayHourCornerLabel()
		{
			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.DayHourCornerLabel",this.GetType().Assembly);
			}
			
			this.Text=RES_MANAGER.GetString("DayHourCornerLabel.Text");
			this.Size=new System.Drawing.Size(Constants.DAY_HOUR_PANEL_WIDTH+Constants.DAY_HOUR_LABEL_OFFSET,Constants.DAY_HOUR_PANEL_HEIGHT);

			this.Location=new System.Drawing.Point(0,Constants.DAY_HOUR_PANEL_OFFSET_Y);

			this.BackColor=System.Drawing.Color.LightBlue;

			
			this.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BorderStyle= System.Windows.Forms.BorderStyle.FixedSingle;	

			_labelContextMenu = new ContextMenu();
			this.ContextMenu=_labelContextMenu;			

			_labelContextMenu.Popup += new System.EventHandler(this._labelContextMenu_Popup);

			this.MouseEnter += new System.EventHandler(this.thisLabel_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.thisLabel_MouseLeave);		

			
		}


		private void _labelContextMenu_Popup(object sender, System.EventArgs e)
		{	
			_labelContextMenu.MenuItems.Clear();			
			
            MenuItem menuItem1 = new MenuItem(RES_MANAGER.GetString("addNewDayMenuItem.Text"));
			menuItem1.Click += new System.EventHandler(addDays_Click);
			_labelContextMenu.MenuItems.Add(menuItem1);
			_labelContextMenu.MenuItems.Add(new MenuItem("-"));

			MenuItem menuItem2 = new MenuItem(RES_MANAGER.GetString("addNewTermMenuItem.Text"));
			menuItem2.Click += new System.EventHandler(addTerm_Click);
			_labelContextMenu.MenuItems.Add(menuItem2);

		}

		private void thisLabel_MouseEnter(object sender, System.EventArgs e)
		{
			this.BackColor=System.Drawing.Color.DeepSkyBlue;
			
		}

		private void thisLabel_MouseLeave(object sender, System.EventArgs e)
		{			
			this.BackColor=System.Drawing.Color.LightBlue;			
		}

		private void addDays_Click(object sender, System.EventArgs e)
		{
			AddDaysForm adf= new AddDaysForm();
			adf.ShowDialog(AppForm.getAppForm());

			if (adf.DialogResult == DialogResult.OK)
			{
				ArrayList tempList = new ArrayList();
				for(int n=0;n<7;n++)
				{
					if(((CheckBox)adf.getGroup().Controls[n]).Checked==true && ((CheckBox)adf.getGroup().Controls[n]).Enabled==true)
					{
						tempList.Add(n);
					}
				}

				AddDaysCmd adsCmd= new AddDaysCmd(tempList);
				CommandProcessor.getCommandProcessor().doCmd(adsCmd);
			
			}
		}

		private void addTerm_Click(object sender, System.EventArgs e)
		{
			AddTermForm tpf= new AddTermForm(true,null);
			tpf.ShowDialog(AppForm.getAppForm());

			if (tpf.DialogResult == DialogResult.OK)
			{
				int index = tpf.getPosOfNewTerm();
				int [] termData = tpf.getNewTermData();

				AddTermCmd atdCmd= new AddTermCmd(index,termData);
				CommandProcessor.getCommandProcessor().doCmd(atdCmd);				
			}
		}
	}
}
