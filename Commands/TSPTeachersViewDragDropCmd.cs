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

namespace OpenCTT
{
	/// <summary>
	/// Summary description for TSPTeachersViewDragDropCmd.
	/// </summary>
	public class TSPTeachersViewDragDropCmd:AbstractCommand
	{
		private Course _dropedCourse;
		private TimeSlotPanel _tsp;
		private TreeNode _selectedNode;
		private int _indexRow;
		private int _indexCol;
		private ArrayList _forUndoRedoList;

		public TSPTeachersViewDragDropCmd(Course dropedCourse, TimeSlotPanel tsp)
		{
			_dropedCourse=dropedCourse;
			_tsp=tsp;
			_indexRow=_tsp.getIndexRow();
			_indexCol=_tsp.getIndexCol();			
			_selectedNode=AppForm.getAppForm().getTeachersTreeView().SelectedNode;
			
		}

		public override void doit()
		{
			_forUndoRedoList= new ArrayList();
			
			ArrayList possibleRooms=_tsp.calculateAllAllowedRooms(_dropedCourse,_indexRow,_indexCol);
			
			IEnumerator puEnum = possibleRooms.GetEnumerator();
			Room minCapacityRoom=null;

			for(int n=0;n<possibleRooms.Count;n++)
			{
				puEnum.MoveNext();
				Room room = (Room)puEnum.Current;
				if(n==0)
				{
					minCapacityRoom=room;
				}
				else
				{
					if(room.getRoomCapacity()< minCapacityRoom.getRoomCapacity())
					{
						minCapacityRoom=room;
					}

				}
			}			
			
			_tsp.makeSubLabel(_dropedCourse,minCapacityRoom);

			EduProgram thisEP=(EduProgram)_dropedCourse.Parent;
			ArrayList [,] mytt=thisEP.getTimetable();
			
			ArrayList lessonsInOneTimeSlot;
			if(mytt[_indexRow,_indexCol]==null) 
			{
				lessonsInOneTimeSlot = new ArrayList();                
			}
			else
			{
				lessonsInOneTimeSlot=mytt[_indexRow,_indexCol];
			}

			
			Object [] courseAndRoomPair=new Object[2];
			courseAndRoomPair[0]=_dropedCourse;
			courseAndRoomPair[1]=minCapacityRoom;

			lessonsInOneTimeSlot.Add(courseAndRoomPair);
			mytt[_indexRow, _indexCol]=lessonsInOneTimeSlot;
			
			_forUndoRedoList.Add(courseAndRoomPair);
					
			if(_dropedCourse.getCoursesToHoldTogetherList().Count>0)
			{
				foreach(Course courseHT in _dropedCourse.getCoursesToHoldTogetherList())
				{
					EduProgram epHT=(EduProgram)courseHT.Parent;
					ArrayList [,] myttHT=epHT.getTimetable();

					ArrayList lessonsInOneTimeSlotHT;
					if(myttHT[_indexRow,_indexCol]==null) 
					{
						lessonsInOneTimeSlotHT = new ArrayList();                
					}
					else
					{
						lessonsInOneTimeSlotHT=myttHT[_indexRow,_indexCol];
					}

			
					Object [] courseAndRoomPairHT=new Object[2];

					courseAndRoomPairHT[0]=courseHT;
					courseAndRoomPairHT[1]=minCapacityRoom;

					lessonsInOneTimeSlotHT.Add(courseAndRoomPairHT);
					myttHT[_indexRow, _indexCol]=lessonsInOneTimeSlotHT;
					_tsp.makeSubLabel(courseHT,minCapacityRoom);
					
					_forUndoRedoList.Add(courseAndRoomPairHT);
					

				}
			}
		}

		public override void undo()
		{
			foreach(Object [] oneItem in _forUndoRedoList)
			{
				Course course=(Course)oneItem[0];

				EduProgram thisEP=(EduProgram)course.Parent;
				ArrayList [,] mytt=thisEP.getTimetable();			
				ArrayList lessonsInOneTimeSlot=mytt[_indexRow,_indexCol];
				lessonsInOneTimeSlot.Remove(oneItem);
			}
	
			if(AppForm.getAppForm().getTreeTabControl().SelectedIndex!=1)
			{
				AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged -=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;
				AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged +=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
			}
			
			AppForm.getAppForm().getTeachersTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);
			AppForm.getAppForm().getTeachersTreeView().SelectedNode=_selectedNode;
			AppForm.getAppForm().getTeachersTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);

			AppForm.getAppForm().ttvRefreshTimetablePanel(_selectedNode,false);
		}

		public override void redo()
		{
			foreach(Object [] oneItem in _forUndoRedoList)
			{
				Course course=(Course)oneItem[0];

				EduProgram thisEP=(EduProgram)course.Parent;
				ArrayList [,] mytt=thisEP.getTimetable();			
				
				ArrayList lessonsInOneTimeSlot;
				if(mytt[_indexRow,_indexCol]==null) 
				{
					lessonsInOneTimeSlot = new ArrayList();                
				}
				else
				{
					lessonsInOneTimeSlot=mytt[_indexRow,_indexCol];
				}

				lessonsInOneTimeSlot.Add(oneItem);
				mytt[_indexRow,_indexCol]=lessonsInOneTimeSlot;
			}
		}
	}
}
