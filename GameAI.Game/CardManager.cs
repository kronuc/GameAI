using System;
using System.Collections.Generic;
using GameAI.Game.Models;
using GameAI.Game.Models.Cards;
using GameAI.Game.Models.Cards.CardBuffs;

namespace GameAI.Game
{
    public class CardManager
    {
        public CardBasis  GetCard()
        {
            var random = new Random();
            var number = random.Next() % 7;
            CardBasis card  = new CardBasis() { CardInformation = new CardInfo() };
            switch (number)
            {
                case 0:
                    card = new CardBasis()
                    {
                        CardInformation = new CardInfo()
                        {
                            Name = "Attack",
                            Description = "increase attack"
                        },
                        Buffs = new List<IBuff>() { new AtackBuff() }
                    };
                    break;
                case 1:
                    card = new CardBasis()
                    {
                        CardInformation = new CardInfo()
                        {
                            Name = "Attack speed",
                            Description = "increase attack speed"
                        },
                        Buffs = new List<IBuff>() { new AttackSpeedBuff() }
                    };
                    break;
                case 2:
                    card = new CardBasis()
                    {
                        CardInformation = new CardInfo()
                        {
                            Name = "Defense",
                            Description = "increase defense"
                        },
                        Buffs = new List<IBuff>() { new DefenseBuff() }
                    };
                    break;
                case 3:
                    card = new CardBasis()
                    {
                        CardInformation = new CardInfo()
                        {
                            Name = "Heal",
                            Description = "heal you"
                        },
                        Buffs = new List<IBuff>() { new HealBuff() }
                    };
                    break;
                case 4:
                    card = new CardBasis()
                    {
                        CardInformation = new CardInfo()
                        {
                            Name = "Max Hp",
                            Description = "increase max Hp"
                        },
                        Buffs = new List<IBuff>() { new MaxHpBuff() }
                    };
                    break;
                case 5:
                    card = new CardBasis()
                    {
                        CardInformation = new CardInfo()
                        {
                            Name = "Regeneration speed",
                            Description = "increase regeneration speed"
                        },
                        Buffs = new List<IBuff>() { new RegenerationSpeedBuff() }
                    };
                    break;
                case 6:
                    card = new CardBasis()
                    {
                        CardInformation = new CardInfo()
                        {
                            Name = "Regeneration",
                            Description = "increase regeneration"
                        },
                        Buffs = new List<IBuff>() { new RegenerationBuff() }
                    };
                    break;
            }

            card.CardInformation.Rareness = DefineCardRareness();
            return card;
        }
        
        private CardRareness DefineCardRareness()
        {
            CardRareness result;
            var random = new Random();
            double number = random.NextDouble();
            if (number < 0.75)
                result = CardRareness.Usual;
            else if (number >= 0.75 & number < 0.95)
                result = CardRareness.Rare;
            else
                result = CardRareness.Legendary;
            return result;
        }
    }
    
}
