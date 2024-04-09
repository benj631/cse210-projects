using System;
using System.Data.Common;

public abstract class SystemFile{

    private string filePath = "";
    private string fileName = "";
    private double fileSize = 0;
    private DateTime dateCreated = new();
    private DateTime lastModified = new();

    public SystemFile(string filePath){
        this.filePath = filePath;
        this.fileName = Path.GetFileName(filePath);

        FileInfo fileInfo = new FileInfo(filePath);
        // Get the size of the file in bytes
        long fileSizeInBytes = fileInfo.Length;
        // Convert bytes to kilobytes
        double fileSizeInKB = (double)fileSizeInBytes / 1024;
        this.fileSize = fileSizeInKB;

        this.dateCreated = fileInfo.CreationTime;
        this.lastModified = fileInfo.LastWriteTime;

    }

    public virtual void ViewBasicFileInfo(){
        Console.WriteLine($"File path: {this.filePath}");
        Console.WriteLine($"File name: {this.fileName}");
        Console.WriteLine($"File size: {this.fileSize}");
        Console.WriteLine($"Date created: {this.dateCreated}");
        Console.WriteLine($"Last modified: {this.lastModified}");
    }

    public virtual string GetEditOption(){
        return "";
    }

    public virtual void GetMetaData(){
        //Get metadata and store it
    }
    public virtual void ViewMetaData(){
        // Open metadata in default way
    }

    public virtual void ChangeMetaData(string fieldToChange, string userInput) {
        
    }

    public virtual void EditTxt(){}



}