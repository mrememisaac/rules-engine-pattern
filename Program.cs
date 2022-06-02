namespace WorkflowEngine;

/// <summary>
/// A program to demo the use of the rules engine pattern
/// </summary>
internal class Program
{
    private static WorkflowRulesEngine Engine => InitializeRulesEngine();

    static void Main(string[] args)
    {
        Console.WriteLine("Rules Engine Pattern Implementation");

        //create a sample request
        var request = new Request(Guid.NewGuid(), "Emem Isaac");

        //add an item to the request
        request.AddItem(new RequestItem(Guid.NewGuid(), "Pizza", "Blue green pizza", 2));

        //get the list of email templates to be fired
        var templates = GetEmailTemplates(request);
        foreach (var template in templates)
        {
            //should print out two templates because both apply to a new request
            //NewRequestRule
            //RequestPendingFirstApprovalRule
            Console.WriteLine($"{template.FileName}");
        }
        //manually add a first approval
        request.AddAction(new Action("Jane Anderson", ActionType.FirstApproval, "Approved by Jane Anderson"));
        Console.WriteLine($"\n- After manually adding a first approval -\n");
        templates = GetEmailTemplates(request);
        foreach (var template in templates)
        {
            //should print out one template because at this point only hte second approval is pending
            //RequestPendingSecondApprovalRule
            Console.WriteLine($"{template.FileName}");
        }
    }

    /// <summary>
    /// Returns a list of email notifications based on the state of the request
    /// </summary>
    /// <param name="request"></param>
    /// <returns>IEnumerable<EmailTemplate></returns>
    public static IEnumerable<EmailTemplate> GetEmailTemplates(Request request)
    {
        return Engine.GetEmailTemplates(request);
    }

    /// <summary>
    /// Uses reflection to find and load all the IWorkflowRule implementations in this assembly
    /// </summary>
    /// <returns>WorkflowRulesEngine</returns>
    static WorkflowRulesEngine InitializeRulesEngine()
    {
        var ruleType = typeof(IWorkflowRule);
        var rules = typeof(Program).Assembly.GetTypes()
            .Where(t => ruleType.IsAssignableFrom(t) && !t.IsInterface)
            .Select(t => Activator.CreateInstance(t) as IWorkflowRule);
        return new WorkflowRulesEngine(rules!);
    }
}