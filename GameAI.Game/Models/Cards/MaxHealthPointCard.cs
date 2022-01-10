using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.Game.Models.Cards
{
    public class MaxHealthPointCard : CardBasis
    {
        public override void ApplyBuff(CharacterInformation characterInformation)
        {
            switch (CardInformation.Rareness)
            {
                case CardRareness.Usual:
                    characterInformation.MaxHP *= 1.05;
                    break;
                case CardRareness.Rare:
                    characterInformation.MaxHP *= 1.1;
                    break;
                case CardRareness.Legendary:
                    characterInformation.MaxHP *= 1.25;
                    break;
            }
        }
    }
}
