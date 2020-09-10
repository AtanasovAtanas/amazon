namespace Amazon.Server.Data.Models
{
    using Amazon.Server.Data.Models.Base;

    public class Country : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
