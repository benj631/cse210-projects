using System;

public class Rectangle : Shape{
    private double side1 = 1;
    private double side2 = 1;

    public Rectangle(string color, double side1, double side2) : base(color){
        this.side1 = side1;
        this.side2 = side2;
    }

    public override double GetArea(){
        return this.side1 * this.side2;
    }

}