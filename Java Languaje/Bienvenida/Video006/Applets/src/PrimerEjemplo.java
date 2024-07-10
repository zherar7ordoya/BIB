import java.io.IOException;

public class PrimerEjemplo {
    public static void main(String[] args) throws InterruptedException, IOException {
        new ProcessBuilder("cmd", "/c", "cls").inheritIO().start().waitFor();
        System.out.println("Hola, Gerardo Tordoya. ¡Ésto es Java!");
    }
}
