Console.WriteLine("Hello World");

var a = new Num(10);
var b = a;
a.n = 10;
Console.WriteLine(b.n);

class Num {
    public Num(int n)
    {
        this.n = n;
    }
    public int n;
}


