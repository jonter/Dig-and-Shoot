using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats 
{
    static float[] DAMAGE = {10, 20, 30, 45, 60, 80, 100, 130, 160, 200, 250};
    public static float GetDamage()
    {
        int level = PlayerPrefs.GetInt("damage");
        return DAMAGE[level];
    }

    static float[] FIRERATE = { 1.5f, 1.8f, 2.2f, 2.5f, 2.8f, 3.2f };

    public static float GetFireRate()
    {
        int level = PlayerPrefs.GetInt("firerate");
        return FIRERATE[level];
    }

    static float[] BASEHEALTH = { 100, 200, 350, 500, 700, 1000, 2000 };
    public static float GetBaseHealth()
    {
        int level = PlayerPrefs.GetInt("basehealth");
        return BASEHEALTH[level];
    }

    static float[] RELOADTIME = { 10000, 50, 45, 40, 35, 30};

    public static float GetReloadTime(string ID)
    {
        int level = PlayerPrefs.GetInt(ID);
        return RELOADTIME[level];
    }

    static float[] FASTSHOOTTIME = { 0, 3f, 4.5f, 6f, 7f, 8f };
    
    public static float GetFastShootTime()
    {
        int level = PlayerPrefs.GetInt("fastshootability");
        return FASTSHOOTTIME[level];
    }

    static float[] GHOSTTIME = { 0, 3.5f, 4.5f, 6f, 7f, 8f };

    public static float GetGhostTime()
    {
        int level = PlayerPrefs.GetInt("ghost");
        return GHOSTTIME[level];
    }

    static float[] FROSTTIME = { 0, 2.5f, 3.5f, 4.5f, 5.5f, 7f };

    public static float GetFrostTime()
    {
        int level = PlayerPrefs.GetInt("frost");
        return FROSTTIME[level];
    }

    static float[] BURSTDAMAGE = {0, 100, 250, 600, 1300, 2500, 4000, 5000};

    public static float GetBurstDamage()
    {
        int level = PlayerPrefs.GetInt("burst");
        return BURSTDAMAGE[level];
    }

}
