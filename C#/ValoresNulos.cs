//aceitando valores nullos
int? valorNullo = 7;
valorNullo = null;

Console.WriteLine(valorNullo);

//pegando valores nullos
Console.WriteLine(valorNullo.GetValueOrDefault());


string author = null;

//causando NullReferenceException
//int x = author.Length;

//causo o valor seja null 
int? y = author?.Length;

//verificando se o valor é nullo
var result = author?.Length ?? 3;
var verifica = y.GetValueOrDefault() != 0 ? "Não é nullo" : "É NULLO";

Console.WriteLine(result);
Console.WriteLine($"Valor {verifica} ");
Console.WriteLine(y.GetValueOrDefault());
