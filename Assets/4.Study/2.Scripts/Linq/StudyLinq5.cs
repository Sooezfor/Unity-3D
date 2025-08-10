using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StudyLinq5 : MonoBehaviour
{
    #region Data Class
    [System.Serializable]
    public class Student
    {
        public int studentID;
        public string studentName;

        public Student(int studentID, string studentName)
        {
            this.studentID = studentID;
            this.studentName = studentName;
        }
    }

    [System.Serializable]
    public class Grade
    {
        public int studentID;
        public int score;
        public string subject;

        public Grade(int studentID, int score, string subject)
        {
            this.studentID = studentID;
            this.score = score;
            this.subject = subject;
        }
    }
    #endregion

    public List<Student> students = new List<Student>();
    public List<Grade> grades = new List<Grade>();

    private void Start()
    {
        #region Add Data
        students.Add(new Student(1, "Alice"));
        students.Add(new Student(2, "Bob"));
        students.Add(new Student(3, "Charlie"));
        students.Add(new Student(4, "Eve"));
        students.Add(new Student(5, "Frank"));

        grades.Add(new Grade(1, 90, "Math"));
        grades.Add(new Grade(2, 85, "Science"));
        grades.Add(new Grade(3, 92, "English"));
        grades.Add(new Grade(4, 76, "Math"));
        grades.Add(new Grade(6, 90, "History"));
        #endregion

        OuterJoin();
    }

    void OuterJoin()
    {
        var leftouterJoin = from s in students
                            join g in grades on s.studentID equals g.studentID into sGrades
                            from g in sGrades.DefaultIfEmpty() //s
                            select new
                            {
                                StudentID = s.studentID,
                                StudentName = s.studentName,
                                Subject = g?.subject, //빠진 데이터 있는지 없는지
                                Score = g?.score ?? 0 //int 값은 만약 null 이라면 0 적겠다고 함. null 대신 0 적어라
                            };
        var rightOuterjoin = from g in grades
                             join s in students on g.studentID equals s.studentID into gStudents
                             from s in gStudents.DefaultIfEmpty()
                             where s == null //널인 대상들 찾아서 아래 기능 추가
                             select new
                             {
                                 StudentID = g.studentID,
                                 StudentName = "N/A",
                                 Subject = g.subject,
                                 Score = g.score
                             };
        var outerJoin = leftouterJoin.Union(rightOuterjoin); //유니온은 합집합

        foreach(var p in outerJoin)
        {
            Debug.Log($"ID : {p.StudentID} / Name : {p.StudentName}/ Subject : {p.Subject} / Score : {p.Score}");
        }

    }

}
