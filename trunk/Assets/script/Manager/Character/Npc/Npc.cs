using UnityEngine;
using System.Collections;

namespace Loop {

    public class Npc : Character {

        protected string _name;
        
        public Npc(string name) : base()  {

            _name = name;
            _moveSpeed = CharacterConstants.NPC_BASE_MOVE_SPEED;
            _runSpeed = CharacterConstants.NPC_BASE_RUN_SPEED;
            _jumpSpeed = CharacterConstants.NPC_BASE_JUMP_SPEED;

        }

        public Npc(string name,
            float moveSpeed,
            float runSpeed = CharacterConstants.NPC_BASE_RUN_SPEED,
            float jumpSpeed = CharacterConstants.NPC_BASE_JUMP_SPEED) : base()
        {
            _name = name;
            _moveSpeed = moveSpeed;
            _runSpeed = runSpeed;
            _jumpSpeed = jumpSpeed;
        }

        public void Talk() {

            // TODO : NPC¶Ô»°
        }

    }

}