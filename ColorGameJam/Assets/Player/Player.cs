using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public enum ColorColor { Red, Blue, Yellow }

    private Rigidbody2D rb;
    [SerializeField]
    private float MoveSpeed = 1;
	[SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Sprite[] RedBulletSprites;
    [SerializeField]
    private Sprite[] BlueBulletSprites;
    [SerializeField]
    private Sprite[] YellowBulletSprites;
    [SerializeField]
    private float TimeBetweenShots = 0.1f;
    private float TimeBetweenShotsCounter = 0;
    private ColorColor playerColor = ColorColor.Red;
    [SerializeField]
    private SpriteRenderer colorChangingSpriteRenderer;
    [SerializeField]
    private Color red = Color.red;
    [SerializeField]
    private Color blue = Color.blue;
    [SerializeField]
    private Color yellow = Color.yellow;

    private Animator anim;
    [SerializeField]
    private RuntimeAnimatorController redAC;
    [SerializeField]
    private RuntimeAnimatorController blueAC;
    [SerializeField]
    private RuntimeAnimatorController yellowAC;

    private bool wasJustInstantiated = true;
    private bool isFiring = false;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        transform.parent = PlayerList.Instance.transform;
        ChangeColor(PlayerList.Instance.GetMinColor());
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        Movement();
        Shooting();
    }

    private void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 vec = new Vector2(h, v);
        vec.Normalize();
        vec *= MoveSpeed;
        rb.velocity = vec;
    }

	private void Shooting()
    {
        TimeBetweenShotsCounter -= Time.deltaTime;
        if (Input.GetButton("Fire1") && TimeBetweenShotsCounter <= 0)
        {                   
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit floorHit;
            if (Physics.Raycast(camRay, out floorHit, 1000))
            {
                Vector3 playerToMouse = floorHit.point - transform.position;
                playerToMouse.z = 0f;
                Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
                GameObject g = PhotonNetwork.Instantiate(bulletPrefab.name, transform.position, newRotation, 0);
                g.transform.right = playerToMouse;
                g.GetComponent<SpriteRenderer>().sprite = GetBulletSprite();
                isFiring = true;
                TimeBetweenShotsCounter = TimeBetweenShots;
            }
        }
        else isFiring = false;
    }

    private Sprite GetBulletSprite()
    {
        switch(playerColor)
        {
            case ColorColor.Red:
                return RedBulletSprites[Random.Range(0, RedBulletSprites.Length)];
            case ColorColor.Blue:
                return BlueBulletSprites[Random.Range(0, BlueBulletSprites.Length)];
            case ColorColor.Yellow:
                return YellowBulletSprites[Random.Range(0, YellowBulletSprites.Length)];
        }
        return null;
    }

    public ColorColor GetPlayerColor()
    {
        return playerColor;
    }

    private void ChangeColor(ColorColor newColor)
    {
        if(!anim) anim = GetComponent<Animator>();
        print("Changing color to : " + newColor);
        playerColor = newColor;

        switch (newColor)
        {
            case Player.ColorColor.Red:
                anim.runtimeAnimatorController = redAC;
                colorChangingSpriteRenderer.color = red;
                break;
            case Player.ColorColor.Blue:
                anim.runtimeAnimatorController = blueAC;
                colorChangingSpriteRenderer.color = blue;
                break;
            case Player.ColorColor.Yellow:
                anim.runtimeAnimatorController = yellowAC;                
                colorChangingSpriteRenderer.color = yellow;
                break;
        }
        wasJustInstantiated = false;
    }

    public bool GetIsFiring() { return isFiring; }

}
	