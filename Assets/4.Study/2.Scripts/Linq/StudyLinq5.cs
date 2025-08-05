using UnityEngine;

public class StudyLinq5 : MonoBehaviour
{
    #region Data Class
    [System.Serializable]
    public class Student
    {
        public int studentID;
        public string studentName;

        public Student(int sutdentID, string studentName)
        {
            this.studentID = sutdentID;
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

}
