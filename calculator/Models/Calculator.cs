using System.Globalization;
using calculator.Models.Interfaces;

namespace calculator.Models;

public class CalculateFromText : ICalculator
{
    public string[] Text { get; set; }

    public CalculateFromText(string[] text)
    {
        Text = text;    
    }

    private double SetLastRow()
    {
        string[] lastLine = Text[Text.Length - 1].Split(' ');

        if (lastLine[0] == "apply")
        {
            double result;
            try
            {
                result = double.Parse(lastLine[1]);
            }
            catch (System.FormatException)
            {
                try
                {
                    result = double.Parse(lastLine[1], CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    throw new Exception("Wrong format of last line!");
                }
            }
            Text = Text.SkipLast(1).ToArray();

            return result;
        }
        else
            throw new Exception("Wrong last command!");
    }

    public double Calculate()
    {
        var result = SetLastRow();

        foreach (string line in Text)
        {
            string[] words = line.Split(' ');
            string command = words[0];
            double number = double.Parse(words[1]);

            switch (command)
            {
                case "add":
                    result += number;
                    break;
                case "subtract":
                    result -= number;
                    break;
                case "multiply":
                    result *= number;
                    break;
                case "divide":
                    result /= number;
                    break;
                default:
                    throw new Exception("Wrong command!");
                    break;
            }
        }
        return result;
    }
}
