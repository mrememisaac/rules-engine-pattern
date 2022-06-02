
namespace WorkflowEngine
{
    /// <summary>
    /// This rul applies to every new request, it invokes a confirmation notification to the request author
    /// </summary>
    public class NewRequestRule : IWorkflowRule
    {
        /// <summary>
        /// A new rule typically has zero acitons
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool IsMatch(Request request)
        {
            return request.ActionsCollection.Count == 0;
        }

        /// <summary>
        /// Returns the matching template
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EmailTemplate SelectTemplate(Request request)
        {
            return new EmailTemplate(nameof(NewRequestRule), request);
        }
    }
}