using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QDAT.DefenseBasic
{
    public class GameManager : MonoBehaviour
    {
        public float spawnTime;
        public Enemy[] enemyPrefabs;
        private bool _isGameOver;
        private int _score;

        public int Score { get => _score; set => _score = value; }

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        // Update is called once per frame
        void Update()
        {

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

