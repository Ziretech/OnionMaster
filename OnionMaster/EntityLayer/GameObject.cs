namespace EntityLayer
{
    public class GameObject
    {
        public string Name { get; set; }
        public Renderable Renderable { get; set; }
        public Positional Positional { get; set; }
        public Controllable Controllable { get; set; }
    }
}
