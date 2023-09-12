using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonFour;

class Calculator
{
    public static int num1, num2, res;

    public static int PerformAction(int num1, int num2, string op)
    {
        int[] arr = new int[25000000]; // <-- 2.5M*4
        switch (op)
        {
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            case "*":
                return num1 * num2;
            case "/":
                return num1 / num2;
            case "%":
                return num1 % num2;
            default:
                return -100500;
        }
    }

    public static double PerformAction(double num1, double num2, string op)
    {
        switch (op)
        {
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            case "*":
                return num1 * num2;
            case "/":
                return num1 / num2;
            default:
                return -100500;
        }
    }
}
