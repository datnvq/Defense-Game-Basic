using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;

namespace QDAT.DefenseBasic
{
    public class ShopDialog : Dialog, IComponentChecking
    {
        public Transform gridRoot;
        public ShopitemUI itemUIPrefab;

        private ShopManger _shopMng;
        private GameManager _gm;

        public override void Show(bool isShow)
        {
            base.Show(isShow);

            _shopMng = FindObjectOfType<ShopManger>();
            _gm = FindObjectOfType<GameManager>();

            UpdateUI();
        }

        public bool IsComponentNull()
        {
            return _shopMng == null || _gm == null || gridRoot == null;
        }

        private void UpdateUI()
        {
            if (IsComponentNull()) return;

            ClearChilds();

            var items = _shopMng.items;
            if (items == null || items.Length <= 0) return;

            for (int i = 0; i < items.Length; i++)
            {
                int idx = i;

                var item = items[idx];

                var itemUIClone = Instantiate(itemUIPrefab, Vector3.zero, Quaternion.identity);

                itemUIClone.transform.SetParent(gridRoot);
                itemUIClone.transform.localScale = Vector3.one;
                itemUIClone.transform.localPosition = Vector3.zero;

                itemUIClone.UpdateUI(item, idx);

                if(itemUIClone.btn != null)
                {
                    itemUIClone.btn.onClick.RemoveAllListeners();
                    itemUIClone.btn.onClick.AddListener(() => ItemEvent(item, idx));
                }
            }
        }

        private void ItemEvent(ShopItem item, int itemIdx)
        {
            if(item == null) return;

            bool isUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIdx);

            if(isUnlocked)
            {
                if (itemIdx != Pref.curPlayerId)
                {
                    Pref.curPlayerId = itemIdx;

                    _gm.ActivePlayer();
                    UpdateUI();
                }

            }
            else if(Pref.coins >= item.price)
            {
                Pref.coins -= item.price;
                Pref.SetBool(Const.PLAYER_PREFIX_PREF + itemIdx, true);
                Pref.curPlayerId = itemIdx;
                _gm.ActivePlayer();
                UpdateUI();
                if (_gm.guiMng)
                {
                    _gm.guiMng.UpdateMainCoins();
                }
            }
            else
            {
                Debug.Log("Ban khong du tien!");
            }
        }

        public void ClearChilds()
        {
            if(gridRoot == null || gridRoot.childCount <= 0) return;

            for(int i = 0;i < gridRoot.childCount; i++)
            {
                var child = gridRoot.GetChild(i);

                if(child != null)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}

