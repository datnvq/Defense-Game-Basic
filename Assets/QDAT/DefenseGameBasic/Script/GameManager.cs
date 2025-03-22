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

        public void PlayGame()
        {
            Debug.Log("PlayGame called. _isGameOver: " + _isGameOver);
            StartCoroutine(SpawnEnemy());

            guiMng.ShowGameGUI(true);
            guiMng.UpdateGameplayCoins();
        }

        public bool IsComponentNull()
        {
            return guiMng == null;
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

