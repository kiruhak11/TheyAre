using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace inProlog.scripts
{
    public class starter : MonoBehaviour
    {
        public static bool ending = false;
        private bool teleport = false;
        private float endingtimer = 2;
        public bool isNewGame;
        public bool sirenBool = false;
        public GameObject startPanel;
        public GameObject secondPanel;
        public GameObject goNext;
        public GameObject goNextMore;
        public GameObject hud;
        public GameObject blackPanel;
        public float firstTimerLog = 3;

        public GameObject player;
        private PlayerCam playerCam;

        public GameObject cameraPlayer;
        private PlayerMovement playerMovement;

        [Header("Light")]
        public AudioSource siren;
        public AudioSource monster;
        public GameObject lig1GameObject;
        public GameObject lig2GameObject;
        public GameObject lig3GameObject;
        public Light lig1;
        public Light lig2;
        public Light lig3;
        public Light lig4;
        public Light lig5;
        public Light lig6;
        public Light lig7;
        public float ligTimer = 3;
        public float ligTimer2 = 5;

        private void Start()
        {
            playerCam = cameraPlayer.GetComponent<PlayerCam>();
            playerMovement = player.GetComponent<PlayerMovement>();
            playerMovement.walkSpeed = 3f;
            if (!isNewGame)
            {
                playerCam.GetComponent<PlayerCam>().enabled = false;
                playerMovement.GetComponent<PlayerMovement>().enabled = false;
                hud.SetActive(false);
                goNext.SetActive(false);
            }
        }

        void Update(){
            if (!isNewGame) {
                firstTimerLog -= 1 * Time.deltaTime;
                startPanel.SetActive(true);
                //при работе 1ой активити
                if (firstTimerLog <= 0 && startPanel.activeInHierarchy) {
                    goNext.SetActive(true);
                    if (Input.GetKey(KeyCode.Space) && goNext.activeInHierarchy) {
                        goNext.SetActive(false);
                        startPanel.SetActive(false);
                        secondPanel.SetActive(true);
                        firstTimerLog = 3f;
                    }
                }

                //при работе 2 активити
                if (firstTimerLog <= 0 && secondPanel.activeInHierarchy)
                {
                    goNextMore.SetActive(true);
                }
            }
            if (goNextMore.activeInHierarchy && Input.GetKey(KeyCode.Space)) {
                isNewGame = true;
                hud.SetActive(true);
                secondPanel.SetActive(false);
                startPanel.SetActive(false);
                playerCam.GetComponent<PlayerCam>().enabled = true;
                playerMovement.GetComponent<PlayerMovement>().enabled = true;
            }
            if (isNewGame)
            {
                hud.SetActive(true);
                secondPanel.SetActive(false);
                startPanel.SetActive(false);
                player.SetActive(true);
                playerCam.GetComponent<PlayerCam>().enabled = true;
                playerMovement.GetComponent<PlayerMovement>().enabled = true;
            }
            if(lig1GameObject.activeInHierarchy && lig2GameObject.activeInHierarchy && lig3GameObject.activeInHierarchy)
            {
                if(ligTimer != 0)
                    ligTimer -= 1 * Time.deltaTime;
                if (ligTimer <= 0)
                {
                    lig1.color = Color.red;
                    lig2.color = Color.red;
                    lig3.color = Color.red;
                    lig4.color = Color.red;
                    lig5.color = Color.red;
                    lig6.color = Color.red;
                    lig7.color = Color.red;
                    if (!sirenBool)
                    {
                        sirenBool = true;
                        siren.Play();
                        monster.Play();
                    }

                    if (sirenBool)
                    {
                        if(ligTimer2 != 0)
                            ligTimer2 -= 1 * Time.deltaTime;
                        if (ligTimer2 <= 0)
                        {
                            blackPanel.SetActive(true);
                            ending = true;
                            if (!teleport)
                            {
                                player.transform.position = new Vector3(66f, 10.6f, 33.3f);
                                teleport = true;
                            }
                        }
                    }
                }
            }

            if (ending)
            {
                if(endingtimer != 0)
                    endingtimer -= 1 * Time.deltaTime;
                if (endingtimer <= 0)
                {
                    blackPanel.SetActive(false);
                }
            }
        }
    }
}
