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
        private bool _isDead;

        private GameManager _gm;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
            _player = FindObjectOfType<Player>();
            _gm = FindObjectOfType<GameManager>();
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

            float distToPlayer = Vector2.Distance(_player.transform.position, transform.position);

            if (distToPlayer <= atkDistance)
            {
                _anim.SetBool(Const.ATTACK_ANIM, true);
                _rb.velocity = Vector2.zero;
            }
            else
            {
                _rb.velocity = new Vector2(-speed, _rb.velocity.y);
            }
        }

        public void Die()
        {
            if (IsComponentNull() || _isDead) return;

            _isDead = true;
            _anim.SetTrigger(Const.DEAD_ANIM);
            _rb.velocity = Vector2.zero;
            gameObject.layer = LayerMask.NameToLayer(Const.DEAD_ANIM);
            if(_gm != null)
            {
                _gm.Score++;
            }

            Destroy(gameObject, 2f);
        }
    }
}
