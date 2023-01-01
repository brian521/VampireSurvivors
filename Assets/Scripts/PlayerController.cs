using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveX, moveY;

    Quaternion ang = Quaternion.Euler(0, 0, 0);
    Vector2 vec = new Vector2(0, 0);
    float deg = 0f;

    Vector2 movevec;

    Rigidbody2D rigid;
    Animator anim;

    public GameObject[] weapon;
    public Sprite[] passive;

    public List<Sprite> gainedPassive = new List<Sprite>();
    public List<Sprite> gainedWeapon = new List<Sprite>();

    [Header("이동속도 조절")]
    [SerializeField] // Inspector에서 편집하기 위해서 사용. public을 사용해도 됨
    [Range(1f, 10f)]
    float moveSpeed = 5f;


    public int PlayerHp = 20;
    public int MaxHp;

    bool damaged = false;

    public int currentLevel = 0;
    public int currentXp = 0;
    public int[] requiredXp = {10, 25, 50, 90, 110, 195, 310, 460, 600};

    public GameObject GameOverImage;

    Enemy enemy;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); // 리지드바디 가져오기
        anim = GetComponent<Animator>();
        MaxHp = PlayerHp;
        MakeWhip();
    }

    void Update()
    {
        FlipX();
        Walk();
        CheckLvl();

        if (moveX != 0 || moveY != 0)
        {
            deg = ((180 / Mathf.PI) * Mathf.Atan2(moveX, -moveY)) - 90;
            ang = Quaternion.Euler(0, 0, deg);
        }

        if (PlayerHp <= 0 && GameOverImage.activeSelf == false)
        {
            GameOver();
        }
    }

    void FixedUpdate() // 주로 물리효과(리지드바디)가 적용된 오브젝트에 사용
    {
        Move();
    }

    void Move()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        movevec = new Vector2(moveX, moveY);
        rigid.velocity = movevec.normalized * moveSpeed;
    }

    void FlipX()
    {
        if (moveX < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (moveX > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void Walk()
    {
        if(rigid.velocity.normalized.x == 0 && rigid.velocity.normalized.y == 0)
        {
            anim.SetBool("isWalk", false);
        }
        else
        {
            anim.SetBool("isWalk", true);
        }
    }

    void MakeWhip()
    {
        Weapon wp = weapon[0].GetComponent<Weapon>();
        GameObject WeaponObject;
        WeaponObject = Instantiate(weapon[0], new Vector2(rigid.position.x + 2.04f, rigid.position.y + 0.6f), Quaternion.identity);
        WeaponObject.transform.localScale = new Vector3(3f, 3f, 1f);

        gainedWeapon.Add(weapon[0].GetComponent<SpriteRenderer>().sprite);

        StartCoroutine(AttackWhip(WeaponObject, wp));
    }

    void MakeKnife()
    {
        Weapon wp = weapon[1].GetComponent<Weapon>();

        gainedWeapon.Add(weapon[1].GetComponent<SpriteRenderer>().sprite);

        StartCoroutine(AttackKnife(wp));
    }

    // 무기 공격 함수
    IEnumerator AttackWhip(GameObject summonedWeapon, Weapon Wp)
    {
        if (transform.localScale.x < 0)
        {
            summonedWeapon.transform.position = new Vector2(rigid.position.x - 2.04f, rigid.position.y + 0.6f);
            summonedWeapon.transform.localScale = new Vector3(-3f, 3f, 1f);
        }
        else
        {
            summonedWeapon.transform.position = new Vector2(rigid.position.x + 2.04f, rigid.position.y + 0.6f);
            summonedWeapon.transform.localScale = new Vector3(3f, 3f, 1f);
        }

        summonedWeapon.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1f);
        summonedWeapon.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        summonedWeapon.GetComponent<SpriteRenderer>().material.color = new Color(1,1,1,0.5f);
        yield return new WaitForSeconds(0.1f);
        summonedWeapon.SetActive(false);
        yield return new WaitForSeconds(Wp.atkDelay);
        StartCoroutine(AttackWhip(summonedWeapon, Wp));
    }

    IEnumerator AttackKnife(Weapon Wp)
    {
        GameObject summonedWeapon;
        summonedWeapon = Instantiate(weapon[1], new Vector2(rigid.position.x, rigid.position.y), ang);

        yield return new WaitForSeconds(Wp.atkDelay);
        StartCoroutine(AttackKnife(Wp));
    }


    void CheckLvl()
    {
        if (currentXp >= requiredXp[currentLevel])
        {
            currentXp -= requiredXp[currentLevel];
            currentLevel += 1;

            switch (currentLevel){ 
                case 2:
                    MakeKnife();
                    break;
                default:
                    gainHp();
                    break;
            }
        }
    }

    void gainHp()
    {
        if(!gainedPassive.Contains(passive[0]))
        {
            gainedPassive.Add(passive[0]);
        }
        MaxHp += 5;
        PlayerHp += 5;
    }


    // 적에 닿으면 데미지 입기
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.CompareTag("Enemy") && damaged == false)
        {
            enemy = col.collider.gameObject.GetComponent<Enemy>();
            Debug.Log("Hit by " + enemy.name);
            damaged = true;
            PlayerHp -= enemy.damage;

            StartCoroutine(CheckDamaged());
        }
    }

    IEnumerator CheckDamaged()
    {
        yield return new WaitForSeconds(1f);
        damaged = false;
    }

    void GameOver()
    {
        GameOverImage.SetActive(true);
        Time.timeScale = 0;
    }
}
