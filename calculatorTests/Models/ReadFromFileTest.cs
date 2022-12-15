using System.Text;
using calculator.Models;
namespace calculatorTests.Models;

public class ReadFromFileTest
{
    [Fact]
    public async Task TestIfReadFromFileWithWrongPathReturnsException()
    {
        var path = "C:WRONGPATH!";

        var readFromFile = new ReadFromFile(path, Encoding.UTF8);

        Func<Task> act = async () => await readFromFile.ReadAllLinesAsync();
        await act.Should().ThrowAsync<Exception>().WithMessage("WrongPath!");
    }

    [Fact]
    public async Task TestIfReadFromFileWithCorrectPathReturnsCorrectStringArray()
    {
        string[] expected = new string[] { "apply 1" };
        string[]? result = null;
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\public\", "test.txt");


        var readFromFile = new ReadFromFile(path, Encoding.UTF8);
        Func<Task> act = async () => result = await readFromFile.ReadAllLinesAsync();

        //await act.Should().NotThrowAsync<Exception>();
        result.Should().BeEquivalentTo(expected);
    }
}