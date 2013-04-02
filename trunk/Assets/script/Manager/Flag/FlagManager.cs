using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Loop
{

    public static class FlagManager {
        
        // fields
        
        private static bool[] _flagArray;


        // properties

        public static bool[] FlagArray {
            get { return _flagArray; }
            set { _flagArray = value; }
        }

        // methods

        // 初始化所有的Flag标志，全部设置为false
        public static void InitFlagArray() {

            Debug.Log("-- Func : InitFlagArray --");

            _flagArray = new bool[FlagConstants.TOTAL_NUM];

            for (int i = 0; i < FlagConstants.TOTAL_NUM; i++) {
                ResetFlag(i);
            }
        }

        // 获取特定Flag的值
        public static bool GetFlag(int flagIndex) {
            return _flagArray[flagIndex];
        }

        // 设置特定的Flag为true
        public static void SetFlag(int flagIndex)
        {
            _flagArray[flagIndex] = true;
        }

        // 设置特定的Flag为false
        public static void ResetFlag(int flagIndex)
        {
            _flagArray[flagIndex] = false;
        }

        // 反转特定的Flag的值
        public static void ReverseFlag(int flagIndex) {
            _flagArray[flagIndex] = !_flagArray[flagIndex];
        }

        // 测试已经保存的Flags数组是否与欲测试的flags(flagsToTest)一致
        public static bool TestFlags(bool[] flagsToTest) {
            for (int i = 0; i < Loop.FlagConstants.TOTAL_NUM; i++) {
                if (flagsToTest[i] == true && _flagArray[i] == true)
                    continue;
                else
                    return false;
            }
            return true;
        }

    }

    

}
