using System;

class WritingAssignment : Assignment {

    public string title = "";

    public WritingAssignment(string studentName, string studyTopic, string title) : base(studentName, studyTopic) {
        this.title = title;
    }

    public override string ReturnSummary(){
        return $"Student Name: {this.studentName}, Topic: {this.studyTopic}, Title: {this.title}";
    }
}