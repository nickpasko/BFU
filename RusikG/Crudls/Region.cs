using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Hunters
{class Region
    {
        internal struct StatisticData
        {
            private Data _data;
            private double _numberOfCrudleInStart;
            private double _numberOfKilledHunters;
            private double _numberOfKilledCrudle;

            public Data Data
            {
                get { return _data; }
                set { _data = value; }
            }

            public double NumberOfCrudleInStart
            {
                get { return _numberOfCrudleInStart; }
                set { _numberOfCrudleInStart = value; }
            }

            public double NumberOfKilledHunters
            {
                get { return _numberOfKilledHunters; }
                set { _numberOfKilledHunters = value; }
            }

            public double NumberOfKilledCrudle
            {
                get { return _numberOfKilledCrudle; }
                set { _numberOfKilledCrudle = value; }
            }
        }

        
        private string _nameOfRegion;
        private int _minNumberOfCrudle;
        private int _maxNumberOfCrudle;
        private int _currentNumberOfCrudle;
        private List<StatisticData> _statistic;

        public string NameOfRegion
        {
            get { return _nameOfRegion; }
            set { _nameOfRegion = value; }
        }

        public int MinNumberOfCrudle
        {
            get { return _minNumberOfCrudle; }
            set { _minNumberOfCrudle = value; }
        }

        public int MaxNumberOfCrudle
        {
            get { return _maxNumberOfCrudle; }
            set { _maxNumberOfCrudle = value; }
        }

        public int CurrentNumberOfCrudle
        {
            get { return _currentNumberOfCrudle; }
            set { _currentNumberOfCrudle = value; }
        }

        public List<Region.StatisticData> Statistic
        {
            get { return _statistic; }
            set { _statistic = value; }
        }
    }
}