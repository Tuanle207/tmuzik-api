namespace Tmuzik.Infrastructure.Models
{
    public interface IHaveDescription
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}