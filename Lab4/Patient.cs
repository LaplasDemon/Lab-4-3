using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Patient
    {
        private int cardNum;
        private string firstName;
        private string secondName;
        private string fatherName;
        private string birthYear;
        private string sex;

        public int CardNum
        {
            get
            {
                return cardNum;   
            }
            set
            {
                cardNum = value;
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }
        public string FatherName
        {
            get { return fatherName; }
            set { fatherName = value; }
        }
        public string BirthYear
        {
            get { return birthYear; }
            set { birthYear = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public Patient()
        {
            this.cardNum = 1;
            this.firstName = "";
            this.secondName = "";
            this.fatherName = "";
            this.birthYear = "";
            this.sex = "";
        }
        public Patient(int cardN, string frsName, string secName, string fathName, string year, string sex)
        {
            this.cardNum = cardN;
            this.firstName = frsName;
            this.secondName = secName;
            this.fatherName = fathName;
            this.birthYear = year;
            this.sex = sex;
        }
    }
}
