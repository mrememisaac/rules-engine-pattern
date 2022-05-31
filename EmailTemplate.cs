namespace WorkflowEngine
{
    /// <summary>
    /// Represents an email template
    /// </summary>
    public class EmailTemplate : IEmailTemplate
    {
        public string FileName { get; }

        public Request Request { get; }

        public EmailTemplate(string fileName, Request request)
        {
            FileName = string.IsNullOrWhiteSpace(fileName) ? throw new ArgumentNullException(nameof(fileName)) : fileName;
            Request = request;
        }
    }
}