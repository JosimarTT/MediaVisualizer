using MediaVisualizer.Shared.ExtensionMethods;

namespace MediaVisualizer.Shared.Tests;

[TestClass]
public class StringExtensionsTests
{
    [TestMethod]
    [DataRow("example.jpg")]
    [DataRow("example.jpeg")]
    [DataRow("example.png")]
    [DataRow("example.gif")]
    public void IsImage_ShouldReturnTrue_ForImagePath(string imagePath)
    {
        // Act
        var result = imagePath.IsImage();

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsImage_ShouldReturnFalse_ForNonImagePath()
    {
        // Arrange
        var nonImagePath = "example.txt";

        // Act
        var result = nonImagePath.IsImage();

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [DataRow("example.mp4")]
    [DataRow("example.mkv")]
    [DataRow("example.avi")]
    [DataRow("example.flv")]
    [DataRow("example.wmv")]
    public void IsVideo_ShouldReturnTrue_ForVideoPath(string videoPath)
    {
        // Act
        var result = videoPath.IsVideo();

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsVideo_ShouldReturnFalse_ForNonVideoPath()
    {
        // Arrange
        var nonVideoPath = "example.txt";

        // Act
        var result = nonVideoPath.IsVideo();

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void RemoveExtraSpaces_ShouldRemoveExtraSpaces()
    {
        // Arrange
        var text = "This  is   a    test";

        // Act
        var result = text.RemoveExtraSpaces();

        // Assert
        Assert.AreEqual("This is a test", result);
    }

    [TestMethod]
    public void RemoveInvalidFolderNameChars_ShouldRemoveInvalidChars()
    {
        // Arrange
        var text = @"\Invalid. /:Folder. *Name.?>|<";

        // Act
        var result = text.RemoveInvalidFolderNameChars();

        // Assert
        Assert.AreEqual("Invalid. Folder. Name.", result);
    }
}