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
        private async Task CheckPlayerAsync(string nickname, int score)
        {
            using (var repo = new PlayerRepository())
            {
                Player tmpPlayer = await GetPlayerAsync(nickname, repo);
                if (tmpPlayer == null || tmpPlayer.Nickname != nickname)
                {
                    tmpPlayer = new Player
                    {
                        Nickname = nickname,
                        BestScore = score
                    };
                    await AddNewPlayerAsync(tmpPlayer, repo);
                }
                else
                {
                    await UpdatePlayerAsync(tmpPlayer, score, repo);
                }
            }
        }

        private async Task AddNewPlayerAsync(Player player, PlayerRepository repo)
        {
            await repo.AddAsync(player);
        }

        private async Task UpdatePlayerAsync(Player player, int score, PlayerRepository repo)
        {
            if (score > player.BestScore)
            {
                player.BestScore = score;
                await repo.SaveAsync(player);
            }
        }

        private async Task<Player> GetPlayerAsync(string nickname, PlayerRepository repo)
        {
            Player Player = await repo.GetOneAsync(nickname);

            return Player;
        }
    }
}
