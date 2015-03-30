using System;
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

        static void Main(string[] args)
        {
            
            _readerOfRegion = new StreamReader(args[0]);
            _readerOfDepartment = new StreamReader(args[1]);
            //_writer = new StreamWriter(args[2]);

            string _regionsString = _readerOfRegion.ReadToEnd();
            string _departmentString = _readerOfDepartment.ReadToEnd();

            string[] _splitedRegions = _regionsString.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None).ToArray();
            string[] _splitedDepartment = _departmentString.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToArray();

            string[] b = _splitedRegions[0].Split(new string[] { "\r\n" }, StringSplitOptions.None).ToArray();

            _dateOfForecasting = new Data(b[0]);


        }
    }
}
