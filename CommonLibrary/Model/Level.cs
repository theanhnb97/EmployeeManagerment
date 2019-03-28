namespace CommonLibrary.Model
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Level(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
