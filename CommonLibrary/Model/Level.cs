namespace CommonLibrary.Model
{
    /// <summary>
    /// Defines the <see cref="Level" />
    /// </summary>
    public class Level
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Level"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="name">The name<see cref="string"/></param>
        public Level(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
