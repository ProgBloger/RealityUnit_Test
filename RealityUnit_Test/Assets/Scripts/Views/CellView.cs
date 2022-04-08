using System;
using UnityEngine;

public class CellClickEventArgs : EventArgs
{
    
}

public interface ICellView
{
    event EventHandler<CellClickEventArgs> OnClicked;
    int Value { set; }

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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                var eventArgs = new CellClickEventArgs();
                OnClicked(this, eventArgs);
            }
        }
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
