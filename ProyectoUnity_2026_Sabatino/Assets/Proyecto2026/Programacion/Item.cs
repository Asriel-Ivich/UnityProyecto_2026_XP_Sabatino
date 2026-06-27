using UnityEngine;

public class Item : MonoBehaviour
{
    public enum TipoItem
    {
        Pocion,
        Flecha,
        Antorcha
    }

    public TipoItem tipoItem;
    public int cantidad = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventario = other.GetComponent<PlayerInventory>();

            if (inventario != null)
            {
                switch (tipoItem)
                {
                    case TipoItem.Pocion:
                        inventario.AgregarPociones(cantidad);
                        break;

                    case TipoItem.Flecha:
                        inventario.AgregarFlechas(cantidad);
                        break;

                    case TipoItem.Antorcha:
                        inventario.AgregarAntorchas(cantidad);
                        break;
                }

                Destroy(gameObject);
            }
        }
    }
}
