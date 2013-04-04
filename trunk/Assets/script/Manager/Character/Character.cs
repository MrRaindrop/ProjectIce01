using UnityEngine;
using System.Collections;

namespace Loop
{

    public class Character
    {

        // fields
        protected GameObject _gameObject;

        protected bool _isAlive;          // 是否还活着

        protected float _moveSpeed;     // 移动速度
        protected float _runSpeed;      // 跑步速度
        protected float _jumpSpeed;     // 跳跃速度

        // properties

        public GameObject GameObject {
            get { return _gameObject; }
            set { _gameObject = value; }
        }

        public bool IsAlive {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        public float MoveSpeed {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }

        public float RunSpeed {
            get { return _runSpeed; }
            set { _runSpeed = value; }
        }

        public float JumpSpeed {
            get { return _jumpSpeed; }
            set { _jumpSpeed = value; }
        }

        // methods

        // 攻击
        public virtual void Attack() {
            Debug.Log("Creature Attack!");
        }

        // 移动
        public virtual void Move() {
            Debug.Log("Creature Move!");
        }

        // 跳跃
        public virtual void Jump() {
            Debug.Log("Creature Jump!");
        }

        // 死亡
        public virtual void Die() {
            Debug.Log("Creature Die!");
        }

    }

}