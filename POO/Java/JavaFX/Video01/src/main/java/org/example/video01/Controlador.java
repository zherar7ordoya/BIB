package org.example.video01;

import javafx.fxml.FXML;
import javafx.scene.control.Label;

public class Controlador {
    @FXML
    private Label etiqueta;

    @FXML
    protected void holaClick() {
        etiqueta.setText("Bueno, esto es JavaFX");
    }
}