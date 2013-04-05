using UnityEngine;
using System.Collections;

namespace Loop
{
    public static class CharacterManager
    {

        public static float playerBaseMoveSpeed = 10.0f;
        public static float playerBaseRunSpeed = 20.0f;
        public static float playerBaseJumpSpeed = 10.0f;

        public static float playerCurrentMoveSpeed = 10.0f;
        public static float playerCurrentRunSpeed = 20.0f;
        public static float playerCurrentJumpSpeed = 10.0f;


        // 根据环境数值计算角色能力值
        public static void CalculatePlayerCapability() {

            /* TODO : 根据环境计算 */

            // playerCurrentJumpSpeed = ...
            // playerCurrentMoveSpeed = ...
            // playerCurrentRunSpeed = ...

            Observer ob = GameObject.FindWithTag("Observer").GetComponent<Observer>();
            Player player = ob.GetCurrentPlayer();

            if (player != null) {
                player.MoveSpeed = playerCurrentMoveSpeed;
                player.RunSpeed = playerCurrentRunSpeed;
                player.JumpSpeed = playerCurrentJumpSpeed;
            }
        }

        // 保存数据
        public static void SaveCharacterData(){

            // 保存敌人及NPC数据

            // 保存角色数据
            SavePlayerInstanceData();

        }

        // 装载数据
        public static void LoadCharacterData(){

            // 装载敌人及NPC数据

            // 装载敌人数据
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

    }
}
