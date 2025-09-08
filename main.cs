using System;
class Program


{
    static void Main()
    {
        string input = "pA pppapppa pdpo pPpapppa";
        string output = "";
        int i = 0;

        while (i < input.Length)
        {
            if (input[i] == 'p' && i + 1 < input.Length && char.IsLetter(input[i + 1]))
            {
                output += input[i + 1];
                i += 2;
            }
            else
            {
                output += input[i];
                i++;
            }
        }

        Console.WriteLine(output);
    }
}
