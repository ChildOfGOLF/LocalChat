using System.IO;

public class History
{
    private string filePath = "chat_history.txt";

    public void SaveMessage(string message)
    {
        File.AppendAllText(filePath, message + Environment.NewLine);
    }

    public string LoadHistory()
    {
        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }
        return string.Empty;
    }
}