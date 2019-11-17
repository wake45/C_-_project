using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    [Serializable]    // 직렬화
    public class Number
    {
        string name;            // 이름
        string phoneNumber;     // 핸드폰 번호
        string birthday;        // 생일
        string relation;        // 관계
        string email;           // 메일주소
        string address;         // 집주소

        public Number(string name, string phoneNumber, string address, string birthday, string relation, string email)  // Number 클래스의 생성자
        {   
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.birthday = birthday;
            this.relation = relation;
            this.email = email;
            this.address = address;
        }

        public string Name  //name의 프로퍼티
        {    
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string PhoneNumber  //phonenumber의 프로퍼티
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        public string Birthday  //birthday의 프로퍼티
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }

        public string Relation  //relation의 프로퍼티
        {
            get
            {
                return relation;
            }
            set
            {
                relation = value;
            }
        }

        public string Email  //email의 프로퍼티
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Address  //address의 프로퍼티
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
    }
}
