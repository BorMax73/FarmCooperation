namespace FarmCooperation.Models;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int CategoryId { get; set; }
    public ArticleCategory Category { get; set; }

    public int ArticleImageId { get; set; }
    public ArticleImage Image { get; set; }

    public int FarmerId { get; set; }
    public Farmer Farmer { get; set; }

    public double Price { get; set; }
}