namespace Amazon.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Amazon.Server.Data.Models.Base;

    public class Picture : BaseDeletableModel<int>
    {
        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
