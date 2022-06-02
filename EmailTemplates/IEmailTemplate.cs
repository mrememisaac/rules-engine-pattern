namespace WorkflowEngine
{

    /// <summary>
    /// Every email template must fulfill this contract
    /// </summary>
    public interface IEmailTemplate
    {
        /// <summary>
        /// The name of the target email template
        /// </summary>
        /// <value></value>
        public string FileName { get; }

        public Request Request { get; }
    }
}