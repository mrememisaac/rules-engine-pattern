namespace WorkflowEngine
{

    /// <summary>
    /// The email engine knows that if it receives this template, it should do nothing
    /// Null Object Pattern at work here
    /// </summary>
    public class NullEmailTemplate : IEmailTemplate
    {
        public string FileName { get; } = string.Empty;

        public Request Request { get; }

        public NullEmailTemplate(string fileName, Request request)
        {
            FileName = string.IsNullOrWhiteSpace(fileName) ? throw new ArgumentNullException(nameof(fileName)) : fileName;
            Request = request;
        }
    }
}