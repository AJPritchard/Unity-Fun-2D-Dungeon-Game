using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public static PlayerHealth health;
    public static PlayerMana mana;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public GameObject[] SpellBar;
    public static readonly int NumberOfSpells = 3;
    public GameObject SpellMenu;

    public float manaRegen = 10;

    private int SpellSelected = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        health = new PlayerHealth(gameObject);
        mana = new PlayerMana(gameObject);

        SpellBar = new GameObject[NumberOfSpells];
        SpellBar[0] = GameObject.Find("White Back Fireball");
        SpellBar[1] = GameObject.Find("White Back Teleport");
        SpellBar[2] = GameObject.Find("White Back Heal");
        SelectSpell(0);

        SpellMenu = GameObject.Find("Spell Menu");
        SpellMenu.SetActive(false);
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (Input.GetMouseButtonDown(1) && SpellSelected == 0)
        {
            Spells.CastFireBall(gameObject, mana);
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            SelectSpell(0);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            SelectSpell(1);
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            SelectSpell(2);
        }

        if (SpellSelected == 1 && Input.GetMouseButtonDown(1))
        {
            Spells.CastTeleport(gameObject, mana);
        }

        if (SpellSelected == 2 && Input.GetMouseButtonDown(1))
        {
            Spells.CastHeal(gameObject, mana, health);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);

        }

        if(health.isDead)
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            SpellMenu.SetActive(!SpellMenu.activeSelf);
        }

        mana.AddMana(PlayerStats.ManaRegen * Time.deltaTime);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public PlayerHealth GetHealth()
    {
        return health;
    }

    public PlayerMana GetMana()
    {
        return mana;
    }

    public void SelectSpell(int spell)
    {
        SpellSelected = spell;

        foreach(GameObject go in SpellBar) {
            go.GetComponent<SpriteRenderer>().color = Color.black;
        }

        SpellBar[SpellSelected].GetComponent<SpriteRenderer>().color = Color.gray;
    }
}
