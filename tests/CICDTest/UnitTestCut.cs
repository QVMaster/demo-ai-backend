namespace CICDTest;

public class UnitTestCut
{
    [Fact]
    public void TestCut()
    {
        // Arrange
        var mainProcess = new MainProcess("String for unit test is here.");

        // Act
        string result = mainProcess.CutEnd(9);

        //Assert
        Assert.Equal("String for unit test", result);
    }

    [Fact]
    public void TestCutWithException()
    {
        // Arrange
        var mainProcess = new MainProcess("Short");

        // Act & Assert
        Assert.Throws<InvalidDataException>( () => mainProcess.CutEnd(10));
    }   

    [Fact]
    public void TestCutWithZero()
    {
        // Arrange
        var mainProcess = new MainProcess("Zero cut test");

        // Act
        string result = mainProcess.CutEnd(0);

        //Assert
        Assert.Equal(mainProcess.MainStr, result);
    }

    [Fact]
    public void TestCutWithFullLength()
    {
        // Arrange
        var mainProcess = new MainProcess("Full length cut test");

        // Act
        string result = mainProcess.CutEnd(mainProcess.MainStr.Length);

        //Assert
        Assert.Equal(string.Empty, result);
    }

}
