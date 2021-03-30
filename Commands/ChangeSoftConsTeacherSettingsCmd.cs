#region Open Course Timetabler - An application for school and university course timetabling
//
// Author:
//   Ivan �urak (mailto:Ivan.Curak@fesb.hr)
//
// Copyright (c) 2007 Ivan �urak, Split, Croatia
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

namespace OpenCTT
{
    /// <summary>
    /// Summary description for ChangeTeacherDataCmd.
    /// </summary>
    public class ChangeSoftConsTeacherSettingsCmd : AbstractCommand
    {
        Teacher _teacher;

        int _newMaxHContinuously;
        int _newMaxHDaily;
        int _newMaxDaysPerWeek;

        int _oldMaxHContinuously;
        int _oldMaxHDaily;
        int _oldMaxDaysPerWeek;

        public ChangeSoftConsTeacherSettingsCmd(Teacher teacher, int newMaxHContinuously, int newMaxHDaily, int newMaxDaysPerWeek)
        {
            _teacher = teacher;

            _newMaxHContinuously = newMaxHContinuously;
            _newMaxHDaily = newMaxHDaily;
            _newMaxDaysPerWeek = newMaxDaysPerWeek;

            _oldMaxHContinuously = _teacher.SCMaxHoursContinously;
            _oldMaxHDaily = _teacher.SCMaxHoursDaily;
            _oldMaxDaysPerWeek = _teacher.SCMaxDaysPerWeek;
        }

        public override void doit()
        {
            _teacher.SCMaxHoursContinously= _newMaxHContinuously;
            _teacher.SCMaxHoursDaily = _newMaxHDaily;
            _teacher.SCMaxDaysPerWeek = _newMaxDaysPerWeek;

            AppForm.getAppForm().getTreeTabControl().SelectedIndex = 1;
            AppForm.getAppForm().getTeachersTreeView().SelectedNode = _teacher;

        }

        public override void undo()
        {
            _teacher.SCMaxHoursContinously = _oldMaxHContinuously;
            _teacher.SCMaxHoursDaily = _oldMaxHDaily;
            _teacher.SCMaxDaysPerWeek = _oldMaxDaysPerWeek;

            AppForm.getAppForm().getTreeTabControl().SelectedIndex = 1;
            AppForm.getAppForm().getTeachersTreeView().SelectedNode = _teacher;

        }

        public override void redo()
        {
            doit();
        }

    }
}
