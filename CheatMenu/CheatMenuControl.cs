using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ModAPI;

namespace CheatMenu
{
    public class CheatMenuControl : Player
    {
        protected override void Update()
        {
            Vector3 position = this.playerNetwork.transform.position;
            if (position.y <= -100f)
            {
                AchievementHandler.UnlockAchievement(AchievementType.ach_diveDeep);
            }
            if ((UnityEngine.Object)this.soundManager != (UnityEngine.Object)null)
            {
                SoundManager obj = this.soundManager;
                Vector3 position2 = this.playerNetwork.transform.position;
                obj.SetOceanPlayerHeight(position2.y);
            }                       

            bool key = UnityEngine.Input.GetKey(KeyCode.LeftShift);
            bool key2 = UnityEngine.Input.GetKey(KeyCode.LeftControl);
            if (ModAPI.Input.GetButtonDown("Paint"))
            {
                this.playerInventory.AddItem("PaintBrush", 1);
                this.playerInventory.AddItem("Color_Red", 10000);
                this.playerInventory.AddItem("Color_Yellow", 10000);
                this.playerInventory.AddItem("Color_Blue", 10000);
                this.playerInventory.AddItem("Color_Black", 10000);
                this.playerInventory.AddItem("Color_White", 10000);            
                this.playerInventory.AddItem("Scrap", 10000);
                this.playerInventory.AddItem("Rope", 10000);
                this.playerInventory.AddItem("Thatch", 10000);
                this.playerInventory.AddItem("SeaVine", 10000);
                this.playerInventory.AddItem("Stone", 10000);
                this.playerInventory.AddItem("Plastic", 10000);
                this.playerInventory.AddItem("Plank", 10000);
                this.playerInventory.AddItem("MetalIngot", 10000);
                this.playerInventory.AddItem("Nail", 10000);                
            }
            if (ModAPI.Input.GetButtonDown("Items"))
            {
                this.playerInventory.AddItem("Hammer", 1);
                this.playerInventory.AddItem("Axe", 1);
                this.playerInventory.AddItem("Hook_Plastic", 1);
                this.playerInventory.AddItem("Seed_Flower_Black", 500);
                this.playerInventory.AddItem("Seed_Flower_White", 500);
                this.playerInventory.AddItem("Seed_Flower_Yellow", 500);
                this.playerInventory.AddItem("Seed_Flower_Blue", 500);
                this.playerInventory.AddItem("Seed_Flower_Red", 500);
                this.playerInventory.AddItem("Raw_Beet", 500);
                this.playerInventory.AddItem("Raw_Potato", 500);
                this.playerInventory.AddItem("Raw_Mackerel", 500);
                this.playerInventory.AddItem("Raw_Shark", 500);
                this.playerInventory.AddItem("Seed_Palm", 500);            
            }
            if (ModAPI.Input.GetButtonDown("StatFull"))
            {
                this.playerNetwork.Stats.stat_health.Value += 100f;
                this.playerNetwork.Stats.stat_thirst.Value += 100f;
                this.playerNetwork.Stats.stat_hunger.Value += 100f;
                this.playerNetwork.Stats.stat_oxygen.Value += 100f;                
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Delete))
            {
                this.playerInventory.Clear();
            }            

            //AzureSkyController
            AzureSkyController skyController = SingletonGeneric<GameManager>.Singleton.skyController;
                if (ModAPI.Input.GetButtonDown("TimeScale"))
                {
                    this.targetTimeScale += 10f;
                }
                else if (ModAPI.Input.GetButtonDown("TimeClear"))
                {
                    this.targetTimeScale -= 10f;
                }
                else if (ModAPI.Input.GetButtonDown("CameraPause"))
                {
                    if (Time.timeScale > 0f)
                    {
                        Time.timeScale = 0f;
                    }
                    else
                    {
                        this.targetTimeScale = 1f;
                        Time.timeScale = 1f;
                    }
                }
                else if (UnityEngine.Input.GetKeyDown(KeyCode.B))
                {
                    float azure_Timeline = skyController.Azure_Timeline;
                    azure_Timeline = ((!key) ? (azure_Timeline + 0.1f) : (azure_Timeline + 0.2f));
                    if (azure_Timeline >= 24f)
                    {
                        azure_Timeline -= 24f;
                    }
                    skyController.AzureSetTime(azure_Timeline, skyController.Azure_DayCycle);
                }
                else if (UnityEngine.Input.GetKeyDown(KeyCode.V))
                {
                    float azure_Timeline2 = skyController.Azure_Timeline;
                    azure_Timeline2 = ((!key) ? (azure_Timeline2 - 0.1f) : (azure_Timeline2 - 0.2f));
                    if (azure_Timeline2 <= 0f)
                    {
                        azure_Timeline2 += 24f;
                    }
                    skyController.AzureSetTime(azure_Timeline2, skyController.Azure_DayCycle);
                }
                this.targetTimeScale = Mathf.Clamp(this.targetTimeScale, 1f, 100f);
                if (Time.timeScale != 0f)
                {
                    Time.timeScale = Helper.Damp(Time.timeScale, this.targetTimeScale, 0.5f, Time.deltaTime);
                }
                if (ModAPI.Input.GetButtonDown("CursorLock"))
                {
                    this.SetMouseLookScripts(!this.mouseLookXScript.enabled);
                    Helper.SetCursorVisibleAndLockState(!Cursor.visible, (CursorLockMode)((Cursor.lockState == CursorLockMode.None) ? 1 : 0));
                }        
            base.Update();
        }
    }
}
