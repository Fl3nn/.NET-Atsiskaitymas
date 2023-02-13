using studentai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuInformacineSistema
{
    public class Menu
    {
        public void InitiateMenu()
        {
            bool isAlive = true;
            while (isAlive)
            {
                Console.WriteLine("---===MENU===---");
                Console.WriteLine("1. Sukurti departamentą ir į jį pridėti studentus, paskaitas");
                Console.WriteLine("2. Pridėti studenta/paskaitas į jau egzistuojantį departamentą");
                Console.WriteLine("3. Sukurti paskaitą ir ją priskirti prie departamento");
                Console.WriteLine("4. Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam egzistuojančias paskaitas");
                Console.WriteLine("5. Perkelti studentą į kitą departamentą");
                Console.WriteLine("6. Atvaizduoti visus departamento studentus");
                Console.WriteLine("7. Atvaizduoti visas departamento paskaitas");
                Console.WriteLine("8. Atvaizduoti visas paskaitas pagal studentą");
                Console.WriteLine("9. Close program");

                var input = GetSelection();
                switch (input)
                {
                    case 1:
                        ActionService.CreateDepartmentAndAddStudentsAndLectures();
                        break;
                    case 2:
                        ActionService.TransferStudentToDepartment();
                        break;
                    case 3:
                        ActionService.AddLectureToDepartment();
                        break;
                    case 4:
                        ActionService.AddStudentToDepartment();
                        break;
                    case 5:
                        break;
                    case 6:
                        ActionService.PrintStudentsInSelectedDepartment();
                        break;
                    case 7:
                        ActionService.PrintLecturesInSelectedDepartment();
                        break;
                    case 8:
                        ActionService.PrintLecturesByStudent();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public int GetSelection()
        {
            bool isSuccess = Int32.TryParse(Console.ReadLine(), out int result);
            if (isSuccess)
            {
                return result;
            }
            Console.WriteLine("Wrong format");
            return 0;
        }
    }
}
