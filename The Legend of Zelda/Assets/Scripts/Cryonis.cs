using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Cryonis : MonoBehaviour
{
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material highlightMaterial;
    [SerializeField] LayerMask WaterLayer;
    [SerializeField] GameObject IceCube;
    [SerializeField] float IceCubeHeight;
    [SerializeField] GameObject CryonisCanvas;

    private Transform _selection;
    
    


    

    private void Start()
    {
        CryonisCanvas.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            CryonisCanvas.SetActive(true);
        }
        else
        {
            CryonisCanvas.SetActive(false);
        }
        SelectWaterLayer();

    }

    private void SelectWaterLayer()
    {
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        if (Physics.Raycast(ray, out hit, 100f, WaterLayer) && (Input.GetMouseButton(2)) )
        {
            
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
            _selection = selection;

            if (Input.GetKeyDown("q"))
            {
                Vector3 offset = new Vector3(0, -IceCubeHeight, 0);
                GameObject currentIceCube =  Instantiate( IceCube , hit.point, Quaternion.identity);
                currentIceCube.transform.DOScale(new Vector3(IceCubeHeight / 2, IceCubeHeight, IceCubeHeight / 2), 1);
                currentIceCube.transform.DOMoveY(IceCubeHeight/2, 1);

                //currentIceCube.transform.localScale = new Vector3(1, IceCubeHeight, 1);
                //currentIceCube.transform.DOMoveY(IceCubeHeight, 2);
            }

        }
    }

    
}
