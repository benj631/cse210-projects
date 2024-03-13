using System;

public class Square : Shape{
    private double sideLength = 1;

    public Square(string color, double sideLength) : base(color){
        this.sideLength = sideLength;
    }

    public override double GetArea(){
        return Math.Pow(this.sideLength, 2);
    }
}