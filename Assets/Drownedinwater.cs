//using UnityEngine;

//public class Drownedinwater : MonoBehaviour
//{



//   void OnTriggerEnter(Collider other)
//    {

//        if (other.gameObject.tag == "Player")
//        {
//            Debug.Log("Dentro del ontrigger");
//            //Mira si el objeto entro en contacto con el Tag de agua 
//            if (gameObject.tag == "Water1")
//            {
//                //Active handle of water1
//                HandleTriggerWater1();
//            }
//            else if (gameObject.tag == "Water2")
//            {
//                //Active handle of water2
//                HandleTriggerWater2();
//            }
//            else if (gameObject.tag == "Water3")
//            {
//                //Active handle of water3
//                HandleTriggerWater3();
//            }

//        }
//    }


//    private void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            Debug.Log("The player has stopped touching the water ");
//        }
//    }
//    void HandleTriggerWater1()
//    {
//        Debug.Log("The player has come into contact with Water1");
//    }

//    void HandleTriggerWater2()
//    {
//        Debug.Log("The player has come into contact with Water2");
//    }

//    void HandleTriggerWater3()
//    {   
//        Debug.Log("The player has come into contact with Water3");
//    }
//}
