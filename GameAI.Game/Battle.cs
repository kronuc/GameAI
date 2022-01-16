using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameAI.Game.Models;

namespace GameAI.Game
{
    public class Battle
    {
        public Character Player { get; set; }
        public Character Enemy { get; set; }
        public List<TickEvent> Log { get; set; }

        public GameStatus Start()
        {
            var playerAttackReload = Player.CountTicksForAttack();
            var playerRegenerationReload = Player.CountTicksForRegeneration();

            Log = new List<TickEvent>();

            var enemyAttackReload = Enemy.CountTicksForAttack();
            var enemyRegenerationReload = Enemy.CountTicksForRegeneration();
            for (int i = 1; i < 10000; i++)
            {
                if (i % enemyRegenerationReload == 0)
                {
                    Enemy.HandleRegeneration();
                    Log.Add(new TickEvent() {Tick = i, Target = "enemy", Type = TickEventType.Heal , Value = Enemy.Information.Regeneration});
                }

                if (i % playerRegenerationReload == 0)
                {
                    Player.HandleRegeneration();
                    Log.Add(new TickEvent() { Tick = i, Target = "player", Type = TickEventType.Heal, Value = Enemy.Information.Regeneration});
                }

                if (i % enemyAttackReload == 0)
                {
                    var damage =  Player.HandleDamage(Enemy.Information.Damage);
                    Log.Add(new TickEvent() { Tick = i, Target = "player", Type = TickEventType.Hit, Value = damage});
                }

                if (i % playerAttackReload == 0)
                {
                    var damage = Enemy.HandleDamage(Player.Information.Damage);
                    Log.Add(new TickEvent() { Tick = i, Target = "enemy", Type = TickEventType.Hit, Value = damage });
                }

                if (Enemy.Information.HP == 0)
                {
                    return GameStatus.Victory;
                }

                if (Player.Information.HP == 0)
                {
                    return GameStatus.Defeat;
                }

                
            }
            return GameStatus.Undefined;
        }
    }
}
