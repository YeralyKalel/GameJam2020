using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

[Serializable]
public class PlayerShooting : MonoBehaviour
{
    public GameObject temporaryBullet;

    public List<Spell> spells = new List<Spell>();
    private Dictionary<string, GameObject> spellObjects = new Dictionary<string, GameObject>();

    [HideInInspector]
    public SpellStyle spellStyle = SpellStyle.Empty; //By default

    public Transform rightHand;

    public void SetupSpelling(SpellStyle spellStyle)
    {
        spellObjects = new Dictionary<string, GameObject>();
        foreach (Spell spell in spells)
        {
            spellObjects.Add(spell.name, spell.prefab);
        }

        this.spellStyle = spellStyle;

        switch (spellStyle)
        {
            case SpellStyle.Fireball:
                maxBulletNumber = 5;
                currentBulletNumber = maxBulletNumber;
                restoreBulletTime = 0.5f;
                break;
            case SpellStyle.LaserBeam:
                break;
            case SpellStyle.WaterBomb:
                maxBulletNumber = 3;
                currentBulletNumber = maxBulletNumber;
                restoreBulletTime = 0.5f;
                break;
            default:
                Debug.LogWarning("Spell doesn't selected");
                return;
        }
    }

    private bool isActive;
    private int currentBulletNumber;
    private int maxBulletNumber;
    private float restoreBulletTime;
    private float currentTimeRestore;

    public void Activate(bool val)
    {
        isActive = val;
    }


    void Update()
    {
        if (!isActive) return;

        if (currentTimeRestore > restoreBulletTime)
        {
            currentTimeRestore = 0;
            currentBulletNumber++;
        }
        else if (currentBulletNumber < maxBulletNumber)
        {
            currentTimeRestore += Time.deltaTime * restoreBulletTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 target;

            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target += new Vector3(0, 0, 10);

            switch (spellStyle)
            {
                case SpellStyle.Fireball:
                    if (currentBulletNumber > 0)
                    {
                        GameObject fireball = Instantiate(spellObjects["Fireball"], rightHand.position, rightHand.rotation);
                        fireball.GetComponent<Fireball>().SetupFireball(target);
                        currentBulletNumber--;
                    }
                    break;
                case SpellStyle.LaserBeam:
                    transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case SpellStyle.WaterBomb:
                    if (currentBulletNumber > 0)
                    {
                        GameObject waterBomb = Instantiate(spellObjects["WaterBomb"], rightHand.position, rightHand.rotation);
                        waterBomb.GetComponent<WaterBomb>().SetupWaterBomb(target);
                        currentBulletNumber--;
                    }
                    break;
                default:
                    Debug.LogWarning("Spell doesn't selected");
                    return;
            }

            //GameObject projectileSpawned = Instantiate(temporaryBullet, transform.position, transform.rotation);
            //projectileSpawned.GetComponent<Projectile>().SetTarget(target);

        }

    }

    [Serializable]
    public class Spell
    {
        public string name = "";
        public GameObject prefab = null;
    }
}
