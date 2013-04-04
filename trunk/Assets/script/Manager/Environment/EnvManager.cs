using UnityEngine;
using System.Collections;

namespace Loop
{

    public static class EnvManager
    {
        public static float playerBaseMoveSpeed = 10.0f;
        public static float playerBaseRunSpeed = 20.0f;
        public static float playerBaseJumpSpeed = 10.0f;

        public static float playerCurrentMoveSpeed = 10.0f;
        public static float playerCurrentRunSpeed = 20.0f;
        public static float playerCurrentJumpSpeed = 10.0f;
        
        public static float gravity = 20.0f;
        public static GravityLevel currentGLevel = GravityLevel.Level2;


        public static float[] gravityLevelArray = new float[6]{
            EnvConstants.G_LEVEL_0,
            EnvConstants.G_LEVEL_1,
            EnvConstants.G_LEVEL_2,
            EnvConstants.G_LEVEL_3,
            EnvConstants.G_LEVEL_4,
            EnvConstants.G_LEVEL_5
        };

        // 设置当前的g等级
        public static void SetGravityLevel(int gravityLevel) {
            if (gravityLevel < EnvConstants.G_LEVEL_MIN || gravityLevel > EnvConstants.G_LEVEL_MAX) {
                Debug.Log("in SetGravityLevel : gravityLevel out of range.");
                return;
            }

            gravity = gravityLevelArray[gravityLevel];
            currentGLevel = (GravityLevel)gravityLevel;
        }

        // 获取当前的g等级
        public static int GetCurrentGLevel() {
            return (int)currentGLevel;
        }

        // 提高g等级，成功返回当前g等级，失败返回-1
        public static int RaiseGLevel() {
            if((int)currentGLevel != EnvConstants.G_LEVEL_MAX){
                currentGLevel++;
                return (int)currentGLevel;
            } else
                return -1;
        }

        // 降低g等级，成功返回当前g等级，失败返回-1
        public static int LowerGLevel() {
            if ((int)currentGLevel != EnvConstants.G_LEVEL_MIN) {
                currentGLevel--;
                return (int)currentGLevel;
            }
            else
                return -1;
        }

        // 根据环境数值计算角色能力值
        public static void CalculatePlayerCapability(){

            /* TODO : 根据环境计算 */

            // playerCurrentJumpSpeed = ...
            // playerCurrentMoveSpeed = ...
            // playerCurrentRunSpeed = ...

            Observer ob = GameObject.FindWithTag("Observer").GetComponent<Observer>();
            Player p = ob.GetCurrentPlayer();
            if (p != null) {
                p.MoveSpeed = playerCurrentMoveSpeed;
                p.RunSpeed = playerCurrentRunSpeed;
                p.JumpSpeed = playerCurrentJumpSpeed;
            }

        }
    }

    public enum GravityLevel{
        Level0 = 0,
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        Level4 = 4,
        Level5 = 5
    };
}
