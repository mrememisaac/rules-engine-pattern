namespace WorkflowEngine
{
    /// <summary>
    /// Every workflow rule must extend this interface
    /// </summary>
    public interface IWorkflowRule
    {
        /// <summary>
        /// Rules engine calls this method as a precondition to determine if this rule applies to the current request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool IsMatch(Request request);

        /// <summary>
        /// Returns the applicable email template
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EmailTemplate SelectTemplate(Request request);
    }
}