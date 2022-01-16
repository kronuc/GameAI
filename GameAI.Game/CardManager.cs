using System;
using System.Collections.Generic;
using GameAI.Game.Models;
using GameAI.Game.Models.Cards;
using GameAI.Game.Models.Cards.CardBuffs;

namespace GameAI.Game
{
    public class CardManager
    {
        private readonly CardBasis[] _allCards;

        public CardManager()
        {
            _allCards = new CardBasis[7];
            _allCards[0] = new CardBasis()
            {
                CardInformation = new CardInfo()
                {
                    Name = "Attack",
                    Description = "increase attack"
                },
                Buffs = new List<IBuff>() { new AtackBuff()}
            };
            _allCards[1] = new CardBasis()
            {
                CardInformation = new CardInfo()
                {
                    Name = "Attack speed",
                    Description = "increase attack speed"
                },
                Buffs = new List<IBuff>() { new AttackSpeedBuff() }
            };
            _allCards[2] = new CardBasis()
            {
                CardInformation = new CardInfo()
                {
                    Name = "Defense",
                    Description = "increase defense"
                },
                Buffs = new List<IBuff>() { new DefenseBuff() }
            };
            _allCards[3] = new CardBasis()
            {
                CardInformation = new CardInfo()
                {
                    Name = "Heal",
                    Description = "increase heal"
                },
                Buffs = new List<IBuff>() { new HealBuff() }
            };
            _allCards[4] = new CardBasis()
            {
                CardInformation = new CardInfo()
                {
                    Name = "Max Hp",
                    Description = "increase max Hp"
                },
                Buffs = new List<IBuff>() { new MaxHpBuff() }
            };
            _allCards[5] = new CardBasis()
            {
                CardInformation = new CardInfo()
                {
                    Name = "Regeneration speed",
                    Description = "increase regeneration speed"
                },
                Buffs = new List<IBuff>() { new RegenerationSpeedBuff() }
            };
            _allCards[6] = new CardBasis()
            {
                CardInformation = new CardInfo()
                {
                    Name = "Regeneration",
                    Description = "increase regeneration"
                },
                Buffs = new List<IBuff>() { new RegenerationBuff() }
            };
        }


        public CardBasis  GetCard()
        {
            var amountOfCards = _allCards.Length;
            var random = new Random();
            var card = _allCards[random.Next() % amountOfCards];
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
