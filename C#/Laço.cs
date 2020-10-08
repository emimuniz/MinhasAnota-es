
  Console.WriteLine();

  int max = int.MaxValue;
  int min = int.MinValue;
  Console.WriteLine($"The range of integers is {min} to {max}");

  Console.WriteLine();


  for (int row = 1; row < 2; row++)
  {
      for (char column = 'a'; column < 'k'; column++)
      {
          Console.WriteLine($"The cell is ({row}, {column})");
      }
  }
