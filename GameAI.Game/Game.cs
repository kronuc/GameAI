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
                if (selectedCardId > -1 & selectedCardId < 4)
                {
                    _player.ApplyBuff(_currentPlayerCards[selectedCardId]);
                }
                else
                {
                    _player.ApplyBuff(_currentPlayerCards[0]);
                }

                var enemyCard = ChooseCardForEnemy();
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
                result.EnemyCards[i] = _currentEnemyCards[i].CardInformation;
            }
            
            result.PlayerCards = new CardInfo[4];
            for (int i = 0; i < 4; i++)
            {
                _currentPlayerCards[i] = _cardManager.GetCard();
                result.PlayerCards[i] = _currentPlayerCards[i].CardInformation;
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
                    Regeneration = 5,
                    RegenerationSpeed = 50
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
                    Regeneration = 5,
                    RegenerationSpeed = 50
                }
            };
        }

        private int ChooseCardForEnemy()
        {
            return 1;
        }
    }

    
}
