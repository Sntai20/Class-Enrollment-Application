Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()
        [TestInitialize]
        Public void Init()
        {
            // Create the data source (needed to populate the Subjects collection)
            GradesPrototype.Data.DataSource.CreateData();
        }

    [TestMethod]
        Public void TestValidGrade()
    {
        GradesPrototype.Data.Grade grade = New GradesPrototype.Data.Grade(1, "01/01/2012", "Math", "A-", "Very good");
        Assert.AreEqual(grade.AssessmentDate, "01/01/2012");
        Assert.AreEqual(grade.SubjectName, "Math");
        Assert.AreEqual(grade.Assessment, "A-");
    }

    [TestMethod]
    [ExpectedException(TypeOf(ArgumentOutOfRangeException))]
    Public void TestBadDate()
    {
        // Attempt to create a grade with a date in the future
        GradesPrototype.Data.Grade grade = New GradesPrototype.Data.Grade(1, "1/1/2023", "Math", "A-", "Very good");
    }

    [TestMethod]
    [ExpectedException(TypeOf(ArgumentException))]
    Public void TestDateNotRecognized ()
    {
        // Attempt to create a grade with an unrecognized date
        GradesPrototype.Data.Grade grade = New GradesPrototype.Data.Grade(1, "13/13/2012", "Math", "A-", "Very good");
    }

    [TestMethod]
    [ExpectedException(TypeOf(ArgumentOutOfRangeException))]
    Public void TestBadAssessment()
    {
        // Attempt to create a grade with an assessment outside the range A+ to E-
        GradesPrototype.Data.Grade grade = New GradesPrototype.Data.Grade(1, "1/1/2012", "Math", "F-", "Terrible");
    }

    [TestMethod]
    [ExpectedException(TypeOf(ArgumentException))]
    Public void TestBadSubject()
    {
        // Attempt to create a grade with an unrecognized subject
        GradesPrototype.Data.Grade grade = New GradesPrototype.Data.Grade(1, "1/1/2012", "French", "B-", "OK");
    }
    End Sub
End Class