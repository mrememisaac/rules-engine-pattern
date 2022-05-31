namespace WorkflowEngine;

/// <summary>
/// Uses the rules engine pattern to invoke various rules on a request
/// </summary>
public class WorkflowRulesEngine
{
    /// <summary>
    /// The rules
    /// </summary>
    /// <value></value>
    private IEnumerable<IWorkflowRule> Rules { get; }

    public WorkflowRulesEngine(IEnumerable<IWorkflowRule> rules)
    {
        Rules = rules;
    }

    /// <summary>
    /// Checks all the rules for those which apply to this request
    /// </summary>
    /// <param name="request"></param>
    /// <returns>A list of matching email templates</returns>
    public IEnumerable<EmailTemplate> GetEmailTemplates(Request request)
    {
        var templates = new List<EmailTemplate>();
        foreach (var rule in Rules)
        {
            if (rule.IsMatch(request))
                templates.Add(rule.SelectTemplate(request));
        }
        return templates;
    }
}