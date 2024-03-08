using System;

class MathAssignment : Assignment {

    string textbookSection = "";
    string problems = "";

    public MathAssignment(string studentName, string studyTopic, string textbookSection, string problems ) : base(studentName, studyTopic) {
        this.textbookSection = textbookSection;
        this.problems = problems;
    }

    public override string ReturnSummary(){
        return $"Student Name: {this.studentName}, Topic: {this.studyTopic}, Textbook Section: {this.textbookSection}, Problems: {this.problems}";
    }
}