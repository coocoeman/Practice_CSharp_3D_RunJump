using UnityEngine;

public class Boy : MonoBehaviour
{
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;
    [Header("跳躍高度"), Range(100, 1500)]
    public int jump = 100;
    
    private Rigidbody r;
    private Animator a;
    private AudioSource aS;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
        r = GetComponent<Rigidbody>();
        a = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision ==null)
        {
            return;
        }
        a.SetBool("跳躍開關",false);
    }



    public void Jump()
    {
        if (a.GetBool("跳躍開關"))
        {
            return;
        }
        r.AddForce(Vector3.up*jump);
        a.SetBool("跳躍開關",true);
        aS.Play();
    }
}
