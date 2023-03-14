using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR
{
    public static class Student
    {
        public static List<students> inf = new List<students>(); 
    }

    public class students
    {
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string Почта { get; set; }
        public string Телефон { get; set; }
        public int Возраст { get; set; }
        public string Субъект { get; set; }
        public string Учреждение { get; set; }
        public string Специальность { get; set; }
        public int Курс { get; set; }
    }
}
