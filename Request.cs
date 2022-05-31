using System.Collections.ObjectModel;

namespace WorkflowEngine
{
    /// <summary>
    /// Represents a real world request. Eg request for work laptop ...
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Unique identifier for this request
        /// </summary>
        /// <value></value>
        public Guid Id { get; }

        /// <summary>
        /// Name of person making the request
        /// </summary>
        /// <value></value>
        public string NameOfRequester { get; }

        /// <summary>
        /// Date request was created
        /// </summary>
        /// <value></value>
        public DateTime RequestDate { get; }

        /// <summary>
        /// All items user is requesting for
        /// </summary>
        /// <typeparam name="RequestItem"></typeparam>
        /// <returns></returns>
        private List<RequestItem> Items { get; } = new List<RequestItem>();

        /// <summary>
        /// A comprehensive list of user actions on this request (first approval, second approval ...)
        /// </summary>
        /// <typeparam name="Action"></typeparam>
        /// <returns></returns>
        private List<Action> Actions { get; } = new List<Action>();

        /// <summary>
        /// Exposes a readonly list of items in this collection
        /// </summary>
        /// <returns></returns>
        public ReadOnlyCollection<RequestItem> ItemsCollection => Items.AsReadOnly();

        /// <summary>
        /// Returns a readonly list of actions on this request item
        /// </summary>
        /// <returns></returns>
        public ReadOnlyCollection<Action> ActionsCollection => Actions.AsReadOnly();

        public Request() { }

        /// <summary>
        /// Instantiates a request object after due validation checks
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Request(Guid id, string name)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            NameOfRequester = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
            RequestDate = DateTime.Now;
        }

        /// <summary>
        /// Adds a new item to the request
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(RequestItem item)
        {
            if (item == null) return;
            Items.Add(item);
        }

        /// <summary>
        /// Adds a new action to the request
        /// </summary>
        /// <param name="action"></param>
        public void AddAction(Action action)
        {
            if (action == null) return;
            Actions.Add(action);
        }
    }
}