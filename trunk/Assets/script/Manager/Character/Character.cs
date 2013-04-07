using UnityEngine;
using System.Collections;

namespace Loop
{

    public class Character
    {

        // fields
        protected GameObject _attachedGameObject;

        protected bool _isAlive;          // 是否还活着
        protected bool _isAvailable;

        protected float _moveSpeed;     // 移动速度
        protected float _runSpeed;      // 跑步速度
        protected float _jumpSpeed;     // 跳跃速度

        // properties

        public GameObject AttachedGameObject {
            get { return _attachedGameObject; }
            set { _attachedGameObject = value; }
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

        // 构造函数
        public Character() {
            _attachedGameObject = null;
            _isAlive = false;
            _isAvailable = false;
        }

        ~Character() {

            MessageManager.SendMessage(MessageType.DestroyGameObject, delegate() { 
                GameObject.Destroy(this._attachedGameObject);
            });

        }

        // 连接物件（将对应物件实例的引用存到本角色实例）
        protected void AttachTo(GameObject go) {
            if (go != null)
                _attachedGameObject = go;
            else
                throw new System.NullReferenceException("@ Character.AttachTo()");
        }

        // 获取绝对坐标
        public virtual Vector3 GetPosition() {
            return AttachedGameObject.transform.position;
        }

        // 获取相对当前世界的坐标
        public virtual Vector3 GetRelativePosition() {
            return AttachedGameObject.transform.position - WorldManager.GetCurrentWorld().WorldPos;
        }

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
            _isAlive = false;

            // TODO...
        }

        // 查看是否可以行动
        public virtual bool IsAvailable(){
            // TODO ...
            return _isAvailable;
        }

        // 禁止行动
        public virtual void DisableAct() {
            _isAvailable = false;
        }

        // 恢复行动
        public virtual void EnableAct() {
            _isAvailable = true;
        }

    }

}