using System;
using System.Collections.Generic;
using Model;
using UnityEngine;
using Random = System.Random;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public RoleData currentRole; //记录当前角色的数据
        public List<WeaponData> currentWeapons = new List<WeaponData>(); //记录当前武器的数据
        public DifficultyData currentDifficulty;//记录当前难度

        
        private void Awake()
        {
            Instance = this;
            
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        public object RandomOne<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return null;
            }

            Random random = new Random();
            int index = random.Next(0, list.Count);
            
            return list[index];

        }
    }
}