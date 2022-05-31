namespace WorkflowEngine
{
    /// <summary>
    /// Represents a significant event in the life of a request
    /// </summary>
    public class Action
    {
        /// <summary>
        /// When it happened
        /// </summary>
        /// <value></value>
        public DateTime Date { get; }

        /// <summary>
        /// Who did it
        /// </summary>
        /// <value></value>
        public string ActorName { get; }

        /// <summary>
        /// What they did
        /// </summary>
        /// <value></value>
        public ActionType ActionType { get; }

        /// <summary>
        /// Additional information about what happened
        /// </summary>
        /// <value></value>
        public string Remarks { get; }

        /// <summary>
        /// For Entity Framework Core
        /// </summary>
        private Action() { }

        /// <summary>
        /// Ensures instances are always in a valid state
        /// </summary>
        /// <param name="name"></param>
        /// <param name="actionType"></param>
        /// <param name="remarks"></param>
        public Action(string name, ActionType actionType, string remarks)
        {
            ActionType = actionType;
            ActorName = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
            Remarks = string.IsNullOrWhiteSpace(remarks) ? throw new ArgumentNullException(nameof(remarks)) : remarks;
            Date = DateTime.Now;
        }
    }
}