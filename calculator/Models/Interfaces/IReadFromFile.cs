namespace calculator.Models.Interfaces;

public interface IReadFromFile
{
    public Task<string[]> ReadAllLinesAsync();
}