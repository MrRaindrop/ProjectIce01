using UnityEngine;
using System.Collections;

namespace Loop {

    public class Player : Character {

        public Player() {

            IsAlive = true;
            GameObject = GameObject.FindWithTag("Player");

            MoveSpeed = EnvManager.playerCurrentMoveSpeed;
            RunSpeed = EnvManager.playerCurrentRunSpeed;
            JumpSpeed = EnvManager.playerCurrentJumpSpeed;

        }

    }



}
