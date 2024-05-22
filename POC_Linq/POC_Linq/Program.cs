// See https://aka.ms/new-console-template for more information
using POC_Linq;

Console.WriteLine("Hello, World!");

var numbers = new[] { 1, 2, 8, 4, 9, 6, 7, 5, 3, 10 };
var evens = numbers.Where(e => e % 2 == 0);

foreach (var number in evens)
{
    //Console.WriteLine(number);
}

var square = numbers.Select(e => e * e);
foreach (var number in square)
{
    //Console.WriteLine(number);
}

var sorted =  numbers.OrderBy(e => e);
foreach (var number in sorted)
{
    //Console.WriteLine(number);
}

var students = new[] {
    new { Id = 1, Name = "John" },
    new { Id = 2, Name = "Jane" }
};
var scores = new[] {
    new { StudentId = 1, Score = 90 },
    new { StudentId = 2, Score = 80 }
};
var query = from student in students
            join score in scores
            on student.Id equals score.StudentId into StudentScor
            from score in StudentScor.DefaultIfEmpty()
            select new
            {
                student.Name, score.Score
            };
var join = students.Join(
    scores,
    student => student.Id,
    score => score.StudentId,
    (student, score) => new { student.Name, score.Score });

foreach(var  student in query)
{
    Console.WriteLine(student);
}



var employees = new List<Employee>
{
    new Employee { Name = "Alice", Age = 25, Department = "HR" },
    new Employee { Name = "Bob", Age = 35, Department = "IT" },
    new Employee { Name = "Charlie", Age = 40, Department = "Finance" },
    new Employee { Name = "David", Age = 28, Department = "IT" }
};

var emps = employees.Where(e => e.Age > 30).Select(e => e.Name);
//foreach (var employee in emps)
//    Console.WriteLine(employee);

var groupemps = employees.GroupBy(e => e.Department[0]);
foreach (var group in groupemps)
{
    //Console.WriteLine(group.Key);
    //foreach (var employee in group)
    //    Console.WriteLine(employee.Name);
}