using System.Linq;

namespace Hunters
{
    class Data
    {
        private int _year;
        private int _date;
        private int _month;
        public Data(string s)
        {
            var _data = s.Split('-').Select(X => int.Parse(X)).ToArray();
            this._year = _data[0];
            this._month = _data[1];
            this._date = _data[2];
        }
    }
}