namespace GameAI.Game.Models.Cards
{
    public abstract class CardBasis
    {
        public CardInfo CardInformation { get; set; }

        public abstract void ApplyBuff(CharacterInformation characterInformation);
    }
}
