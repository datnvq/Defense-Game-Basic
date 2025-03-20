using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QDAT.DefenseBasic
{
    public class Player : MonoBehaviour
    {
        public float atkRate;
        private Animator _anim;
        private float _curAtkRate;
        private bool _isAttacked;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _curAtkRate = atkRate;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_isAttacked)
            {
                if (_anim != null)
                {
                    _anim.SetBool(Const.ATTACK_ANIM, true);
                }
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
            if (_anim)
            {
                _anim.SetBool(Const.ATTACK_ANIM, false);
            }
        }
    }
}
