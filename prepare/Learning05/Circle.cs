using System;

public class Circle : Shape{
    private double diameter = 1;

    public Circle(string color, double diameter) : base(color){
        this.diameter = diameter;
    }

    public override double GetArea(){
        return this.diameter * Math.PI;
    }
    
}