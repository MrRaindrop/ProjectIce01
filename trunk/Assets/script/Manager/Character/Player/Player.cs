using UnityEngine;
using System.Collections;

namespace Loop {

    public class Player : Character {

        // 构造函数
        public Player() {

            IsAlive = true;
            GameObject = GameObject.FindWithTag("Player");

            MoveSpeed = CharacterManager.playerCurrentMoveSpeed;
            RunSpeed = CharacterManager.playerCurrentRunSpeed;
            JumpSpeed = CharacterManager.playerCurrentJumpSpeed;

        }

        public void SwitchToWorld(WorldName name) {
            
            if ((int)name < 0 || (int)name >= WorldConstants.WORLDS_NUM) {
                Debug.Log("Error : Switch World Failed - worldIndex out of range. World name: " + name);
                return;
            }

            GameObject.GetComponent<PlayerMove>().MoveToWorld(name);
        }

        // 攻击
        public override void Attack() {
            Debug.Log("Player Attack!");
        }

        // 死亡
        public override void Die() {
            Debug.Log("Player Die!");
        }

        // 查看角色是否可以行动
        public override bool IsAvailable() {
            return GameObject.GetComponent<PlayerMove>().IsPlayerAvailable();
        }

        // 禁止角色行动
        public override void DisableAct() {
            GameObject.GetComponent<PlayerMove>().DisablePlayerAct();
        }

        // 恢复角色行动
        public override void EnableAct() {
            GameObject.GetComponent<PlayerMove>().EnablePlayerAct();
        }

        // 是否响应玩家输入
        public bool IsInputAvailable() {
            return GameObject.GetComponent<PlayerMove>().IsInputAvailable();
        }

        // 不接受玩家输入
        public void DisableInput() {
            GameObject.GetComponent<PlayerMove>().DisableInput();
        }

        // 接受玩家输入
        public void EnableInput() {
            GameObject.GetComponent<PlayerMove>().EnableInput();
        }

    }

}
