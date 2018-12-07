using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace StaminaScript {
    public class Stamina : MonoBehaviour {
        public Rigidbody player;
        public float currStamina = 5.0f;
        public float maxStamina = 5.0f;

        private float staminaRegenTimer = 0.0f;

        private const float staminaDecreasePerFrame = 3.0f;
        private const float staminaIncreasePerFrame = 1.0f;
        private const float staminaTimeToRegen = 1.0f;

        private void Update()
        {
                Debug.Log("You're running");
                if (currStamina <= 0)
                {
                    return;
                }
                else
                {
                    currStamina = Mathf.Clamp(currStamina - (staminaDecreasePerFrame * Time.deltaTime), 0.0f, maxStamina);
                    staminaRegenTimer = 0.0f;
                }
             if (currStamina < maxStamina)
            {
                if (staminaRegenTimer >= staminaTimeToRegen)
                    currStamina = Mathf.Clamp(currStamina + (staminaIncreasePerFrame * Time.deltaTime), 0.0f, maxStamina);
                else
                    staminaRegenTimer += Time.deltaTime;
            }
        }
    }
}