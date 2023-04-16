namespace LearningReflection;

public class MailService
{
    public void SendMail(string address, string subject, string body)
    {
        Console.WriteLine($"Sending a warning mail to {address} with subject {subject} and body {body}.");
    }
}