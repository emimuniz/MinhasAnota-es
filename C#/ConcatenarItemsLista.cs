string delimiter = ",";
List<string> items = new List<string>() { "foo", "boo", "john", "doe" };
Console.WriteLine(items.Aggregate((i, j) => i + delimiter + j));


///outra forma
items.Select(i => i.Boo).Aggregate((i, j) => i + delimiter + j)
