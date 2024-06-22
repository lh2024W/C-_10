using System.Collections;
using System.Threading;
namespace C__10
{

    class Student : IComparable
    {
        public string firstname;//имя
        public string secondname;//отчество
        public string lastname;//фамилия
        public string birthday;//дата рождения
        public string address;//домашний адрес
        public string phone;//телефон
        List<int> Tests;//зачеты
        List<int> TermPapers;//курсовые работы
        List<int> Exams;//экзамены

        public Student() : this(10, 11, 11)
        {
            //Console.WriteLine("C-tor without params");
        }

        public Student(int test, int term, int exam) : this("Иван", "Иванович", "Иванов", "12.01.2003",
            "г.Одесса ул.Пушкинская 10", "069635422", 12, 12, 12)
        {
            Tests = new List<int>();
            SetTests(test);
            TermPapers = new List<int>();
            SetTermPapers(term);
            Exams = new List<int>();
            SetExams(exam);

            //Console.WriteLine("C-tor with params");
        }

        public Student(string firstname, string secondname, string lastname, string birthday, string address, string phone,
            int test, int term, int exam)//main c-tor
        {
            SetFirstname(firstname);
            SetSecondname(secondname);
            SetLastname(lastname);
            SetBirthday(birthday);
            SetAddress(address);
            SetPhone(phone);
            Tests = new List<int>();
            SetTests(test);
            TermPapers = new List<int>();
            SetTermPapers(term);
            Exams = new List<int>();
            SetExams(exam);

            //Console.WriteLine("Main c-tor");
        }

        public void SetFirstname(string firstname)
        {
            this.firstname = firstname;
        }

        public void SetSecondname(string secondname)
        {
            this.secondname = secondname;
        }

        public void SetLastname(string lastname)
        {
            this.lastname = lastname;
        }

        public void SetBirthday(string birthday)
        {
            this.birthday = birthday;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public void SetPhone(string phone)
        {
            this.phone = phone;
        }

        public void SetTests(int test)
        {
            Tests.Add(test);
        }

        public void SetTermPapers(int term)
        {
            TermPapers.Add(term);
        }

        public void SetExams(int exam)
        {
            Exams.Add(exam);
        }

        public string GetFirstname()
        {
            return firstname != null ? firstname : "Не задано";
        }

        public string GetSecondname()
        {
            return secondname != null ? secondname : "Не задано";
        }

        public string GetLastname()
        {
            return lastname != null ? lastname : "Не задано";
        }

        public string GetBirthday()
        {
            return birthday != null ? birthday : "Не задано";
        }

        public string GetAddress()
        {
            return address != null ? address : "Не задано";
        }

        public string GetPhone()
        {
            return phone != null ? phone : "Не задано";
        }

        public List<int> GetTests()
        {
            return Tests;
        }

        public List<int> GetTermPapers()
        {
            return TermPapers;
        }

        public List<int> GetExams()
        {
            return Exams;
        }

        public void GetInfo()
        {
            Console.WriteLine("Имя: " + GetFirstname());
            Console.WriteLine("Отчество: " + GetSecondname());
            Console.WriteLine("Фамилия: " + GetLastname());
            Console.WriteLine("Дата рождения: " + GetBirthday());
            Console.WriteLine("Адрес проживания: " + GetAddress());
            Console.WriteLine("Телефон: " + GetPhone());
            foreach (int test in Tests)
            {
                Console.WriteLine("Оценки за зачеты: " + test);
            }
            foreach (int term in TermPapers)
            {
                Console.WriteLine("Оценки за зачеты: " + term);
            }
            foreach (int exam in Exams)
            {
                Console.WriteLine("Оценки за зачеты: " + exam);
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            return firstname + " " + secondname + " " + lastname + " " + birthday + " " + address + " " + phone + " " +
                Tests + " " + TermPapers + " " + Exams + " ";
        }

        public void Study()
        {
            Console.WriteLine("Студент: " + firstname + " " + secondname + " " + lastname);
            Console.WriteLine("Учится!");
            Console.WriteLine("Его оценки: ");
            foreach (int test in Tests)
            {
                Console.WriteLine("Оценки за зачеты: " + test);
            }
            foreach (int term in TermPapers)
            {
                Console.WriteLine("Оценки за зачеты: " + term);
            }
            foreach (int exam in Exams)
            {
                Console.WriteLine("Оценки за зачеты: " + exam);
            }
        }

        public void TakeExam()
        {
            Console.WriteLine("Студент: " + firstname + " " + secondname + " " + lastname);
            Console.WriteLine("Сдал экзамен!");
            Console.WriteLine("Его оценка: ");
            foreach (int exam in Exams)
            {
                Console.WriteLine("Оценки за зачеты: " + exam);
            }
            Console.WriteLine();
        }

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                return firstname.CompareTo((obj as Student).firstname);
            }
            throw new NotImplementedException();
        }

        public class SortByName : IComparer
        {
            public int Compare(object ob1, object ob2)
            {
                Student s1 = (Student)ob1;
                Student s2 = (Student)ob2;
                return String.Compare(s1.firstname, s2.firstname);
            }
        }

        public class SortByLastname : IComparer
        {
            public int Compare(object ob1, object ob2)
            {
                Student s1 = (Student)ob1;
                Student s2 = (Student)ob2;
                return String.Compare(s1.lastname, s2.lastname);
            }
        }

        public class SortByLengthAddress : IComparer
        {
            public int Compare(object ob1, object ob2)
            {
                Student s1 = (Student)ob1;
                Student s2 = (Student)ob2;
                if (s1.address.Length < s2.address.Length) return 1;
                else return 0;
            }
        }

        public int SearchByName(object obj, string name)// не могу проверить, не знаю что не так... 
        {
            if (obj is Student)
            {
                return name.CompareTo((obj as Student).firstname);
            }
            throw new NotImplementedException();
            
        }
    }

        class Program
        {
            static void Main(string[] args)
            {
                Student [] students = new Student[5];
                students[0] = new Student("Тарас", "Григорьевич", "Шевченко", "24.03.2001", "г.Киев", "0502658985", 12, 12, 12);
                students[1] = new Student("Александр", "Витальевич", "Савицкий", "21.11.1988", "г.Запорожье", "67559440026", 12, 11, 12);
                students[2] = new Student("Ольга", "Юрьевна", "Корсар", "04.12.1984", "г.Киев", "09548565652", 11, 12, 12);
                students[3] = new Student("Вадим", "Олегович", "Шустрый", "31.12.2010", "г.Одесса", "04852115253", 10, 12, 9);
                students[4] = new Student("Анна", "Владимировна", "Борисенко", "03.08.1999", "г.Львов", "2659947436", 11, 11, 11);
                
                Array.Sort(students);

                foreach (Student student in students)
                {
                    Console.WriteLine(student);//не показывает оценки
                }
                Console.WriteLine();

                Array.Sort(students, new Student.SortByName());
                foreach (Student student in students)
                {
                    Console.WriteLine(student);//не показывает оценки
                }
                Console.WriteLine();

                Array.Sort(students, new Student.SortByLengthAddress());
                foreach (Student student in students)
                {
                    Console.WriteLine(student);//не показывает оценки
                }
                Console.WriteLine();

            
            }
        }
    
}
