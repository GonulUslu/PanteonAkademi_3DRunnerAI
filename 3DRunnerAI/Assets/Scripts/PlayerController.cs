using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 
    public float runningSpeed;
    public float xSpeed;
    float touchXDelta = 0f;
    float newX = 0;
    public float limitx;  // 2.17.Player �n x ekseninde platform d���na ��kmamas� i�in bir i�lem gerekli.


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
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) // Dokundu�umda && Dokunup parma��m� hareket ettirdi�imde
        {
            // Android cihaz� ba�la ve ekrana dokunu�larda a�a��dakileri test et
            //Debug.Log(Input.touchCount); yukar�da sadece if(Input.touchCount > 0) yaz�p dokunu�u test etti�imizde
            //Debug.Log("Finger is moved"); ile bu if blo�unu console da test ettik.
            //Debug.Log(Input.GetTouch(0).deltaPosition.x); ile x deki hareketini test ettik sola - sa�a +(de�erler b�y�k)
            //Debug.Log(Input.GetTouch(0).deltaPosition.x/ Screen.width); ile ekran geni�li�ine b�ld���m�z i�in daha k���k rakamlara ula�t�k test ederken

            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X"); // Mouse sol t�k s�r�kleyerek kontrol edebiliyoruz
        }
        // PROBLEM : sola ve sa�a giderken parma��m�z� �eksek dahi hangi y�ne bast�ysak ilerlemeye devam ediyor. ��z�m :
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