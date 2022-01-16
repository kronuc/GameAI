using System;
using GameAI.Game.Models;
using GameAI.Game.Models.Cards;

namespace GameAI.Game
{
    public class Game
    {
        private Character _player;
        private Character _enemy;
        private readonly CardManager _cardManager;
        private readonly CardBasis[] _currentPlayerCards;
        private readonly CardBasis[] _currentEnemyCards;
        private readonly Battle _battle;
        private int _turn;

        public Game(CardManager cardManager, Battle battle)
        {
            _turn = 0;
            _currentEnemyCards = new CardBasis[4];
            _currentPlayerCards = new CardBasis[4];
            _cardManager = cardManager;
            _battle = battle;
        }


        public TurnResult MakeTurn(int selectedCardId)
        {
            var result = new TurnResult();
            var battleResult = GameStatus.Undefined.ToString();
            if (_turn != 0)
            {
                var enemyCard = ChooseCardForEnemy();
                if (selectedCardId > -1 & selectedCardId < 4)
                {
                    _player.ApplyBuff(_currentPlayerCards[selectedCardId]);
                }
                else
                {
                    _player.ApplyBuff(_currentPlayerCards[0]);
                }

                _enemy.ApplyBuff(_currentEnemyCards[enemyCard]);

                _battle.Enemy = _enemy;
                _battle.Player = _player;

                battleResult = _battle.Start().ToString();

                result.BattleLog = _battle.Log;
            }
            else
            {
                InitialiseNewGame();
            }
            
            result.EnemyCards = new CardInfo[4];
            for (int i = 0; i < 4; i++)
            {
                _currentEnemyCards[i] = _cardManager.GetCard();
                _currentEnemyCards[i].CardInformation.Id = i;
                var cardInfo = _currentEnemyCards[i].CardInformation;
                result.EnemyCards[i] = new CardInfo()
                {
                    Id = i,
                    Name = cardInfo.Name,
                    Description = cardInfo.Description,
                    Rareness = cardInfo.Rareness
                };
            }
            
            result.PlayerCards = new CardInfo[4];
            for (int j = 0; j < 4; j++)
            {
                _currentPlayerCards[j] = _cardManager.GetCard();
                _currentPlayerCards[j].CardInformation.Id = j;
                var cardInfo = _currentPlayerCards[j].CardInformation;
                result.PlayerCards[j] = new CardInfo()
                {
                    Id = j,
                    Name = cardInfo.Name,
                    Description = cardInfo.Description,
                    Rareness = cardInfo.Rareness
                };
            }

            result.Enemy = _enemy.Information;
            result.Player = _player.Information;

            if (battleResult != GameStatus.Undefined.ToString())
            {
                InitialiseNewGame();
                _battle.Enemy = _enemy;
                _battle.Player = _player;
                result.GameResult = battleResult;
                _turn = 0;
            }
            else
            {
                _turn++;
                result.GameResult = battleResult;
            }

            return result;
        }

        private void InitialiseNewGame()
        {
            _player = new Character()
            {
                Information = new CharacterInformation()
                {
                    MaxHP = 10000,
                    HP = 10000,
                    Damage = 10,
                    Defense = 200,
                    AttackSpeed = 100,
                    Regeneration = 8,
                    RegenerationSpeed = 100
                }
            };

            _enemy = new Character()
            {
                Information = new CharacterInformation()
                {
                    MaxHP = 10000,
                    HP = 10000,
                    Damage = 10,
                    Defense = 200,
                    AttackSpeed = 100,
                    Regeneration = 8,
                    RegenerationSpeed = 100
                }
            };
        }

        private int ChooseCardForEnemy()
        {
            var enemyVariants = ApplyCardds(_enemy.Information, _currentEnemyCards);
            var playerVariants = ApplyCardds(_player.Information, _currentPlayerCards);
            var bestChoice = 0;
            var currentMax = -100d;
            for (int i = 0; i < 4; i++)
            {
                var currentMin = 100d;
                for (int j = 0; j < 4; j++)
                {
                    var evaluation = Evaluate(playerVariants[j], enemyVariants[i]);
                    if (evaluation < currentMin)
                        currentMin = evaluation;
                }

                if (currentMin > currentMax)
                {
                    currentMax = currentMin;
                    bestChoice = i;
                }
            }
            return bestChoice;
        }

        public double Evaluate(CharacterInformation player, CharacterInformation enemy)
        {
            var result = 0d;
            result += EvaluateProperty(player.Damage, enemy.Damage);
            result += EvaluateProperty(player.Defense, enemy.Defense);
            result += EvaluateProperty(player.AttackSpeed, enemy.AttackSpeed);
            result += 5 * EvaluateProperty(player.HP / player.MaxHP, enemy.HP / enemy.MaxHP);
            result += EvaluateProperty(player.MaxHP, enemy.MaxHP);
            result += EvaluateProperty(player.Regeneration, enemy.Regeneration);
            return result / 11;
        }
        
        private double EvaluateProperty(double playerProperty, double enemyProperty)
        {
            var dif = enemyProperty - playerProperty;
            var result = dif > 0 ? dif / playerProperty : dif / enemyProperty;
            result = result >= 1 ? 100 : result * 100;
            return result;
        }

        public CharacterInformation CopyCharacter(CharacterInformation character)
        {
            var result = new CharacterInformation()
            {
                AttackSpeed = character.AttackSpeed,
                Defense = character.Defense,
                Damage = character.Damage,
                HP = character.HP,
                MaxHP = character.MaxHP,
                Regeneration = character.Regeneration,
                RegenerationSpeed = character.RegenerationSpeed
            };
            return result;
        }

        public CharacterInformation[] ApplyCardds(CharacterInformation character, CardBasis[] card)
        {
            var result = new CharacterInformation[4];
            for (int i = 0; i < 4; i++)
            {
                result[i] = CopyCharacter(character);
                card[i].ApplyBuff(result[i]);
            }
            return result;
        }

        
    }

    
}
