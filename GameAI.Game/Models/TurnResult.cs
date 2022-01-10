using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.Game.Models
{
    public class TurnResult
    {
        public string GameResult { get; set; }
        public CharacterInformation Player { get; set; }
        public CharacterInformation Enemy { get; set; }
        public CardInfo[] PlayerCards { get; set; }
        public CardInfo[] EnemyCards { get; set; }
        public IEnumerable<TickEvent> BattleLog { get; set; }
    }

    public enum GameStatus
    {
        Victory,
        Defeat,
        Undefined
    }
}
