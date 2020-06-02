using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class PatientManager
    {
        private List<Patient> patients;
        private ReaderWriter readerWriter;
        public PatientManager()
        {           
            readerWriter = new ReaderWriter();
            patients = parsePatientsFromFile();
        }
        public void setComands()
        {
            Console.WriteLine("Доступні команди: додавання(add), видалення(delete), редагування(edit), виведення списку пацієнтів(show), пошук(find), сортування(sort)");
            Console.WriteLine("Для завершення роботи введіть: exit");

            switch (Console.ReadLine())
            {
                case "add":
                    Console.WriteLine();
                    addNewPatient();
                    break;

                case "edit":
                    Console.WriteLine();
                    editPatient();
                    setComands();
                    break;

                case "delete":
                    Console.WriteLine();
                    deletePatient();
                    setComands();
                    break;

                case "show":
                    Console.WriteLine();
                    showPatientList();
                    setComands();
                    break;

                case "find":
                    Console.WriteLine();
                    findPatient();
                    break;

                case "sort":
                    Console.WriteLine();
                    sortPatients();
                    break;

                case "exit":
                    return;
            }
        }     
        public Patient parsePatientInfo(string strInfo)
        {
            string[] words = new string[6];
            words = strInfo.Split(',');
            Patient patient = new Patient(int.Parse(words[0]), words[1], words[2], words[3], words[4], words[5]);
            return patient;
        }
        public List<Patient> parsePatientsFromFile()
        {
            List<Patient> patients = new List<Patient>();
            List<string> strs = readerWriter.readDataFromFile();
            int strCount = 0;
            foreach (string s in strs)
            {
                patients.Add(parsePatientInfo(s));
                strCount++;
            }
            return patients;
        }
        public void showPatientList()
        {
            Console.WriteLine("{0, -10} {1, -14} {2, -14} {3, -14} {4, -17} {5}", "№ карти", "Прізвище", "Імя", "Побатькові", "Рік народження", "Стать");
            foreach (var p in patients)
                Console.WriteLine("{0, -10} {1, -14} {2, -14} {3, -14} {4, -17} {5}", p.CardNum, p.FirstName, p.SecondName, p.FatherName, p.BirthYear, p.Sex);
        }

        public void addNewPatient()
        {
            Console.WriteLine("Введiть данi пацієнта через кому(№ карти, Прізвище, Імя, Побатькові, Рік народження, Стать)");
            string strInfo = Console.ReadLine();
            Patient newPatient = parsePatientInfo(strInfo);
            patients.Add(newPatient);
            readerWriter.savePatientList(patients);
            setComands();
        }

        public void showPatientInfo(Patient p)
        {
            Console.WriteLine("Номер карти: " + p.CardNum);
            Console.WriteLine("Прізвище: " + p.FirstName);
            Console.WriteLine("Імя: " + p.SecondName);
            Console.WriteLine("Побатькові " + p.FatherName);
            Console.WriteLine("Рік народження: " + p.BirthYear);
            Console.WriteLine("Стать: " + p.Sex);
        }
        public void deletePatient()
        {
            Console.WriteLine("Номер карти: ");
            int cardNum = int.Parse(Console.ReadLine());
            foreach (var p in patients)
            {
                if (p.CardNum == cardNum)
                {
                    showPatientInfo(p);
                    Console.WriteLine("Видалити? (Y/N)");
                    var key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Y)
                    {
                        patients.Remove(p);
                        Console.WriteLine("Видалено успішно!");
                        break;
                    }
                }
            }
            readerWriter.savePatientList(patients);
        }
        public void editPatient()
        {
            Console.WriteLine("Номер карти: ");
            int cardNum = int.Parse(Console.ReadLine());
            foreach (var p in patients)
            {
                if (p.CardNum == cardNum)
                {
                    showPatientInfo(p);
                    Console.WriteLine("Введіть нову інформацію через кому(№ карти, Прізвище, Імя, Побатькові, Рік народження, Стать)");
                    string strInfo = Console.ReadLine();
                    Patient editPatient = parsePatientInfo(strInfo);
                    showPatientInfo(editPatient);
                    Console.WriteLine("Зберегти зміни(Y/N)");
                    var key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Y)
                    {
                        patients.Remove(p);
                        patients.Add(editPatient);
                        break;
                    }
                }
            }
            readerWriter.savePatientList(patients);
        }
        public void findPatient()
        {
            Console.WriteLine("Стать(жінка,чоловік): ");
            string sex = Console.ReadLine();
            Console.WriteLine("Пацієнти:");
            foreach (var p in patients)
            {
                if (p.Sex == sex)
                    showPatientInfo(p);
            }
        }

        public Patient getPatientByFirstName(string fName)
        {
            Patient patient = new Patient();
            foreach (var p in patients)
                if (fName == p.FirstName)
                    patient = p;
            return patient;   
        }
        public void sortPatients()
        {
            List<string> firstNamesList = new List<string>();
            
            foreach (var p in patients)
            {
                firstNamesList.Add(p.FirstName);
            }
            string[] arr = firstNamesList.ToArray();
            Array.Sort(arr);
            Console.WriteLine("{0, -10} {1, -14} {2, -14} {3, -14} {4, -17} {5}", "№ карти", "Прізвище", "Імя", "Побатькові", "Рік народження", "Стать");
            for (int i = 0; i < arr.Count(); i++)
            {
                Patient p = getPatientByFirstName(arr[i]);
                Console.WriteLine("{0, -10} {1, -14} {2, -14} {3, -14} {4, -17} {5}", p.CardNum, p.FirstName, p.SecondName, p.FatherName, p.BirthYear, p.Sex);
            }
            setComands();
        }
    }
}
