using UnityEngine;
using System.Collections;

namespace Loop {

    public class Player : Character {

        // ���캯��
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

        // ����
        public override void Attack() {
            Debug.Log("Player Attack!");
        }

        // ����
        public override void Die() {
            Debug.Log("Player Die!");
        }

        // �鿴��ɫ�Ƿ�����ж�
        public override bool IsAvailable() {
            return GameObject.GetComponent<PlayerMove>().IsPlayerAvailable();
        }

        // ��ֹ��ɫ�ж�
        public override void DisableAct() {
            GameObject.GetComponent<PlayerMove>().DisablePlayerAct();
        }

        // �ָ���ɫ�ж�
        public override void EnableAct() {
            GameObject.GetComponent<PlayerMove>().EnablePlayerAct();
        }

        // �Ƿ���Ӧ�������
        public bool IsInputAvailable() {
            return GameObject.GetComponent<PlayerMove>().IsInputAvailable();
        }

        // �������������
        public void DisableInput() {
            GameObject.GetComponent<PlayerMove>().DisableInput();
        }

        // �����������
        public void EnableInput() {
            GameObject.GetComponent<PlayerMove>().EnableInput();
        }

    }

}
