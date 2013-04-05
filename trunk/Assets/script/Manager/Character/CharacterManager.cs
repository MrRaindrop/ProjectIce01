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


        // ���ݻ�����ֵ�����ɫ����ֵ
        public static void CalculatePlayerCapability() {

            /* TODO : ���ݻ������� */

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

        // ��������
        public static void SaveCharacterData(){

            // ������˼�NPC����

            // �����ɫ����
            SavePlayerInstanceData();

        }

        // װ������
        public static void LoadCharacterData(){

            // װ�ص��˼�NPC����

            // װ�ص�������
            LoadPlayerInstanceData();

        }

        // ������Ϸ��ɫ����
        private static void SavePlayerInstanceData() {
            Observer ob = GameObject.FindWithTag("Observer").GetComponent<Observer>();
            if (!ob) {
                Debug.LogError("Error: Can't find Observer @ CharacterManager.LoadPlayerInstance()");
                return;
            }
            Player player = ob.GetCurrentPlayer();
            player.SaveData();

        }

        // װ����Ϸʱ�����齨��ɫ����
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
