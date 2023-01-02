using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 
    public float runningSpeed;
    public float xSpeed;
    float touchXDelta = 0f;
    float newX = 0;
    public float limitx;  // 2.17.Player ýn x ekseninde platform dýþýna çýkmamasý için bir iþlem gerekli.


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SwipeCheck();
        
    }

    public void SwipeCheck()  // 2.19.
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) // Dokunduðumda && Dokunup parmaðýmý hareket ettirdiðimde
        {
            // Android cihazý baðla ve ekrana dokunuþlarda aþaðýdakileri test et
            //Debug.Log(Input.touchCount); yukarýda sadece if(Input.touchCount > 0) yazýp dokunuþu test ettiðimizde
            //Debug.Log("Finger is moved"); ile bu if bloðunu console da test ettik.
            //Debug.Log(Input.GetTouch(0).deltaPosition.x); ile x deki hareketini test ettik sola - saða +(deðerler büyük)
            //Debug.Log(Input.GetTouch(0).deltaPosition.x/ Screen.width); ile ekran geniþliðine böldüðümüz için daha küçük rakamlara ulaþtýk test ederken

            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X"); // Mouse sol týk sürükleyerek kontrol edebiliyoruz
        }
        // PROBLEM : sola ve saða giderken parmaðýmýzý çeksek dahi hangi yöne bastýysak ilerlemeye devam ediyor. Çözüm :
        else //3.1.
        {
            touchXDelta = 0;
        }
        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitx, limitx); // 2.18.
        // Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}