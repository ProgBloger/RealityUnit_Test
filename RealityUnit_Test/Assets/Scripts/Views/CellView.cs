using System;
using System.Collections.Generic;
using UnityEngine;

public class CellClickEventArgs : EventArgs
{
    
}

public interface ICellView
{
    event EventHandler<CellClickEventArgs> OnClicked;
    int Value { set; }

    bool IsActive { set; } 
    void SetPosition(Vector3 position);
}

public class CellView : MonoBehaviour, ICellView
{
    public event EventHandler<CellClickEventArgs> OnClicked = (sender, e) => {};
    public int Value 
    {
        set
        {
            string labelName = value.ToString();
            
            TextMesh label = GetComponentInChildren<TextMesh>();
            label.text = labelName;
            
            gameObject.name = $"Cell with value {labelName}";
        }
    }

    public bool IsActive 
    {
        set
        {
            if(value)
            {
                var cubeRenderer = GetComponent<Renderer>();

                cubeRenderer.material.SetColor("_Color", Color.red);
            }
            else
            {
                var cubeRenderer = GetComponent<Renderer>();

                cubeRenderer.material.SetColor("_Color", Color.green);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit mouseHit;
            if(Physics.Raycast(ray, out mouseHit) && mouseHit.transform == transform)
            {
                var eventArgs = new CellClickEventArgs();
                OnClicked(this, eventArgs);
            }
        }

        var touches = new List<Ray>();
        if(Input.touchCount > 0)
         {
             foreach(Touch t in Input.touches)
             {
                 touches[t.fingerId] = Camera.main.ScreenPointToRay(Input.GetTouch(t.fingerId).position);

                 if(Input.GetTouch(t.fingerId).phase == TouchPhase.Began)
                 {
                    RaycastHit touchHit;
                    if(Physics.Raycast(touches[t.fingerId], out touchHit) && touchHit.transform == transform)
                    {
                        var eventArgs = new CellClickEventArgs();
                        OnClicked(this, eventArgs);
                    }
                 }
                     
             }
         }
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
