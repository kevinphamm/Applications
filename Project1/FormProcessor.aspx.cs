using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class FormProcessor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Retreiving the values from the form that was sent and assigning it to a variable
            String name = "Name of student: " + Request["txtName"] + "<br />";
            String studentID = "Student ID: " + Request["txtStudentID"] + "<br />";
            String course = "Course number: " + Request["ddlCourse"] + "<br />";

            //Retreiving the answers for the teacher from the form and assigning it
            String answer1 = Request["optPrep"];
            String answer2 = Request["optKnow"];
            String answer3 = Request["optExpect"];
            String answer4 = Request["optGrading"];
            String answer5 = Request["optQuestion"];
            String answer6 = Request["optTime"];

            //Retreiving the answers for the course from the form and assigning it
            String answer7 = Request["optContent"];
            String answer8 = Request["optPace"];
            String answer9 = Request["optMaterial"];
            String answer10 = Request["optEnjoy"];
            String answer11 = Request["optUnderstand"];
            String answer12 = Request["optRecommend"];

            double grade1 = getGrade(answer1);
            double grade2 = getGrade(answer2);
            double grade3 = getGrade(answer3);
            double grade4 = getGrade(answer4);
            double grade5 = getGrade(answer5);
            double grade6 = getGrade(answer6);

            //Calculates Teacher Grade
            String teacherLetterGrade = CalculateGrade(grade1, grade2, grade3, grade4, grade5, grade6);

            double grade7 = getGrade(answer7);
            double grade8 = getGrade(answer8);
            double grade9 = getGrade(answer9);
            double grade10 = getGrade(answer10);
            double grade11 = getGrade(answer11);
            double grade12 = getGrade(answer12);

            //Calculate Course Grade
            String courseLetterGrade = CalculateGrade(grade7, grade8, grade9, grade10, grade11, grade12);


            //Updating labels with the student's information
            lblName.Text = name;
            lblStudentID.Text = studentID;
            lblCourse.Text = course;

            //Updating labels with the answers to the teacher questions
            lblAnswer1.Text = answer1;
            lblAnswer2.Text = answer2;
            lblAnswer3.Text = answer3;
            lblAnswer4.Text = answer4;
            lblAnswer5.Text = answer5;
            lblAnswer6.Text = answer6;

            //Updating labels with the answers to the course questions
            lblAnswer7.Text = answer7;
            lblAnswer8.Text = answer8;
            lblAnswer9.Text = answer9;
            lblAnswer10.Text = answer10;
            lblAnswer11.Text = answer11;
            lblAnswer12.Text = answer12;

            //Updating labels with the calculated grades depending on the answers from the 6 teacher questions and the 6 course questions
            lblTeacherLetterGrade.Text = teacherLetterGrade;
            lblCourseLetterGrade.Text = courseLetterGrade;
        }

        protected double getGrade(String answer)
        {
            if (answer.Equals("Strongly Agree"))
            {
                return 5;
            }
            else if (answer.Equals("Agree"))
            {
                return 4;
            }
            else if (answer.Equals("Neutral"))
            {
                return 3;
            }
            else if (answer.Equals("Disagree"))
            {
                return 2;
            }
            else if (answer.Equals("Strongly Disagree"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        protected string CalculateGrade(double grade1, double grade2, double grade3, double grade4, double grade5, double grade6)
        {
            double totalTeacherGrade = grade1 + grade2 + grade3 + grade4 + grade5 + grade6;
            totalTeacherGrade = totalTeacherGrade / 30;
            if (totalTeacherGrade >= 0.9)
            {
                return "A";
            }
            else if (totalTeacherGrade >= 0.8)
            {
                return "B";
            }
            else if (totalTeacherGrade >= 0.7)
            {
                return "C";
            }
            else if (totalTeacherGrade >= 0.6)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }
    }
}