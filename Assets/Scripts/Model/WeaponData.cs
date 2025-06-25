using System;

namespace Model

{
    [Serializable]
    public class WeaponData
    {
        public int id;
        public string name;
        public string avatar;
        public int grade;
        public float damage;
        public int isLong;
        public int range;
        public float critical_strikes_multiple;
        public float critical_strikes_prabability;
        public float cooling;
        public int repel;
        public string weapon_describe;


    }
}