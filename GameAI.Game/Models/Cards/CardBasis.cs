using System.Collections.Generic;
using GameAI.Game.Models.Cards.CardBuffs;

namespace GameAI.Game.Models.Cards
{
    public class CardBasis
    {
        public List<IBuff> Buffs { get; set; }

        public CardInfo CardInformation { get; set; }

        public void ApplyBuff(CharacterInformation characterInformation)
        {
            foreach (var buff in Buffs)
            {
                buff.ApplyBuff(characterInformation, CardInformation.Rareness);
            }
        }
    }
}
