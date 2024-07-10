public class App {
    public static void main(String[] args) throws Exception {
        // Limpia la consola
        System.out.print("\033[H\033[2J");
        final double pulgada = 2.54;
        int centimetros = 6;
        double resultado = centimetros / pulgada;
        System.out.println("En " + centimetros + " centimetros hay " + resultado + " pulgadas");
    }
}
