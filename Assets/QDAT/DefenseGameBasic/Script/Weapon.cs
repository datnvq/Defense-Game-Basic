using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace QDAT.DefenseBasic
{
    public class Weapon : MonoBehaviour
    {
        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Const.ENEMY_TAG))
            {
                Enemy enemy = collision.GetComponent<Enemy>();
                if (enemy)
                {
                    enemy.Die();
                }
            }
        }
    }
}


