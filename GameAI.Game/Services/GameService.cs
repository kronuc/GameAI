using AutoBogus;
using GameAI.Game.Models;

namespace GameAI.Game.Services
{
    public class GameService
    {
        private readonly Game _game;

        public GameService(Game game)
        {
            _game = game;
        }

        public TurnResult MakeTurn(int selectedCardId)
        {
            var turn = _game.MakeTurn(selectedCardId);
            return turn;
        }
    }
}
