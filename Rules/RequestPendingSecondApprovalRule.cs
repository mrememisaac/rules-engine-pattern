
namespace WorkflowEngine
{
    /// <summary>
    /// A rule that fires when a request is awaiting first approval
    /// </summary>
    public class RequestPendingSecondApprovalRule : IWorkflowRule
    {
        /// <summary>
        /// This rule matches when there has been no first approval
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool IsMatch(Request request)
        {
            var firstApprovalOccured = request.ActionsCollection.Any(a => a.ActionType == ActionType.FirstApproval);
            return firstApprovalOccured && request.ActionsCollection.Any(a => a.ActionType != ActionType.SecondApproval);
        }

        /// <summary>
        /// Returns the email template for this rule
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EmailTemplate SelectTemplate(Request request)
        {
            return new EmailTemplate(nameof(RequestPendingSecondApprovalRule), request);
        }
    }
}