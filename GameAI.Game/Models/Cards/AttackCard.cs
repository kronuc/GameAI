using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.Game.Models.Cards
{
    public class AttackCard : CardBasis
    {
        public override void ApplyBuff(CharacterInformation characterInformation)
        {
            switch (CardInformation.Rareness)
            {
                case CardRareness.Usual:
                    characterInformation.Damage *= 1.05;
                    break;
                case CardRareness.Rare:
                    characterInformation.Damage *= 1.1;
                    break;
                case CardRareness.Legendary:
                    characterInformation.Damage *= 1.25;
                    break;
            }
        }
    }
}
