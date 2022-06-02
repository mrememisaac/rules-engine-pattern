# Rules Engine Pattern Applied

This sample demonstrates the use of the Rules Engine Pattern.

## Scenario

Imagine you are working on a software for requesting items like work tools etc. Whenever a new item request is submitted, the requester should be sent an email confirmation and his manager should be notified, that there is a new requisition awaiting his approval. If the manager approves, the Director of that department should be notified that there is a requisition pending his approval.

From the above, we can extract three rules.

#. When a new request is submitted fire a request created successfully alert
#. New Request should fire a "Manager please approve request" message
#. When Manager approves, fire a "Director please approve request" message

It stands to reason also that, if a request is declined at any point in time, the requester should also be notified. Therefore we have the following additional rules

#. When Manager declines a request fire "Manager Declined your request" alert
#. When Director declines a request fire "Director Declined your request" alert

Obviously those copied in each of these alerts would vary for instance a new request alert should go only to the requester. The "Manager please approve request" message should be addressed to the requesters manager but the requester should be copied.

## Task

We need a way to ensure that whenever changes happen to a request changes like created, manager approved, manager declined, director approved, director declined, comment added etc. That an appropriate message or set of messages are sent.

Furthermore there is a possibility that the list of things can that can happen to a request can grow. Therefore we need a way to ensure that whenever we add a new rule, it is automatically picked up and applied. This situatation lends itself beautifully to the Rules Engine pattern.

## Domain

The entities in this domain are:

- [Request](/Entities/Request.cs)
- [Request Item](/Entities/RequestItem.cs)
- [Action](/Entities/Action.cs)
- [ActionType](/Entities/ActionType.cs)

Each entity is well documented. Visit the links to see details.

## Rules

Each rule must implement [IWorkflowRule interface](/Rules/IWorkflowRule.cs). This is the reason why we can use reflection to find all the workflow rules automatically.

```
    static WorkflowRulesEngine InitializeRulesEngine()
    {
        var ruleType = typeof(IWorkflowRule);
        var rules = typeof(Program).Assembly.GetTypes()
            .Where(t => ruleType.IsAssignableFrom(t) && !t.IsInterface)
            .Select(t => Activator.CreateInstance(t) as IWorkflowRule);
        return new WorkflowRulesEngine(rules!);
    }
```
