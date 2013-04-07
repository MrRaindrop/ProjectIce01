using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Loop
{
    public static class CharacterManager
    {

        // player

        // ��ɫ��������ֵ
        public static float playerBaseMoveSpeed = 10.0f;
        public static float playerBaseRunSpeed = 20.0f;
        public static float playerBaseJumpSpeed = 10.0f;

        // ��ɫ��ǰ����ֵ
        public static float playerCurrentMoveSpeed = 10.0f;
        public static float playerCurrentRunSpeed = 20.0f;
        public static float playerCurrentJumpSpeed = 10.0f;

        // Enemy

        // ��������
        private static string[] _enemyType = new string[CharacterConstants.ENEMY_TYPE_COUNT] {
            "ʷ��ķ", "�粼��", "����սʿ", "ħŮ"
        };
        public static List<string> enemyType = new List<string>(_enemyType);

        // Enemyʵ���������б�
        private static List<Enemy> _enemyInstanceList = new List<Enemy>();

        // Npc
        


        // methods

        // ���ݻ�����ֵ�����ɫ����ֵ
        public static void CalculatePlayerCapability()
        {

            /* TODO : ���ݻ������� */

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

        // �ڵ�ͼ������ĳ�����͵ĵ���ʵ��
        public static void AddEnemyInstance(EnemyType type, Vector3 pos) {

            Enemy enemy = new Enemy(type, pos);
            _enemyInstanceList.Add(enemy);

        }

        // �ڵ�ͼ������ĳ���������Ƶĵ���ʵ��������ʵ���ڽ�ɫ�������ĵ����б�������
        public static int AddEnemyInstance(string type, Vector3 pos) {

            Enemy enemy = new Enemy(type, pos);
            int index = _enemyInstanceList.Count;
            _enemyInstanceList.Add(enemy);
            enemy.AttachedGameObject.GetComponent<EnemyAI>().EnemyIndex = index;
            return index;
        }

        // �ڵ�ͼ������ĳ��������ŵĵ���ʵ��������ʵ���ڽ�ɫ�������ĵ����б�������
        public static int AddEnemyInstance(int type, Vector3 pos) {

            Enemy enemy = new Enemy(type, pos);
            int index = _enemyInstanceList.Count;
            _enemyInstanceList.Add(enemy);
            enemy.AttachedGameObject.GetComponent<EnemyAI>().EnemyIndex = index;
            return index;

        }
        
        // ɾ��ָ��ʵ����ŵĵ���ʵ��
        public static void RemoveEnemyInstance(int index) {

            if (index < 0 || index >= _enemyInstanceList.Count)
                throw new System.IndexOutOfRangeException("@ CharacterManager.RemoveEnemyInstance()");
            _enemyInstanceList.RemoveAt(index);

        }

        // ��ȡָ����ŵĵ���ʵ��
        public static Enemy GetEnemyInstance(int index) {

            if (index < 0 || index >= _enemyInstanceList.Count)
                throw new System.IndexOutOfRangeException("@ CharacterManager.RemoveEnemyInstance()");
            return _enemyInstanceList[index];

        }


        // ��������
        public static void SaveCharacterData(){

            // ������˼�NPC����


            // ������������
            SavePlayerInstanceData();

        }

        // װ������
        public static void LoadCharacterData(){

            // װ�ص��˼�NPC����

            // װ����������
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

        // װ����Ϸʱ�ָ�����ʱ���ǵ�λ��
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
