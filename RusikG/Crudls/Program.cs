using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunters
{
    class Program
    {
        private static StreamReader _readerOfRegion;
        private static StreamReader _readerOfDepartment;
        private static StreamWriter _writer;

        private static Data _dateOfForecasting;
        private static Region _region;
        private static Department _department;

        private static List<Region> _listRegions = new List<Region>();

        static void Main(string[] args)
        {
            _readerOfRegion = new StreamReader(args[0]);
            _readerOfDepartment = new StreamReader(args[1]);
            //_writer = new StreamWriter(args[2]);

            string[] _regionsString = _readerOfRegion.ReadToEnd().Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None).ToArray(); ;
            string[] _departmentString = _readerOfDepartment.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.None).ToArray(); ;

            string[] _firstRegion = _regionsString[0].Split(new string[] { "\r\n" }, StringSplitOptions.None).ToArray();
            _dateOfForecasting = new Data(_firstRegion[0]);
            

            for (int i = 0; i < _regionsString.Length; i++)
            {
                List<string> _tempStrings = _regionsString[i].Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

                if (_tempStrings.Contains(_firstRegion[0]))
                {
                    _tempStrings.Remove(_tempStrings[0]);
                }

                string[] _firstString = _tempStrings[0].Split('\t').ToArray();

                List<Region.StatisticData> _statisticDatas = new List<Region.StatisticData>();

                for (int j = 1; j < _tempStrings.Count; j++)
                {
                    string[] _splitedStatistic = _tempStrings[j].Split('\t').ToArray();

                    _statisticDatas.Add(new Region.StatisticData()
                    {
                        Data = new Data(_splitedStatistic[0]),
                        NumberOfCrudleInStart = double.Parse(_splitedStatistic[1],CultureInfo.InvariantCulture),
                        NumberOfKilledHunters = double.Parse(_splitedStatistic[2],CultureInfo.InvariantCulture),
                        NumberOfKilledCrudle = double.Parse(_splitedStatistic[3],CultureInfo.InvariantCulture)
                    });
                }
                

                _listRegions.Add(new Region()
                {
                    NameOfRegion = _firstString[0],
                    MinNumberOfCrudle = double.Parse(_firstString[1], CultureInfo.InvariantCulture),
                    MaxNumberOfCrudle = double.Parse(_firstString[2], CultureInfo.InvariantCulture),
                    CurrentNumberOfCrudle = double.Parse(_firstString[3], CultureInfo.InvariantCulture),
                    Statistic = _statisticDatas
                });
            }
            
        }
    }
}
