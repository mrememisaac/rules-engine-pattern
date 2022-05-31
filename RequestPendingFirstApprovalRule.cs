namespace WorkflowEngine
{
    /// <summary>
    /// A rule that fires when a request is awaiting first approval
    /// </summary>
    public class RequestPendingFirstApprovalRule : IWorkflowRule
    {
        /// <summary>
        /// This rule matches when there has been no first approval
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool IsMatch(Request request)
        {
            return !request.ActionsCollection.Any(a => a.ActionType == ActionType.FirstApproval);
        }

        /// <summary>
        /// Returns the email template for this rule
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EmailTemplate SelectTemplate(Request request)
        {
            return new EmailTemplate(nameof(RequestPendingFirstApprovalRule), request);
        }
    }
}
