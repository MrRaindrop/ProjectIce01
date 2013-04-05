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

            if (player != null)
            {
                player.MoveSpeed = playerCurrentMoveSpeed;
                player.RunSpeed = playerCurrentRunSpeed;
                player.JumpSpeed = playerCurrentJumpSpeed;
            }

        }

    }
}
