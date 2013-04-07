using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Loop
{
    public static class CharacterManager
    {

        // player

        // 角色基础能力值
        public static float playerBaseMoveSpeed = 10.0f;
        public static float playerBaseRunSpeed = 20.0f;
        public static float playerBaseJumpSpeed = 10.0f;

        // 角色当前能力值
        public static float playerCurrentMoveSpeed = 10.0f;
        public static float playerCurrentRunSpeed = 20.0f;
        public static float playerCurrentJumpSpeed = 10.0f;

        // Enemy

        // 敌人种类
        private static string[] _enemyType = new string[CharacterConstants.ENEMY_TYPE_COUNT] {
            "史莱姆", "哥布林", "骷髅战士", "魔女"
        };
        public static List<string> enemyType = new List<string>(_enemyType);

        // Enemy实例化对象列表
        private static List<Enemy> _enemyInstanceList = new List<Enemy>();

        // Npc
        


        // methods

        // 根据环境数值计算角色能力值
        public static void CalculatePlayerCapability()
        {

            /* TODO : 根据环境计算 */

            // playerCurrentJumpSpeed = ...
            // playerCurrentMoveSpeed = ...
            // playerCurrentRunSpeed = ...

            Observer ob = GameObject.FindWithTag("Observer").GetComponent<Observer>();
            Player player = ob.GetCurrentPlayer();

            if (player != null)
            {
                player.MoveSpeed = playerCurrentMoveSpeed;
                player.RunSpeed = playerCurrentRunSpeed;
                player.JumpSpeed = playerCurrentJumpSpeed;
            }
        }

        // 在地图上增加某种类型的敌人实例
        public static void AddEnemyInstance(EnemyType type, Vector3 pos) {

            Enemy enemy = new Enemy(type, pos);
            _enemyInstanceList.Add(enemy);

        }

        // 在地图上增加某种类型名称的敌人实例，返回实例在角色管理器的敌人列表里的序号
        public static int AddEnemyInstance(string type, Vector3 pos) {

            Enemy enemy = new Enemy(type, pos);
            int index = _enemyInstanceList.Count;
            _enemyInstanceList.Add(enemy);
            enemy.AttachedGameObject.GetComponent<EnemyAI>().EnemyIndex = index;
            return index;
        }

        // 在地图上增加某种类型序号的敌人实例，返回实例在角色管理器的敌人列表里的序号
        public static int AddEnemyInstance(int type, Vector3 pos) {

            Enemy enemy = new Enemy(type, pos);
            int index = _enemyInstanceList.Count;
            _enemyInstanceList.Add(enemy);
            enemy.AttachedGameObject.GetComponent<EnemyAI>().EnemyIndex = index;
            return index;

        }
        
        // 删除指定实例序号的敌人实例
        public static void RemoveEnemyInstance(int index) {

            if (index < 0 || index >= _enemyInstanceList.Count)
                throw new System.IndexOutOfRangeException("@ CharacterManager.RemoveEnemyInstance()");
            _enemyInstanceList.RemoveAt(index);

        }

        // 获取指定序号的敌人实例
        public static Enemy GetEnemyInstance(int index) {

            if (index < 0 || index >= _enemyInstanceList.Count)
                throw new System.IndexOutOfRangeException("@ CharacterManager.RemoveEnemyInstance()");
            return _enemyInstanceList[index];

        }


        // 保存数据
        public static void SaveCharacterData(){

            // 保存敌人及NPC数据


            // 保存主角数据
            SavePlayerInstanceData();

        }

        // 装载数据
        public static void LoadCharacterData(){

            // 装载敌人及NPC数据

            // 装载主角数据
            LoadPlayerInstanceData();

        }

        // 保存游戏角色数据
        private static void SavePlayerInstanceData() {
            Observer ob = GameObject.FindWithTag("Observer").GetComponent<Observer>();
            if (!ob) {
                Debug.LogError("Error: Can't find Observer @ CharacterManager.LoadPlayerInstance()");
                return;
            }
            Player player = ob.GetCurrentPlayer();
            player.SaveData();

        }

        // 装载游戏时重新组建角色对象
        private static void LoadPlayerInstanceData() {
            Observer ob = GameObject.FindWithTag("Observer").GetComponent<Observer>();
            if (!ob) {
                Debug.LogError("Error: Can't find Observer @ CharacterManager.LoadPlayerInstance()");
                return;
            }
            Player player = ob.GetCurrentPlayer();
            if (player == null)
                throw new System.NullReferenceException(
                    "ob._currentPlayer is missing @ CharacterManager.LoadPlayerInstance()");

            player.LoadData();
        }

        // 装载游戏时恢复保存时主角的位置
        public static void RecoverPlayerPosition() {
            Observer ob = GameObject.FindWithTag("Observer").GetComponent<Observer>();
            if (!ob)
            {
                Debug.LogError("Error: Can't find Observer @ CharacterManager.LoadPlayerInstance()");
                return;
            }
            Player player = ob.GetCurrentPlayer();
            if (player == null)
                throw new System.NullReferenceException(
                    "ob._currentPlayer is missing @ CharacterManager.LoadPlayerInstance()");
            player.RecoverPosition();
        }

    }
}
