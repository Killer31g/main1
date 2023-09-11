//unsigned int a,b;
uint a, b;

Console.WriteLine("Podaj a:");
a = uint.Parse(Console.ReadLine());

Console.WriteLine("Podaj b:");
b = uint.Parse(Console.ReadLine());

a = NWD(a, b);
Console.WriteLine(a);

uint NWD(uint a, uint b)
{
    while(a != b)
    {
    if (a > b)
    a = a - b;
    else
    b = b - a;    
    }
return a;
};