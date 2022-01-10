namespace GameAI.Game.Models.Cards
{
    class HealthPointCard : CardBasis
    {
        public override void ApplyBuff(CharacterInformation characterInformation)
        {
            switch (CardInformation.Rareness)
            {
                case CardRareness.Usual:
                    characterInformation.HP *= 1.05;
                    break;
                case CardRareness.Rare:
                    characterInformation.HP *= 1.1;
                    break;
                case CardRareness.Legendary:
                    characterInformation.HP *= 1.25;
                    break;
            }
            if (characterInformation.HP > characterInformation.MaxHP)
                characterInformation.HP = characterInformation.MaxHP;
        }
    }
}
