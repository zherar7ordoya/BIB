import model.Producto;

public class Main {
    public static void main(String[] args) {
        System.out.println("Ejecutando la aplicación inventario");
        Producto producto = new Producto("refresco", 5.00, 10);
        System.out.println("Producto: " + producto.getNombre());
        System.out.println("Valor: " + producto.getValor());
        System.out.println("Cantidad: " + producto.getCantidad());
    }
}