<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormProcessor.aspx.cs" Inherits="Project1.FormProcessor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="background-color:azure">
    <asp:Label ID="lblName" runat="server" Text="" ></asp:Label>
    <asp:Label ID="lblStudentID" runat="server" Text="" ></asp:Label>
    <asp:Label ID="lblCourse" runat="server" Text="" ></asp:Label><br />

    <asp:Label ID="lblQuestion1" runat="server" Text="The Teacher is well prepared for class:" ></asp:Label>
    <asp:Label ID="lblAnswer1" runat="server" Text="" ></asp:Label>
    <hr />

    <asp:Label ID="lblQuestion2" runat="server" Text="The Teacher demonstrates knowledge of the course subject:" ></asp:Label>
    <asp:Label ID="lblAnswer2" runat="server" Text="" ></asp:Label>
    <hr />

    <asp:Label ID="lblQuestion3" runat="server" Text="The Teacher is clear in giving directions and explains what to do expected:" ></asp:Label>
    <asp:Label ID="lblAnswer3" runat="server" Text="" ></asp:Label>
    <hr />

    <asp:Label ID="lblQuestion4" runat="server" Text="The Teacher's grading policy is fair:" ></asp:Label>
    <asp:Label ID="lblAnswer4" runat="server" Text="" ></asp:Label>
    <hr />

    <asp:Label ID="lblQuestion5" runat="server" Text="The Teacher encourages students to speak:" ></asp:Label>
    <asp:Label ID="lblAnswer5" runat="server" Text="" ></asp:Label>
    <hr />

    <asp:Label ID="lblQuestion6" runat="server" Text="The Teacher manages the time well:" ></asp:Label>
    <asp:Label ID="lblAnswer6" runat="server" Text="" ></asp:Label>
    <hr />

    <asp:Label ID="lblQuestion7" runat="server" Text="The Course content met your needs as a student:" ></asp:Label>
    <asp:Label ID="lblAnswer7" runat="server" Text="" ></asp:Label>
    <hr />

    <asp:Label ID="lblQuestion8" runat="server" Text="The pace at which the course is taught was too fast:" ></asp:Label>
    <asp:Label ID="lblAnswer8" runat="server" Text="" ></asp:Label>
    <hr />

    <asp:Label ID="lblQuestion9" runat="server" Text="The course material and reading were helpful:" ></asp:Label>
    <asp:Label ID="lblAnswer9" runat="server" Text="" ></asp:Label>
    <hr />

    <asp:Label ID="lblQuestion10" runat="server" Text="The course material was enjoyable:" ></asp:Label>
    <asp:Label ID="lblAnswer10" runat="server" Text="" ></asp:Label>
    <hr />

    <asp:Label ID="lblQuestion11" runat="server" Text="The class incorporated all of the material and provided a clear understanding of the subject:" ></asp:Label>
    <asp:Label ID="lblAnswer11" runat="server" Text="" ></asp:Label>
    <hr />

    <asp:Label ID="lblQuestion12" runat="server" Text="Would you recommend the course to others:" ></asp:Label>
    <asp:Label ID="lblAnswer12" runat="server" Text="" ></asp:Label>
    <hr />

    <asp:Label ID="lblTeacherGrade" runat="server" Text="Letter grade for the teacher resulting from the first 6 questions: " ></asp:Label>
    <asp:Label ID="lblTeacherLetterGrade" runat="server" Text="" ></asp:Label><br />
    <asp:Label ID="lblCourseGrade" runat="server" Text="Letter grade for the course resulting from the last 6 questions: " ></asp:Label>
    <asp:Label ID="lblCourseLetterGrade" runat="server" Text="" ></asp:Label>

</body>
</html>

