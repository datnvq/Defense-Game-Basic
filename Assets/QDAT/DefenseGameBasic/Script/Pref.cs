using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QDAT.DefenseBasic
{
    public static class Pref
    {
        public static int bestScore
        {
            set
            {
                int oldBestScore = PlayerPrefs.GetInt(Const.BEST_SCORE_PREF, 0);
                if(oldBestScore < value)
                {
                    PlayerPrefs.SetInt(Const.BEST_SCORE_PREF, value);
                }
            }
            get => PlayerPrefs.GetInt(Const.BEST_SCORE_PREF, 0);
        }
        public static int curPlayerId
        {
            set => PlayerPrefs.SetInt(Const.CUR_PLAYER_ID_PREF, value);
            get => PlayerPrefs.GetInt(Const.CUR_PLAYER_ID_PREF, 0);
        }

        public static int coins 
        { 
            get => PlayerPrefs.GetInt(Const.COIN_PREF, 0);
            set => PlayerPrefs.SetInt(Const.COIN_PREF, value);
        }

        public static float musicVol
        {
            get => PlayerPrefs.GetFloat(Const.MUSIC_VOL_PREF, 0);
            set => PlayerPrefs.SetFloat(Const.MUSIC_VOL_PREF, value);
        }
        public static float soundVol
        {
            get => PlayerPrefs.GetFloat(Const.SOUND_VOL_PREF, 0);
            set => PlayerPrefs.SetFloat(Const.SOUND_VOL_PREF, value);
        }
        public static void SetBool(string key, bool value)
        {
            if(value)
            {
                PlayerPrefs.SetInt(key, 1);
            }else
            {
                PlayerPrefs.SetInt(key, 0);
            }
        }
        public static bool GetBool(string key)
        {
            int check = PlayerPrefs.GetInt(key);
            return check == 1;
        }
    }

}

