using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace QDAT.DefenseBasic
{
    public class GameManager : MonoBehaviour, IComponentChecking
    {
        public float spawnTime;
        public Enemy[] enemyPrefabs;
        public GUIManager guiMng;
        public ShopManger shopMng;
        private Player _curPlayer;
        private bool _isGameOver;
        private int _score;

        public int Score { get => _score; set => _score = value; }

        // Start is called before the first frame update
        void Start()
        {
            if (IsComponentNull()) return;

            guiMng.ShowGameGUI(false);
            guiMng.UpdateMainCoins();
        }

        public bool IsComponentNull()
        {
            return guiMng == null || shopMng == null;
        }

        public void PlayGame()
        {
            ActivePlayer();
            StartCoroutine(SpawnEnemy());

            guiMng.ShowGameGUI(true);
            guiMng.UpdateGameplayCoins();
        }

        public void ActivePlayer()
        {
            if(IsComponentNull()) return;

            if(_curPlayer != null)
            {
                Destroy(_curPlayer.gameObject);
            }

            var shopItems = shopMng.items;

            if (shopItems == null || shopItems.Length <= 0) return;

            var newPlayerPb = shopItems[Pref.curPlayerId].playerPrefab;

            if(newPlayerPb != null)
            {
                _curPlayer = Instantiate(newPlayerPb, new Vector3(-7f, -1f, 0f), Quaternion.identity);
            }
        }

        public void Gameover()
        {
            if(_isGameOver) return;
            _isGameOver = true;
            Pref.bestScore = _score;

            if(guiMng.gameoverDialog != null)
                guiMng.gameoverDialog.Show(true);
        }

        IEnumerator SpawnEnemy()
        {
            while (!_isGameOver)
            {
                if (enemyPrefabs != null && enemyPrefabs.Length > 0)
                {
                    int randIdx = Random.Range(0, enemyPrefabs.Length);

                    Enemy enemyPrefab = enemyPrefabs[randIdx];

                    if (enemyPrefab)
                    {
                        Instantiate(enemyPrefab, new Vector3(8, 0, 0), Quaternion.identity);
                    }
                }
                yield return new WaitForSeconds(spawnTime);
            }
            
        }
    }
}

