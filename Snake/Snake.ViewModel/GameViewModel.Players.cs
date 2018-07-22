using GalaSoft.MvvmLight;
using Snake.Players;
using Snake.Players.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.ViewModel
{
    public partial class GameViewModel : ViewModelBase
    {
        private void CheckPlayer(Player player, int score)
        {
            Player tmpPlayer = GetPlayer(player.Nickname);
			if(tmpPlayer == null)
            {
                player.BestScore = score;
                AddNewPlayer(player);
            }
            else if ((tmpPlayer.Nickname == player.Nickname))
            {
                UpdatePlayer(player, score);
            }
            else
            {
                player.BestScore = score;
                AddNewPlayer(player);
            }
        }

        private void AddNewPlayer(Player Player)
        {
            using (var repo = new PlayerRepository())
            {
                repo.AddAsync(Player);
            }
        }

        private void UpdatePlayer(Player player, int score)
        {
            using (var repo = new PlayerRepository())
            {
                var PlayerToUpdate = GetPlayer(player.Nickname);
                if (score > player.BestScore)
                {
                    PlayerToUpdate.BestScore = score;
                    repo.Save(PlayerToUpdate);
                }
            }

        }

        private Player GetPlayer(string nickname)
        {
            using (var repo = new PlayerRepository())
            {
                Player Player = repo.GetOne(nickname);
                return Player;
            }
        }
    }
}
