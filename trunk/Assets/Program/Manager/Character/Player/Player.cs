using UnityEngine;
using System.Collections;

namespace Loop {

    public class Player : Character {

        // 构造函数
        public Player() {

            IsAlive = true;
            AttachedGameObject = GameObject.FindWithTag("Player");

            MoveSpeed = CharacterManager.playerCurrentMoveSpeed;
            RunSpeed = CharacterManager.playerCurrentRunSpeed;
            JumpSpeed = CharacterManager.playerCurrentJumpSpeed;

        }

        // 切换世界
        public void SwitchToWorld(WorldName name) {
            
            if ((int)name < 0 || (int)name >= WorldConstants.WORLDS_NUM) {
                Debug.Log("Error : Switch World Failed - worldIndex out of range. World name: " + name);
                return;
            }

            AttachedGameObject.GetComponent<PlayerMove>().MoveToWorld(name);
        }

        // 保存角色数据
        public void  SaveData() {
            PlayerPrefsX.SetBool("isAlive", _isAlive);
            PlayerPrefsX.SetBool("isAvailable", _isAvailable);
            PlayerPrefsX.SetVector3("playerPosition", AttachedGameObject.transform.position);
        }

        // 装载角色数据
        public void  LoadData() {
            _isAlive = PlayerPrefsX.GetBool("isAlive");
            _isAvailable = PlayerPrefsX.GetBool("isAvailable");
        }

        // 恢复保存游戏时的主角位置
        public void RecoverPosition() {
            Vector3 pos = PlayerPrefsX.GetVector3("playerPosition");
            TranslateTo(pos);
        }

        // 移动主角到特定位置
        public void TranslateTo(Vector3 pos) {
            Vector3 dis = pos - _attachedGameObject.transform.position;
            _attachedGameObject.transform.Translate(dis, Space.World);
        }

        // 攻击
        public override void Attack() {
            Debug.Log("Player Attack!");
        }

        // 死亡
        public override void Die() {
            DisableInput();
            Debug.Log("Player Die!");

            // TODO ...
        }

        // 查看角色是否可以行动
        public override bool IsAvailable() {
            return _isAvailable;
        }

        // 禁止角色行动
        public override void DisableAct(){
            base.DisableAct();
            Debug.Log("-- Func : Player.DisableAct --");
        }

        // 恢复角色行动
        public override void EnableAct() {
            base.EnableAct();
            Debug.Log("-- Func : Player.EnableAct --");
        }

        // 是否响应玩家输入
        public bool IsInputAvailable() {
            return AttachedGameObject.GetComponent<PlayerMove>().IsInputAvailable();
        }

        // 不接受玩家输入
        public void DisableInput() {
            AttachedGameObject.GetComponent<PlayerMove>().DisableInput();
        }

        // 接受玩家输入
        public void EnableInput() {
            AttachedGameObject.GetComponent<PlayerMove>().EnableInput();
        }

    }

}
