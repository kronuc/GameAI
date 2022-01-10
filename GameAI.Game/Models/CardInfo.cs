namespace GameAI.Game.Models
{
    public class CardInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CardRareness Rareness { get; set; }
    }

    public enum CardRareness
    {
        Usual,
        Rare,
        Legendary
    }
}
