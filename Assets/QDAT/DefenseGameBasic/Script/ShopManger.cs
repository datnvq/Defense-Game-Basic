using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QDAT.DefenseBasic
{
    public class ShopManger : MonoBehaviour
    {
        public ShopItem[] items;
        

        void Start()
        {
            Init();
        }

        private void Init()
        {
            if (items == null || items.Length <= 0) return;

            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                string dataKey = Const.PLAYER_PREFIX_PREF + i;
                if (item != null)
                {
                    if(i == 0)
                    {
                        Pref.SetBool(dataKey, true);
                    }
                    else
                    {
                        if(!PlayerPrefs.HasKey(dataKey))
                        {
                            Pref.SetBool(dataKey, false);
                        }
                    }
                }
            }
        }
    }
}
