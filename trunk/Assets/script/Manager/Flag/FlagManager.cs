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
        public static bool TestFlags(bool[] flagsToTest, bool[] flagsValueToTest) {
            for (int i = 0; i < Loop.FlagConstants.TOTAL_NUM; i++) {
                if (flagsToTest[i] && flagsValueToTest[i] == _flagArray[i])
                    continue;
                else if (!flagsToTest[i])
                    continue;
                else
                    return false;
            }
            return true;
        }

        // �����־����
        public static void SaveFlagData() {

            Loop.PlayerPrefsX.SetBoolArray("flagArray", _flagArray);

        }

        // װ�ر�־����
        public static void LoadFlagData() {

            _flagArray = Loop.PlayerPrefsX.GetBoolArray("flagArray", false, (int)FlagConstants.TOTAL_NUM);

        }

    }

    

}
