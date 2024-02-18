using System;

class Fraction {
    private int numerator;
    private int denominator;

    public Fraction(int top = 0, int bot = 1) {
        this.numerator = top;
        if (bot == 0) {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        this.denominator = bot;
    }

    public void SetTop(int value) {
        this.numerator = value;
    }

    public void SetBottom(int value) {
        if (value == 0) {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        this.denominator = value;
    }

    public int GetTop() {
        return this.numerator;
    }

    public int GetBottom() {
        return this.denominator;
    }

    public string GetFractionString() {
        return $"{this.numerator}/{this.denominator}";
    }

    public double GetDecimalValue() {
        return (double)this.numerator / this.denominator;
    }
}
