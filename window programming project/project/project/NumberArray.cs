using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    [Serializable]
    class NumberArray
    {
        private Number[] number = new Number[100];    // Number클래스 100개짜리 배열
        private int count = 0;   // 카운트 0

        public Number this[int index]
        {
            get
            {
                return number[index];
            }
            set
            {
                number[index] = value;
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
    }
}
