using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;


[System.Serializable]
public class RequestConArgumentos : UnityEvent<GeneralInfo> {}
public class RequestManager : MonoBehaviour
{

    [SerializeField]
    private UnityEvent _requestRecibidaSinArgumentos;

    [SerializeField]
    private RequestConArgumentos _requestConArgumentos;

    [SerializeField]
    private float _esperaEntreRequests = 1;

     [SerializeField]private TextAsset _archivoJson;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HacerRequest());

        // _requestRecibidaSinArgumentos += funcion();
    }
    
    public IEnumerator HacerRequest() { 
        // Vamos a cargar el json

        // Primero checamos si existe
        if (_archivoJson != null) {
            string datosJson = _archivoJson.text; // Volvemos datos de json en un string

            GeneralInfo generalInfo = JsonUtility.FromJson<GeneralInfo>(datosJson);
            //print(generalInfo);
            _requestRecibidaSinArgumentos?.Invoke();
            _requestConArgumentos?.Invoke(generalInfo);
            
        }

        yield return new WaitForSeconds(_esperaEntreRequests);

    }

}
