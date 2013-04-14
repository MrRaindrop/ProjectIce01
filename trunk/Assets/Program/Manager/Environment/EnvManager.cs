using UnityEngine;
using System.Collections;

namespace Loop
{

    public static class EnvManager
    {
        
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

        // 保存环境相关数据
        public static void SaveEnvData() {

            PlayerPrefs.SetFloat("gravity", gravity);
            PlayerPrefs.SetInt("currentGLevel", (int)currentGLevel);

        }

        // 装载环境相关数据
        public static void LoadEnvData() {

            gravity = PlayerPrefs.GetFloat("gravity");
            currentGLevel = (GravityLevel)PlayerPrefs.GetInt("currentGLevel");
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
