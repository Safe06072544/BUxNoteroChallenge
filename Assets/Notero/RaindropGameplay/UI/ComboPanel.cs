using UnityEngine;
using UnityEngine.UI;

namespace Notero.RaindropGameplay.UI
{
    public class ComboPanel : MonoBehaviour
    {
        public Image healthbar;
        public Image[] healthPoints;
        public Image BG; // Reference ของพื้นหลังเดิม
        public Image FadeBG; // Reference ของพื้นหลังที่ต้องการเปลี่ยน

        float health;
        float maxHealth = 110000;
        float lerpSpeed;

        void Start()
        {
            health = 0;
        }

        void HealthBarFiller()
        {
            healthbar.fillAmount = Mathf.Lerp(healthbar.fillAmount, health / maxHealth, lerpSpeed);

            for (int i = 0; i < healthPoints.Length; i++)
            {
                healthPoints[i].enabled = !DisplayHealthPoint(health, i);
            }
        }

        bool DisplayHealthPoint(float _health, int pointNumber)
        {
            return ((pointNumber * 3900) >= _health);
        }

        public void Damage(float damagePoints)
        {
            if (health > 0)
                health -= damagePoints;
        }

        public void Heal(float healingPoints)
        {
            health = healingPoints;
            if (health > maxHealth) health = maxHealth;

            lerpSpeed = 1f * Time.deltaTime;

            HealthBarFiller();

            if (maxHealth >= 110000)
            {
                BG.gameObject.SetActive(false); // ปิดการใช้งาน BG
                FadeBG.gameObject.SetActive(true); // เปิดการใช้งาน FadeBG
            }
        }
    }
}
