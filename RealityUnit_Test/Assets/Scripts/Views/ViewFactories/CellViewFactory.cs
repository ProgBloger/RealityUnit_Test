using UnityEngine;

public interface ICellViewFactory
{
    ICellView GetView(Vector3 position);
}

public class CellViewFactory : ICellViewFactory
{
    public ICellView GetView(Vector3 position)
    {
      var prefab = Resources.Load<GameObject>("Cell");
      var instance = UnityEngine.Object.Instantiate(prefab);
      var cellView = instance.GetComponent<ICellView>();

      cellView.SetPosition(position);

      return cellView;
    }
}