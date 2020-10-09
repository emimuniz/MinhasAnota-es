string[] names = { "Adam", "Barry", "Charlie" };

//duas formas de percorrer um array
Console.WriteLine();
foreach (string name in names)
{
    Console.WriteLine($"{name} has {name.Length} characters.");
}

IEnumerator e = names.GetEnumerator();

while (e.MoveNext())
{
    string name = (string)e.Current; // Current is read-only!
    Console.WriteLine($"{name} has {name.Length} characters.");
}
