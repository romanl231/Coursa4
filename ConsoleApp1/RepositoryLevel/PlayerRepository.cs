using System;
using lab2.RepositoryLevel.Interfaces;
using lab2.Entity.Accounts;
using lab2.Data;

namespace lab2.RepositoryLevel
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<GameAccount> Players;

        public PlayerRepository(List<GameAccount> players)
        {
            Players = players;
            
        }

        public void Create(GameAccount player)
        {
            Players.Add(player);
        }

        public GameAccount FindUserByName(string name)
        {
            var player = Players.FirstOrDefault(p => p.UserName == name);
            return player;
        }
         

        public GameAccount ReadById(int id)
        {
            var player = Players.FirstOrDefault(p => p.Id == id);
            return player;
        }

        public List<GameAccount> ReadAll()
        {
            return Players;
        }

        public void Update(int id, string username, string password)
        {
            var existingPlayer = Players.FirstOrDefault(p => p.Id == id);
            existingPlayer.UserName = username;
            existingPlayer.Password = password;
        }

        public void Delete(GameAccount player)
        {
            var playerToDelete = Players.FirstOrDefault(p => p.Id == player.Id);
            Players.Remove(playerToDelete);
        }
    }
}
