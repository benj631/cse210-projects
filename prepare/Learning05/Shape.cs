using System;

public abstract class Shape{

    private string color = "";

    public Shape(string color){
        this.color = color;
    }

    public virtual double GetArea(){
        return 0;
    }

    public string GetColor(){
        return this.color;
    }
    
    public void SetColor(string color){
        this.color = color;
    }
}