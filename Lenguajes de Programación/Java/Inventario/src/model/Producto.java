package model;

public class Producto {
    public int getCantidad() {
        return cantidad;
    }

    public Producto(String nombre, double valor, int cantidad) {
        this.nombre = nombre;
        this.valor = valor;
        this.cantidad = cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }

    public double getValor() {
        return valor;
    }

    public void setValor(double valor) {
        this.valor = valor;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    private String nombre;
    private double valor;
    private int cantidad;
}
