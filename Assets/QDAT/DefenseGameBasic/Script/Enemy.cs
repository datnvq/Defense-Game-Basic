using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QDAT.DefenseBasic
{
    public class Enemy : MonoBehaviour, IComponentChecking
    {
        public float speed;
        public float atkDistance;
        private Animator _anim;
        private Rigidbody2D _rb;
        private Player _player;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
            _player = FindObjectOfType<Player>();
        }
        // Start is called before the first frame update
        void Start()
        {

        }
        public bool IsComponentNull()
        {
            return _anim == null || _rb == null || _player == null;
        }

        // Update is called once per frame
        void Update()
        {
            if(IsComponentNull()) return;

            if(Vector2.Distance(_player.transform.position, transform.position) <= atkDistance)
            {
                _anim.SetBool(Const.ATTACK_ANIM, true);
                _rb.velocity = Vector2.zero;
            }
            else
            {
                _rb.velocity = new Vector2(-speed, _rb.velocity.y);
            }
        }
    }
}
