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

        // ��ʼ�����е�Flag��־��ȫ������Ϊfalse
        public static void InitFlagArray() {

            Debug.Log("-- Func : InitFlagArray --");

            _flagArray = new bool[FlagConstants.TOTAL_NUM];

            for (int i = 0; i < FlagConstants.TOTAL_NUM; i++) {
                ResetFlag(i);
            }
        }

        // ��ȡ�ض�Flag��ֵ
        public static bool GetFlag(int flagIndex) {
            return _flagArray[flagIndex];
        }

        // �����ض���FlagΪtrue
        public static void SetFlag(int flagIndex)
        {
            _flagArray[flagIndex] = true;
        }

        // �����ض���FlagΪfalse
        public static void ResetFlag(int flagIndex)
        {
            _flagArray[flagIndex] = false;
        }

        // ��ת�ض���Flag��ֵ
        public static void ReverseFlag(int flagIndex) {
            _flagArray[flagIndex] = !_flagArray[flagIndex];
        }

        // �����Ѿ������Flags�����Ƿ��������Ե�flags(flagsToTest)һ��
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
