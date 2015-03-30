using System.Collections.Generic;

namespace Hunters
{
    class Department
    {
        private string _nameOfDepartment;
        private int _numberOfHunters;
        private List<Region> _listOfRegions;


        public string NameOfDepartment
        {
            get { return _nameOfDepartment; }
            set { _nameOfDepartment = value; }
        }

        public int NumberOfHunters
        {
            get { return _numberOfHunters; }
            set { _numberOfHunters = value; }
        }

        public List<Region> ListOfList
        {
            get { return _listOfRegions; }
            set { _listOfRegions = value; }
        }
    }
}