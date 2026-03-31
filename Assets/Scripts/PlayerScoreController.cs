using Unity.Netcode;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerScoreController
    {
            private NetworkVariable<PlayerScoreData> playerScoreData=new NetworkVariable<PlayerScoreData>();
            private PlayerScoreView _playerScoreView;
            public PlayerScoreController(PlayerScoreView playerScoreView)
            {
                
                playerScoreView.CrossTxt.text = playerScoreData.Value.CrossScore.ToString();
                playerScoreView.CircleTxt.text = playerScoreData.Value.CircleScore.ToString();
            }
            
            
            
            // [Rpc(SendTo.Everyone)]
            // public void AddScoreRpc()
            // {
            //     playerScoreData.Value.CrossScore++;
            //     Debug.Log(playerScoreData.Value.CrossScore);
            // }
            // public void UpdateScore(PlayerType winner)
            // {
            //     if (winner == PlayerType.Cross)
            //     {
            //         playerScoreData.Value.CrossScore++;
            //         _playerScoreView.CrossTxt.text = playerScoreData.Value.CrossScore.ToString();
            //     }
            //     else
            //     {
            //         playerScoreData.Value.CircleScore++;
            //         _playerScoreView.CircleTxt.text = playerScoreData.Value.CircleScore.ToString();
            //     }
            // }
    }
}