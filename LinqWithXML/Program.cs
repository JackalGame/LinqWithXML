using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqWithXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentsXML =
                @"<Students>
                    <Student>
                        <Name>Toni</Name>
                        <Age>21</Age>
                        <University>Yale</University>
                        <GradeAv>5.4</GradeAv>
                    </Student>
                    <Student>
                        <Name>James</Name>
                        <Age>18</Age>
                        <University>Yale</University>
                        <GradeAv>3.2</GradeAv>
                    </Student>
                    <Student>
                        <Name>Fiona</Name>
                        <Age>28</Age>
                        <University>Leeds</University>
                        <GradeAv>4.1</GradeAv>
                    </Student>
                    <Student>
                        <Name>Jack</Name>
                        <Age>29</Age>
                        <University>Liverpool</University>
                        <GradeAv>7.2</GradeAv>
                    </Student>
                </Students>";

            XDocument studentsXDoc = new XDocument();
            studentsXDoc = XDocument.Parse(studentsXML);

            var students = from student in studentsXDoc.Descendants("Student")
                           select new
                           {
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               University = student.Element("University").Value,
                               GradeAv = student.Element("GradeAv").Value
                           };

            foreach(var student in students)
            {
                Console.WriteLine($"Student {student.Name} with age of {student.Age} from University {student.University} with a current grade average of {student.GradeAv}");
            }

            var studentsByAge = from student in students orderby student.Age select student;

            foreach(var student in studentsByAge)
            {
                Console.WriteLine($"Student {student.Name} is {student.Age} years old");
            }

            Console.Read();
        }
    }
}
