using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class ReaderWriter
    {
        public List<string> readDataFromFile()
        {
            List<string> lines = new List<string>();
            string line;
            StreamReader file = new StreamReader("patient.txt", Encoding.GetEncoding(1251));
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            file.Close();
            return lines;
        }

        public void savePatient(Patient patient)
        {
            StreamWriter save = new StreamWriter("patient.txt", true, Encoding.GetEncoding(1251));

            save.WriteLine(patient.CardNum.ToString()+","+patient.FirstName + "," + patient.SecondName + "," + patient.FatherName + "," + patient.BirthYear + "," + patient.Sex);
            save.Close();
        }

        public void savePatientList(List<Patient> patients)
        {
            using (StreamWriter save = new StreamWriter("patient.txt", false, Encoding.GetEncoding(1251)))
            {
                string str = null;
                foreach (var p in patients)
                {
                    str = p.CardNum.ToString() + "," + p.FirstName + "," + p.SecondName + "," + p.FatherName + "," + p.BirthYear + "," + p.Sex;
                    save.WriteLine(str);
                }
            }
        }
    
    }
}


    

