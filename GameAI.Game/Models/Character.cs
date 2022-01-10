using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using GameAI.Game.Models.Cards;

namespace GameAI.Game.Models
{
    public class Character
    {
        public CharacterInformation Information { get; set; }

        public void ApplyBuff(CardBasis card)
        {
            card.ApplyBuff(Information);
        }

        public int CountTicksForAttack()
        {
            return 10000 / Information.AttackSpeed;
        }


        public int CountTicksForRegeneration()
        {
            return 10000 / Information.RegenerationSpeed;
        }

        public void HandleDamage(double damage)
        {
            this.Information.HP -= damage * (1 - (-100 / ((this.Information.Defense / 10) + 100) + 1));
            if (this.Information.HP < 0) 
            {
                this.Information.HP = 0;
            }
        }

        public void HandleRegeneration()
        {
            this.Information.HP += this.Information.Regeneration;
            if (this.Information.HP > this.Information.MaxHP)
            {
                this.Information.HP = this.Information.MaxHP;
            }
        }
    }
}
