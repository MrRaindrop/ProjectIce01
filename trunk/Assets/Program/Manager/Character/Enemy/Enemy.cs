using UnityEngine;
using System.Collections;

namespace Loop
{
    public class Enemy : Character {

        protected EnemyType _type;

        // method

        // ���캯����ͨ��ö��ֵ����
        public Enemy(EnemyType type, Vector3 pos) : base() {

            _type = type;

            _moveSpeed = CharacterConstants.ENEMY_BASE_MOVE_SPEED;
            _runSpeed = CharacterConstants.ENEMY_BASE_RUN_SPEED;
            _jumpSpeed = CharacterConstants.ENEMY_BASE_JUMP_SPEED;

            CalculateEnemyCapability();

            // TODO : ��prefabʵ����һ�������posλ�ò�attach����ʵ��
            // ����������ж�����������Ч�����ű����

        }

        // ���캯����ͨ��������Ź���
        public Enemy(int type, Vector3 pos)
            : base()
        {
            if (type < 0 || type >= CharacterConstants.ENEMY_TYPE_COUNT)
                Debug.LogError("Error : can't instantiate a enmey of type " + type);
            else
                _type = (EnemyType)type;

            _moveSpeed = CharacterConstants.ENEMY_BASE_MOVE_SPEED;
            _runSpeed = CharacterConstants.ENEMY_BASE_RUN_SPEED;
            _jumpSpeed = CharacterConstants.ENEMY_BASE_JUMP_SPEED;

            CalculateEnemyCapability();

            // TODO : ��prefabʵ����һ�������posλ�ò�attach����ʵ��
            // ����������ж�����������Ч�����ű����

        }

        // ���캯����ͨ������������
        public Enemy(string type, Vector3 pos)
            : base()
        {
            int i = CharacterManager.enemyType.IndexOf(type);

            if (i == -1)
                Debug.LogError("Error : can't instantiate a enemy of type " + type);
            else
                _type = (EnemyType)i;

            _moveSpeed = CharacterConstants.ENEMY_BASE_MOVE_SPEED;
            _runSpeed = CharacterConstants.ENEMY_BASE_RUN_SPEED;
            _jumpSpeed = CharacterConstants.ENEMY_BASE_JUMP_SPEED;

            CalculateEnemyCapability();

            // TODO : ��prefabʵ����һ�������posλ�ò�attach����ʵ��
            // ����������ж�����������Ч�����ű����
        }

        // ���㵱ǰ���绷���£� ������ĵ��˵�����ֵ
        protected virtual void CalculateEnemyCapability() {

            // TODO : ���㵱ǰ���绷���£� ������ĵ��˵�����ֵ

        }

    }

}
