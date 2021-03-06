using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
public class PlayerMovement : MonoBehaviour
{
    //public PlayerEvents playerEvents;
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public Animator anim;
    bool ennemiisTarget;
    public PlayableDirector Brawling;
    
    public float speedRotation;
    public Joystick js;

    public static bool isNotInput;
    public PlayerEvents playerEvents;
    Transform target = null;
    private void OnEnable()
    {

        //EventController.canKill += ChangeTarget;
        // EventController.sendSettingData += GetSettingData;
        //EventController.gameWin += GameWin;
        //EventController.gameLoose += GameLoose;
        StartCoroutine(carouTineTarget());


    }

    private void OnDisable()
    {
        //EventController.canKill -= ChangeTarget;
        //EventController.sendSettingData -= GetSettingData;
       // EventController.gameWin -= GameWin;
       // EventController.gameLoose -= GameLoose;
        StopCoroutine(carouTineTarget());



    }

    private void Start()
    {
      
    }
    
    IEnumerator carouTineTarget()
    {
        UpdateTarget();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(carouTineTarget());
    }
    
    void UpdateTarget()
    {
        Collider[] ennemies = Physics.OverlapSphere(transform.position, 10);
        for (int i = 0; i < ennemies.Length; i++)
        {
            if (ennemies[i].transform.tag == "Ennemie")
            {
                target = ennemies[i].transform;
                break;

            }
            else
            {
                target = null;
            }
        }
        
    }
    void Update()
    {
        /*if (isWin==true||Singleton._instance.state==GameState.win)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
           
            anim.SetFloat("speed", 0);

            return;
        }
        if (switchTarget==null||!switchTarget.gameObject.activeInHierarchy)
        {
            ennemiisTarget = false;
        }*/

        
        
        //Application.targetFrameRate = 30;
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //mo= new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = Vector3.zero;


#if UNITY_ANDROID
      move = new Vector3(js.Horizontal, 0, js.Vertical);
      speedRotation=0.3f;
     


#else
        //move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        // speedRotation = 0.5f;
        move = new Vector3(js.Horizontal, 0, js.Vertical);
        speedRotation = 0.3f;
#endif





        if (move==Vector3.zero)
        {
            isNotInput=true;
        }

        anim.SetFloat("speed", Mathf.Abs(move.magnitude * Time.deltaTime * playerSpeed));
        if (move!=Vector3.zero)
        {
            isNotInput = false;
            /*if (move.magnitude>0.8)
            {
                anim.speed = 1.5f;
                playerSpeed = 8;
            }
            if (move.magnitude<0.8&&move.magnitude>0.3)
            {
                anim.speed = 1;
                playerSpeed = 12;
            }
            if (move.magnitude<=0.3&&move.magnitude>0.05f)
            {
                anim.speed = 0.8f;
                playerSpeed =15;
            }
            if (move.magnitude<=0.01)
            {
                anim.speed = 1;
            }*/
          //  playerSpeed = 8;
            //anim.speed = 2;
            move.y=0;
            controller.Move(move.normalized * Time.smoothDeltaTime* playerSpeed);
            // anim.speed = move.magnitude * Time.deltaTime * playerSpeed*10;
        }
        else
        {
            anim.speed = 1;
        }
       
      
        if (target!=null)
        {
            if (playerEvents.canRotate == true)
            {
                LookToEnnemie(target);
            }
            
            
        }
        else
        {

            if (move != Vector3.zero && playerEvents.canRotate == true)
            {

                LockOnTarget(move.normalized);
                // gameObject.transform.forward = move;
            }
        }
       

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        if (groundedPlayer==false)
        {
            playerVelocity.y = gravityValue * Time.deltaTime;
            controller.Move(playerVelocity);
        }
        /*string x = (transform.localPosition.x).ToString();
        string y = (transform.localPosition.y).ToString();
        string z = (transform.localPosition.z).ToString();
        
        if (x.Length>5||y.Length>5||z.Length>5){

            string a = "";
        string b = "";
        string c = "";
        for (int i = 0; i < 5; i++)
        {
            if (i <= x.Length - 1)
            {
                a += x[i];
            }
            if (i <= y.Length - 1)
            {
                b += y[i];
            }
            if (i <= z.Length - 1)
            {
                c += z[i];
            }

        }
        transform.localPosition = new Vector3(float.Parse(a), float.Parse(b), float.Parse(c));
        }*/
        
        

    }

    void LockOnTarget(Vector3 _target)
    {
         
            Vector3 root = Vector3.Lerp(transform.forward, _target, speedRotation);
            transform.forward = root;
        
      
    }
    void LookToEnnemie(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.3f).eulerAngles;
        // LeanTween.rotate(transform, new Vector3(0,dir.y,0), 0.3f);
        transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    Transform switchTarget;
      /*  void ChangeTarget(Transform t,float raduis)
    {
        switchTarget = t;
        if (t==null)
        {
            ennemiisTarget = false;

        }
        else if(playerEvents.AutoFocuse == true)
        {
            ennemiisTarget = true;
        }
    }*/
    
    void GetSettingData(float speed, float ennemydetect, bool autofocuse, bool vibration)
    {
        playerSpeed = speed;

    }
    bool isWin;
    void GameWin()
    {
      
        isWin = true;
       // this.enabled = false;
    }
    void GameLoose()
    {
        this.enabled = false;
    }
    public void PlayBrawling()
    {
        Brawling.Play();
    }
}
