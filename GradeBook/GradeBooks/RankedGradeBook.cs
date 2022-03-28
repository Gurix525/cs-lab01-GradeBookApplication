using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            double fifthOfStudents = Students.Count / 5;
            double studentsWithHigherAverage = 0;

            foreach (Student student in Students)
            {
                if (student.AverageGrade > averageGrade) studentsWithHigherAverage++;
            }

            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            else if (studentsWithHigherAverage >= 4 * fifthOfStudents)
                return 'F';
            else if (studentsWithHigherAverage >= 3 * fifthOfStudents)
                return 'D';
            else if (studentsWithHigherAverage >= 2 * fifthOfStudents)
                return 'C';
            else if (studentsWithHigherAverage >= 1 * fifthOfStudents)
                return 'B';
            return 'A';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5) Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5) Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStudentStatistics(name);
        }
    }
}
