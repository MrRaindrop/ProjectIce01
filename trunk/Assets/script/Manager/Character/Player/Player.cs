using UnityEngine;
using System.Collections;

namespace Loop {

    public class Player : Character {

        // ���캯��
        public Player() {

            IsAlive = true;
            AttachedGameObject = GameObject.FindWithTag("Player");

            MoveSpeed = CharacterManager.playerCurrentMoveSpeed;
            RunSpeed = CharacterManager.playerCurrentRunSpeed;
            JumpSpeed = CharacterManager.playerCurrentJumpSpeed;

        }

        // �л�����
        public void SwitchToWorld(WorldName name) {
            
            if ((int)name < 0 || (int)name >= WorldConstants.WORLDS_NUM) {
                Debug.Log("Error : Switch World Failed - worldIndex out of range. World name: " + name);
                return;
            }

            AttachedGameObject.GetComponent<PlayerMove>().MoveToWorld(name);
        }

        // �����ɫ����
        public void  SaveData() {
            PlayerPrefsX.SetBool("isAlive", _isAlive);
            PlayerPrefsX.SetBool("isAvailable", _isAvailable);
        }

        // װ�ؽ�ɫ����
        public void  LoadData() {
            _isAlive = PlayerPrefsX.GetBool("isAlive");
            _isAvailable = PlayerPrefsX.GetBool("isAvailable");
        }

        // ����
        public override void Attack() {
            Debug.Log("Player Attack!");
        }

        // ����
        public override void Die() {
            DisableInput();
            Debug.Log("Player Die!");

            // TODO ...
        }

        // �鿴��ɫ�Ƿ�����ж�
        public override bool IsAvailable() {
            return _isAvailable;
        }

        // ��ֹ��ɫ�ж�
        public override void DisableAct(){
            base.DisableAct();
            Debug.Log("-- Func : Player.DisableAct --");
        }

        // �ָ���ɫ�ж�
        public override void EnableAct() {
            base.EnableAct();
            Debug.Log("-- Func : Player.EnableAct --");
        }

        // �Ƿ���Ӧ�������
        public bool IsInputAvailable() {
            return AttachedGameObject.GetComponent<PlayerMove>().IsInputAvailable();
        }

        // �������������
        public void DisableInput() {
            AttachedGameObject.GetComponent<PlayerMove>().DisableInput();
        }

        // �����������
        public void EnableInput() {
            AttachedGameObject.GetComponent<PlayerMove>().EnableInput();
        }

    }

}
