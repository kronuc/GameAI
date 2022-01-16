namespace GameAI.Game.Models.Cards.CardBuffs
{
    public class RegenerationBuff : IBuff
    {
        public void ApplyBuff(CharacterInformation character, CardRareness rareness)
        {

            switch (rareness)
            {
                case CardRareness.Usual:
                    character.Regeneration *= 1.05;
                    break;
                case CardRareness.Rare:
                    character.Regeneration *= 1.10;
                    break;
                case CardRareness.Legendary:
                    character.Regeneration *= 1.25;
                    break;
            }
        }
    }
}
