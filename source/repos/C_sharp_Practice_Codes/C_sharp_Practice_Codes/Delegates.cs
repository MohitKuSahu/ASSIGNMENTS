using System;

delegate void calculator(int x, int y);
class Delegates
{

    public static void add(int a, int b)
    {
        Console.Write(a + b);
    }
    public static void mul(int a, int b)
    {
        Console.Write(a * b);
    }
}
