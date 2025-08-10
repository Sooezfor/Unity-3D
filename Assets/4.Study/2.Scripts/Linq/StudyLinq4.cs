using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class StudyLinq4 : MonoBehaviour
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

        grades.Add(new Grade(1, 90, "Math"));
        grades.Add(new Grade(2, 85, "Science"));
        grades.Add(new Grade(3, 92, "English"));
        grades.Add(new Grade(4, 76, "Math"));
        #endregion

        InnerJoin();
    }

    void InnerJoin() //내부 조인
    {
        var innerJoin = from s in students
                        join g in grades on s.studentID equals g.studentID
                        select new
                        {
                            StudentID = s.studentID,
                            StudentName = s.studentName,
                            Subject = g.subject,
                            Score = g.score
                        }; //새로운 가상의 무엇인가을 만드는 것.
                           //이 값들이 innerJoin 에게 열거형으로 들어간다

        foreach (var p in innerJoin)
        {
            Debug.Log($"ID : {p.StudentID} / Name : {p.StudentName}/ Subject : {p.Subject} / Score : {p.Score}");
        }
    }
}
