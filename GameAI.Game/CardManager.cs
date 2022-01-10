using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoBogus;
using GameAI.Game.Models;
using GameAI.Game.Models.Cards;

namespace GameAI.Game
{
    public class CardManager
    {
        public CardBasis  GetCard()
        {
            var information =  AutoFaker.Generate<CardInfo>();
            return new AttackCard() { CardInformation = information };
        }
    }
}
