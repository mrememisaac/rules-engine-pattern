namespace WorkflowEngine;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var request = new Request(Guid.NewGuid(), "Emem Isaac");
        request.AddItem(new RequestItem(Guid.NewGuid(), "Pizza", "Blue green pizza", 2));
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
    /// Uses reflection to find and load all the IWorkflowRule implementations in this assembly
    /// </summary>
    /// <param name="request"></param>
    /// <returns>IEnumerable<EmailTemplate></returns>
    public static IEnumerable<EmailTemplate> GetEmailTemplates(Request request)
    {
        var ruleType = typeof(IWorkflowRule);
        var rules = typeof(Program).Assembly.GetTypes()
            .Where(t => ruleType.IsAssignableFrom(t) && !t.IsInterface)
            .Select(t => Activator.CreateInstance(t) as IWorkflowRule);
        var engine = new WorkflowRulesEngine(rules!);
        return engine.GetEmailTemplates(request);
    }
}