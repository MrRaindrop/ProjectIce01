using UnityEngine;
using System.Collections;

namespace Loop
{
    public class Enemy : Character {

        protected EnemyType _type;

        // method

        // 构造函数，通过枚举值构造
        public Enemy(EnemyType type, Vector3 pos) : base() {

            _type = type;

            _moveSpeed = CharacterConstants.ENEMY_BASE_MOVE_SPEED;
            _runSpeed = CharacterConstants.ENEMY_BASE_RUN_SPEED;
            _jumpSpeed = CharacterConstants.ENEMY_BASE_JUMP_SPEED;

            CalculateEnemyCapability();

            // TODO : 从prefab实例化一个物件到pos位置并attach到本实例
            // 并给其挂载行动、动画、特效三个脚本组件

        }

        // 构造函数，通过类型序号构造
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

            // TODO : 从prefab实例化一个物件到pos位置并attach到本实例
            // 并给其挂载行动、动画、特效三个脚本组件

        }

        // 构造函数，通过中文名构造
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

            // TODO : 从prefab实例化一个物件到pos位置并attach到本实例
            // 并给其挂载行动、动画、特效三个脚本组件
        }

        // 计算当前世界环境下， 该种类的敌人的能力值
        protected virtual void CalculateEnemyCapability() {

            // TODO : 计算当前世界环境下， 该种类的敌人的能力值

        }

    }

}
