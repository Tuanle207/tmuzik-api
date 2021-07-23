namespace Tmuzik.Infrastructure.Data.Models
{
    public interface IHaveDescription
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}