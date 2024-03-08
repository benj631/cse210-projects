using System;
using System.Collections.Generic;

public class Assignment {
    public string studentName = "";
    public string studyTopic = "";
    
    public Assignment(string studentName, string studyTopic) {
        this.studentName = studentName;
        this.studyTopic = studyTopic;
    }

    public virtual string ReturnSummary() {
        return $"Student Name: {this.studentName}, Topic: {this.studyTopic}";
    }
}