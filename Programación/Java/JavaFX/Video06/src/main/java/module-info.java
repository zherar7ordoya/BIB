module org.example.video06 {
    requires javafx.controls;
    requires javafx.fxml;


    opens org.example.video06 to javafx.fxml;
    exports org.example.video06;
}