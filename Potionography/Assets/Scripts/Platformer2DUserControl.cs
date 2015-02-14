using UnityEngine;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof (PlatformerCharacter2D))]

    public class Platformer2DUserControl : MonoBehaviour
    {
		Player player;
        private PlatformerCharacter2D character;
        private bool jump;
		private bool shoot = false;

		void Start()
		{
			player = GetComponent<Player>();
		}

        private void Awake()
        {
            character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if(!jump)
            // Read the jump input in Update so button presses aren't missed.
            jump = Input.GetButtonDown("Jump");
        }

        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = Input.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            character.Move(h, crouch, jump);
            jump = false;

			bool shootKey = Input.GetKey (KeyCode.LeftAlt);
			if (shootKey) 
			{
				if (!shoot)
				{
					player.Shoot();
				}
				shoot = true;
			}
			else
			{
				shoot = false;
			}
        }
    }
}