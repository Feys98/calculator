using System.Text;
using calculator.Models;

string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\public\", "test.txt");

var readFromFile = new ReadFromFile(path, Encoding.UTF8);
var calculator = new CalculateFromText(readFromFile.ReadAllLinesAsync().Result);

Console.WriteLine("Result: " + calculator.Calculate());