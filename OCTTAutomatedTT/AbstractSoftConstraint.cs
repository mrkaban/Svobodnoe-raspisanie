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
using System.Collections.Generic;
using System.Text;

namespace OpenCTT.Automated
{
    public abstract class AbstractSoftConstraint
    {
        protected Object _theObj;
        protected Object[] _myArgs;
        protected Object[] _relatedObjects;
        protected string _scName;


        public AbstractSoftConstraint(Object theObj, Object[] myArgs, Object[]relatedObjects)
        {
            _theObj = theObj;
            _myArgs = myArgs;
            _relatedObjects = relatedObjects;            
        }

        public string getSCName()
        {
            return _scName;
        }


        public abstract double evaluateSC();
        

    }
}
