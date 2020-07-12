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

    public void SetupSpelling(SpellStyle spellStyle)
    {
        spellObjects = new Dictionary<string, GameObject>();
        foreach (Spell spell in spells)
        {
            spellObjects.Add(spell.name, spell.prefab);
        }

        this.spellStyle = spellStyle;
    }

    private bool isActive;

    public void Initialize()
    {
        isActive = false;
    }
    public void Activate()
    {
        isActive = true;
    }


    void Update()
    {
        if (!isActive) return;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 target;

            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target += new Vector3(0, 0, 10);

            switch (spellStyle)
            {
                case SpellStyle.Fireball:
                    GameObject fireball = Instantiate(spellObjects["Fireball"], transform.position, transform.rotation);
                    fireball.GetComponent<Fireball>().SetupFireball(target);
                    break;
                case SpellStyle.LaserBeam:
                    GameObject laserBeam = Instantiate(spellObjects["LaserBeam"], transform.position, transform.rotation, gameObject.transform);
                    laserBeam.GetComponent<LaserBeam>().SetupLaserBeam();
                    break;
                case SpellStyle.WaterBomb:
                    GameObject waterBomb = Instantiate(spellObjects["WaterBomb"], transform.position, transform.rotation);
                    waterBomb.GetComponent<WaterBomb>().SetupWaterBomb(target);
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
