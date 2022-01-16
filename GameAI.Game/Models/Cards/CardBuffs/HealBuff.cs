using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.Game.Models.Cards.CardBuffs
{
    public class HealBuff : IBuff
    {
        public void ApplyBuff(CharacterInformation character, CardRareness rareness)
        {
            switch (rareness)
            {
                case CardRareness.Usual:
                    character.HP += character.MaxHP * 0.05;
                    break;
                case CardRareness.Rare:
                    character.HP += character.MaxHP * 0.10;
                    break;
                case CardRareness.Legendary:
                    character.HP += character.MaxHP * 0.25;
                    break;
            }

            if (character.MaxHP < character.HP)
                character.HP = character.MaxHP;
        }
    }
}
