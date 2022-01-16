using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.Game.Models.Cards.CardBuffs
{
    public class AttackSpeedBuff : IBuff
    {
        public void ApplyBuff(CharacterInformation character, CardRareness rareness)
        {
            switch (rareness)
            {
                case CardRareness.Usual:
                    character.AttackSpeed =  (int)(character.AttackSpeed * 1.05);
                    break;
                case CardRareness.Rare:
                    character.AttackSpeed = (int)(character.AttackSpeed * 1.10);
                    break;
                case CardRareness.Legendary:
                    character.AttackSpeed = (int)(character.AttackSpeed * 1.25);
                    break;
            }
        }
    }
}
