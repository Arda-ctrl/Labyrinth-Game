using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text zaman, can, durum;
    private Rigidbody rg;
        public float Hiz = 3f;
    float zamanSayaci = 60;
    int canSayaci = 3;
    bool oyunDevam = true;
    bool oyunTamam = false;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyunTamam)
        {
            zamanSayaci -= Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
        else if (!oyunTamam)
        {
            durum.text = "You lost, you can try again.";
            btn.gameObject.SetActive (true);
        }
        if(zamanSayaci < 0 )
            oyunDevam = false;
    }
    void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(yatay, 0, dikey);
            rg.AddForce(kuvvet * 10);
        }
        else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }
    void OnCollisionEnter(Collision cls)
    {
        //Debug.Log(cls.gameObject.name);
        string objname = cls.gameObject.name;
        
        if(objname.Equals ("bitis"))
        {
            oyunTamam = true;
            durum.text = "Congratulations you big head";
            btn.gameObject.SetActive(true);
        }
        else if (!objname.Equals("Zemin1") && !objname.Equals("Zemin2"))
        {
            canSayaci -= 1;
            can.text = canSayaci + "";
            if(canSayaci == 0)
                oyunDevam = false;
        }
     

    }
}
