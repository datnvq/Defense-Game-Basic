using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QDAT.DefenseBasic
{
    public class Player : MonoBehaviour, IComponentChecking
    {
        public float atkRate;
        private Animator _anim;
        private float _curAtkRate;
        private bool _isAttacked;
        private bool _isDead;
        private GameManager _gm;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _curAtkRate = atkRate;
            _isDead = false;
            _gm = FindObjectOfType<GameManager>();
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        public bool IsComponentNull()
        {
            return _anim == null || _gm == null;
        }

        // Update is called once per frame
        void Update()
        {
            if (IsComponentNull()) return;
            if (Input.GetMouseButtonDown(0) && !_isAttacked)
            {
                _anim.SetBool(Const.ATTACK_ANIM, true);
                _isAttacked = true;
            }

            if (_isAttacked)
            {
                _curAtkRate -= Time.deltaTime;
                if (_curAtkRate <= 0)
                {
                    _isAttacked = false;
                    _curAtkRate = atkRate;
                }
            }
        }

        public void ResetAtkAnim()
        {
            if (IsComponentNull()) return;
            _anim.SetBool(Const.ATTACK_ANIM, false);
        }
        private void OnTriggerEnter2D(Collider2D colTarget)
        {
            if (IsComponentNull()) return;
            if (colTarget.CompareTag(Const.ENEMY_WEAPON_TAG) && !_isDead)
            {
                _anim.SetTrigger(Const.DEAD_ANIM);
                _isDead = true;
                gameObject.layer = LayerMask.NameToLayer(Const.DEAD_LAYER);
                _gm.Gameover();
            }
        }
    }
}
