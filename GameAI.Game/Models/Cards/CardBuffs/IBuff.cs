namespace GameAI.Game.Models.Cards.CardBuffs
{
    public interface IBuff
    {
        public void ApplyBuff(CharacterInformation character, CardRareness rareness);
    }
}
