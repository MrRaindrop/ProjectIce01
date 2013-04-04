using UnityEngine;
using System.Collections;

namespace Loop
{

    public class Character
    {

        // fields
        protected GameObject _gameObject;

        protected bool _isAlive;          // �Ƿ񻹻���

        protected float _moveSpeed;     // �ƶ��ٶ�
        protected float _runSpeed;      // �ܲ��ٶ�
        protected float _jumpSpeed;     // ��Ծ�ٶ�

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

        // ����
        public virtual void Attack() {
            Debug.Log("Creature Attack!");
        }

        // �ƶ�
        public virtual void Move() {
            Debug.Log("Creature Move!");
        }

        // ��Ծ
        public virtual void Jump() {
            Debug.Log("Creature Jump!");
        }

        // ����
        public virtual void Die() {
            Debug.Log("Creature Die!");
        }

    }

}