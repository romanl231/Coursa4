using System;
using lab1;
using lab2.Entity.Games;
using lab2.Entity.Accounts;
using lab2.RepositoryLevel.Interfaces;
using lab2.ServiceLevel.Interfaces;
using lab2.RepositoryLevel;
using lab2.DbContext;
using lab2.Data;
using lab2.Factories;

namespace lab2.ServiceLevel
{
    public class GameService : Interfaces.IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly DBContext _database;
        private int Id 
        {
            get
            {
                var lastGameId = _database.Games.LastOrDefault();
                return (lastGameId?.GameIndex + 1) ?? 1;
            }
                }
        public GameService(DBContext database)
        {
            _database = database;
            _gameRepository = new GameRepository(_database.Games);
        }

        public void CreateNew(string gameType)
        {
            GameAccount _bot = PlayerFactory.CreatePlayer(0, "BOT", "bot", "standart");
            GameManager gameManager = new GameManager();
            if (gameManager.Play(gameType))
            {
                Game game = GameFactory.CreateGame(gameType, Id, UserSession.CurrentUser, _bot, UserSession.CurrentUser, 0);
                UserSession.CurrentUser.WinGame(game);
                _bot.LoseGame(game);
                _gameRepository.Create(game);
            }
            else
            {
                Game game = GameFactory.CreateGame(gameType, Id, UserSession.CurrentUser, _bot, _bot, 0);
                UserSession.CurrentUser.LoseGame(game);
                _bot.WinGame(game);
                _gameRepository.Create(game);
            }
        }

        public Game GetById(int id)
        {
            return _gameRepository?.ReadByID(id) ?? throw new Exception($"Game with {id} isn't found");
        }

        
        public List<Game> GetAll()
        {
            var games = _gameRepository.ReadAll();
            if (!games.Any())
            {
                throw new Exception("Game with isn't found");
            }

            return games;
        }

        public void Delete(int id)
        {
            var game = _gameRepository.ReadByID(id);
            if (game == null)
            {
                throw new Exception($"Game with {id} isn't found for deletion");
            }

            _gameRepository.Delete(game);
        }

        public List<Game> ShowGamesForPlayer(GameAccount player)
        {
            var gameLst = GetAll();
            var playerGames = gameLst.Where(game => game.User1 == player || game.User2 == player).ToList();

            if (playerGames.Any())
            {
                return playerGames;
            }
            else
            {
                throw new Exception($"No games found for player {player.UserName}.");
            }
        }
    }
}
