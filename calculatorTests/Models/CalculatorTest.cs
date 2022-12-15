using calculator.Models;

namespace calculatorTests.Models;

public class CalculatorTest
{
    [Fact]
    public void TestIfCorrectFormatOfDataInCalculatorReturnsCorrectResult()
    {
        string[] textString = new string[]
        {
            "add 2",
            "multiply 3",
            "apply 0"
        };

        double expected = 6.0;
        
        var calculator = new CalculateFromText(textString);
        var calculatorResult = calculator.Calculate();
        
        calculatorResult.Should().Be(expected);
        calculatorResult.Should().BeOfType(typeof(double));
    }

    [Fact]
    public void TestIfDecimalFormatWithDotOfLastLineInTextArrayReturnsCorrectResult()
    {
        string[] textString = new string[]
        {
            "apply 0.1"
        };
        double expected = 0.1;

        var calculator = new CalculateFromText(textString);
        var calculatorResult = calculator.Calculate();

        calculatorResult.Should().Be(expected);
        calculatorResult.Should().BeOfType(typeof(double));
    }

    [Fact]
    public void TestIfDecimalFormatWithCommaOfLastLineInTextArrayReturnsCorrectResult()
    {
        string[] textString = new string[]
        {
            "apply 0,1"
        };
        double expected = 0.1;

        var calculator = new CalculateFromText(textString);
        var calculatorResult = calculator.Calculate();

        calculatorResult.Should().Be(expected);
        calculatorResult.Should().BeOfType(typeof(double));
    }

    [Fact]
    public void TestIfWrongFormatOfLastLineInTextArrayReturnsException()
    {
        string[] textString = new string[]
        {
            "apply 0:1"
        };
        var expected = "Wrong format of last line!";
        
        var calculator = new CalculateFromText(textString);
        var calculatorResult = calculator.Invoking(x => x.Calculate());
        
        calculatorResult.Should().Throw<Exception>().WithMessage(expected);
    }

    [Fact]
    public void TestIfWrongLastLineInTextArrayReturnsException()
    {
        string[] textString = new string[]
        {
            "apllyy 0"
        };
        var expected = "Wrong last command!";
        
        var calculator = new CalculateFromText(textString);
        var calculatorResult = calculator.Invoking(x => x.Calculate());

        calculatorResult.Should().Throw<Exception>().WithMessage(expected);
    }
}

