using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QDAT.DefenseBasic
{
    public class ShopitemUI : MonoBehaviour
    {
        public Text priceTxt;
        public Image hud;
        public Button btn;

        public void UpdateUI(ShopItem item, int itemIdx)
        {
            if (item == null) return;

            if(hud != null)
            {
                hud.sprite = item.previewImg;
            }

            bool isUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIdx);
            if(isUnlocked)
            {
                if(Pref.curPlayerId == itemIdx)
                {
                    if(priceTxt != null)
                    {
                        priceTxt.text = "Active";
                    }
                }else if (priceTxt)
                {
                    priceTxt.text = "Owned";
                }
            }
            else
            {
                if(priceTxt)
                {
                    priceTxt.text = item.price.ToString();
                }
            }
        }
    }
}
