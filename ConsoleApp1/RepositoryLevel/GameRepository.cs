using System;
using lab2.Entity.Games;
using lab2.Entity.Accounts;
using lab2.RepositoryLevel.Interfaces;

namespace lab2.RepositoryLevel
{
    public class GameRepository : IGameRepository
    {
        private readonly List<Game> GameLst;

        public GameRepository(List<Game> gamelst)
        {
            GameLst = gamelst;
        }

        public void Create(Game game)
        {
            GameLst.Add(game);
        }

        public Game ReadByID(int id)
        {
            var exictingGame = GameLst.FirstOrDefault(g => g.GameIndex == id);
            return exictingGame;
        }

        public List<Game> ReadAll()
        {
            return GameLst;
        }

        public void Update(int id, Game game)
        {
            var existingGame = GameLst.FirstOrDefault(g => g.GameIndex == id);
            existingGame.User1 = game.User1;
            existingGame.User2 = game.User2;
            existingGame.WinAccount = game.WinAccount;
            existingGame.Rating = game.Rating;
        }

        public void Delete(Game game)
        {
            var gameTodelete = GameLst.FirstOrDefault(g => g.GameIndex == game.GameIndex);
            GameLst.Remove(gameTodelete);
        }
    }
}
