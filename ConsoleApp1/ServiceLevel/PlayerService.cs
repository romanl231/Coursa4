using System;
using lab1;
using lab2.RepositoryLevel.Interfaces;
using lab2.ServiceLevel.Interfaces;
using lab2.Entity.Accounts;
using lab2.Entity.Games;
using lab2.DbContext;
using lab2.Data;
using lab2.RepositoryLevel;
using lab2.Factories;

namespace lab2.ServiceLevel
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly DBContext _dbContext;
        public int Id { 
            get 
            {
                var lastPlayerId =  _dbContext.Players.LastOrDefault();
                return (lastPlayerId?.Id + 1) ?? 1;
                
            }
        }
        public PlayerService(DBContext database)
        {
            _dbContext = database;
            _playerRepository = new PlayerRepository(_dbContext.Players);
        }

        public bool CheckForExisting(string username)
        {
            var players = GetAll();
            foreach (var player in players)
            {
                if (player.UserName == username)
                {
                    return true;
                }
            }
            return false;
        }

        public void CreateNew(string username, string password, string accType)
        {
            if (CheckForExisting(username)) 
            {
                throw new Exception("User with this nickname already exist");
            }
            else
            {
                GameAccount player = PlayerFactory.CreatePlayer(Id, username, password, accType);
                _playerRepository.Create(player);
            }
           
        }

        public bool Login(string username, string password)
        {
            GameAccount user = _playerRepository.FindUserByName(username);
            if (user == null || user.Password != password)
            {
                return false;
            }
            UserSession.SetUserRole(UserSession.UserRole.User);
            UserSession.CurrentUser = user;
            return true;
        }

        public void Logout()
        {
            UserSession.CurrentUser = null;
            UserSession.ResetUserRole();
        }

        public GameAccount GetUserById(int id)
        {
            if (id != null)
            {
                var wantedUser = _playerRepository.ReadById(id);
                return wantedUser;
            }
            else throw new Exception($"User with {id} not found");
        }

        public List<GameAccount> GetAll()
        {
            return _playerRepository.ReadAll();
        }
        public void Update(int id, string username, string password)
        {
            _playerRepository.Update(id, username, password);
        }

        public void Delete(int id)
        {
            GameAccount player = _playerRepository.ReadById(id);
            if (CheckForExisting(player.UserName))
            {
                _playerRepository.Delete(player);
            }
            else
            {
                throw new Exception("There's no player to delete");
            }
        }
    }
}