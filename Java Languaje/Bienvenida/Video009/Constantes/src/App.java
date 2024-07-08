public class App {
    public static void main(String[] args) throws Exception {
        // Clean console
        System.out.print("\033[H\033[2J");
        double a = 5;
        double b;
        b = 7;
        double c = b / a;
        System.out.print(c);
    }
}
