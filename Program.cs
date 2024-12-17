
class Pract7
{
    static void Main()
    {
        // Словари для хранения логинов и паролей
        Dictionary<string, string> stLogins = new Dictionary<string, string>
        {
            { "stu1", "pas1" },
            { "stu2", "pas2" }
        };

        Dictionary<string, string> tLogins = new Dictionary<string, string>
        {
            { "prep", "pasP" }
        };

        Dictionary<string, string> aLogins = new Dictionary<string, string>
        {
            { "admin", "pass" }
        };

        // Предварительные данные
        List<Student> stList = new List<Student>
        {
            new Student("Шандро", "Михаил", "Алексеевич", 2000, "Группа 1"),
            new Student("Петров", "Петр", "Петрович", 2001, "Группа 2")
        };

        List<Teacher> tList = new List<Teacher>
        {
            new Teacher("Смирнов", "Алексей", "Алексеевич", 1985, "Математика")
        };

        Journal Journal = new Journal();

        while (true)
        {
            Console.WriteLine("Выберите способ входа: Студент, Преподаватель, Администратор");
            string userRole = Console.ReadLine()?.ToLower();

            if (userRole == "студент")
            {
                if (Authenticate(stLogins))
                {
                    Console.WriteLine("Добро пожаловать, студент!");
                    Console.WriteLine("Ваш журнал:");
                    Journal.DisplayJournal();
                }
            }
            else if (userRole == "преподаватель")
            {
                if (Authenticate(tLogins))
                {
                    Console.WriteLine("Добро пожаловать, преподаватель!");
                    TeacherMenu(Journal);
                }
            }
            else if (userRole == "администратор")
            {
                if (Authenticate(aLogins))
                {
                    Console.WriteLine("Добро пожаловать, администратор!");
                    AdminMenu(stList, tList, Journal);
                }
            }
            else
            {
                Console.WriteLine("Неверная роль. Попробуйте снова.");
            }
        }
    }

    static bool Authenticate(Dictionary<string, string> validLogins)
    {
        Console.Write("Введите логин: ");
        string inLogin = Console.ReadLine();
        Console.Write("Введите пароль: ");
        string inPassword = Console.ReadLine();

        if (validLogins.ContainsKey(inLogin) && validLogins[inLogin] == inPassword)
        {
            return true;
        }

        Console.WriteLine("Неверные логин или пароль.");
        return false;
    }

    static void TeacherMenu(Journal gJournal)
    {
        while (true)
        {
            Console.WriteLine("\nМеню преподавателя:");
            Console.WriteLine("1. Просмотреть журнал");
            Console.WriteLine("2. Добавить оценку");
            Console.WriteLine("3. Изменить оценку");
            Console.WriteLine("4. Удалить оценку");
            Console.WriteLine("5. Выход");

            string teacherChoice = Console.ReadLine();
            switch (teacherChoice)
            {
                case "1":
                    gJournal.DisplayJournal();
                    break;
                case "2":
                    gJournal.AddGrade();
                    break;
                case "3":
                    gJournal.EditGrade();
                    break;
                case "4":
                    gJournal.DeleteGrade();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void AdminMenu(List<Student> studentList, List<Teacher> teacherList, Journal gradeJournal)
    {
        while (true)
        {
            Console.WriteLine("\nМеню администратора:");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Удалить студента");
            Console.WriteLine("3. Добавить преподавателя");
            Console.WriteLine("4. Удалить преподавателя");
            Console.WriteLine("5. Просмотреть журнал");
            Console.WriteLine("6. Выход");
            string adminChoice = Console.ReadLine();
            switch (adminChoice)
            {
                case "1":
                    Console.WriteLine("Введите данные студента: ");
                    studentList.Add(Student.CreateStudent());
                    break;
                case "2":
                    Console.WriteLine("Введите фамилию студента для удаления: ");
                    string studentLastName = Console.ReadLine();
                    studentList.RemoveAll(student => student.LastName == studentLastName);
                    Console.WriteLine("Студент удален.");
                    break;
                case "3":
                    Console.WriteLine("Введите данные преподавателя: ");
                    teacherList.Add(Teacher.CreateTeacher());
                    break;
                case "4":
                    Console.WriteLine("Введите фамилию преподавателя для удаления: ");
                    string teacherLastName = Console.ReadLine();
                    teacherList.RemoveAll(teacher => teacher.LastName == teacherLastName);
                    Console.WriteLine("Преподаватель удален.");
                    break;
                case "5":
                    gradeJournal.DisplayJournal();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}

// Класс для студентов
class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public int YearOfBirth { get; set; }
    public string Group { get; set; }

    public Student(string lastName, string firstName, string middleName, int yearOfBirth, string group)
    {
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        YearOfBirth = yearOfBirth;
        Group = group;
    }

    public static Student CreateStudent()
    {
        Console.Write("Фамилия: ");
        string last = Console.ReadLine();
        Console.Write("Имя: ");
        string first = Console.ReadLine();
        Console.Write("Отчество: ");
        string middle = Console.ReadLine();
        Console.Write("Год рождения: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Группа: ");
        string group = Console.ReadLine();

        return new Student(last, first, middle, year, group);
    }
}

// Класс для преподавателей
class Teacher
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public int YearOfBirth { get; set; }
    public string Discipline { get; set; }

    public Teacher(string lastName, string firstName, string middleName, int yearOfBirth, string discipline)
    {
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        YearOfBirth = yearOfBirth;
        Discipline = discipline;
    }

    public static Teacher CreateTeacher()
    {
        Console.Write("Фамилия: ");
        string last = Console.ReadLine();
        Console.Write("Имя: ");
        string first = Console.ReadLine();
        Console.Write("Отчество: ");
        string middle = Console.ReadLine();
        Console.Write("Год рождения: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Дисциплина: ");
        string discipline = Console.ReadLine();

        return new Teacher(last, first, middle, year, discipline);
    }
}

// Класс для работы с журналом
class Journal
{
    private Dictionary<string, int> gradeRecords = new Dictionary<string, int>();

    public void DisplayJournal()
    {
        if (gradeRecords.Count == 0)
        {
            Console.WriteLine("Журнал пуст.");
            return;
        }


foreach (var record in gradeRecords)
        {
            Console.WriteLine($"{record.Key}: {record.Value}");
        }
    }

    public void AddGrade()
    {
        Console.Write("Введите предмет: ");
        string subject = Console.ReadLine();
        Console.Write("Введите оценку (1-5): ");
        int grade = int.Parse(Console.ReadLine());
        gradeRecords[subject] = grade;
        Console.WriteLine("Оценка добавлена.");
    }

    public void EditGrade()
    {
        Console.Write("Введите предмет для изменения оценки: ");
        string subject = Console.ReadLine();

        if (gradeRecords.ContainsKey(subject))
        {
            Console.Write("Введите новую оценку (1-5): ");
            int grade = int.Parse(Console.ReadLine());
            gradeRecords[subject] = grade;
            Console.WriteLine("Оценка изменена.");
        }
        else
        {
            Console.WriteLine("Такого предмета нет в журнале.");
        }
    }

    public void DeleteGrade()
    {
        Console.Write("Введите предмет для удаления: ");
        string subject = Console.ReadLine();

        if (gradeRecords.Remove(subject))
        {
            Console.WriteLine("Оценка удалена.");
        }
        else
        {
            Console.WriteLine("Такого предмета нет в журнале.");
        }
    }
}
