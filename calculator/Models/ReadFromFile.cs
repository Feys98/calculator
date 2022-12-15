using calculator.Models.Interfaces;
using System.Text;

namespace calculator.Models;

public class ReadFromFile : IReadFromFile
{
    private string Path { get; }
    private Encoding Encoding { get; }

    public ReadFromFile(string path, Encoding encoding)
    {
        Path = path;
        Encoding = encoding;
    }

    public async Task<string[]> ReadAllLinesAsync()
    {
        var lines = new List<string>();
          
        try
        {
            await using var stream = new FileStream(Path, FileMode.Open, FileAccess.Read);
            using var reader = new StreamReader(stream, Encoding);

            while (reader.Peek() >= 0)
            {
                var line = await reader.ReadLineAsync();
                if (line != null)
                    lines.Add(line);
            }

            return lines.ToArray();
        }
        catch (Exception)
        {
            throw new Exception("WrongPath!");
        }
    }
}