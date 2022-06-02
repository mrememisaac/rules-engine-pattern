namespace WorkflowEngine
{
    /// <summary>
    /// Represents an item in a request
    /// </summary>
    public class RequestItem
    {
        /// <summary>
        /// Unique identity for this request item
        /// </summary>
        /// <value></value>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the requested item
        /// </summary>
        /// <value></value>
        public string Name { get; }

        /// <summary>
        /// Additional descriptive information about the item
        /// </summary>
        /// <value></value>
        public string Description { get; }

        /// <summary>
        /// The number of units of the item required
        /// </summary>
        /// <value></value>
        public int Quantity { get; }

        /// <summary>
        /// The likely price of the requested item
        /// </summary>
        /// <value></value>
        public int Price { get; }

        /// <summary>
        /// Constructs a request item after due validation checks
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="quantity"></param>
        public RequestItem(Guid id, string name, string description, int quantity = 1)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
            Description = string.IsNullOrWhiteSpace(description) ? throw new ArgumentNullException(nameof(description)) : description;
            Quantity = quantity < 1 ? 1 : quantity;
        }
    }
}