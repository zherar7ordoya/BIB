module com.zherar7ordoya.chatgpt {
    requires javafx.controls;
    requires javafx.fxml;


    opens com.zherar7ordoya.chatgpt to javafx.fxml;
    exports com.zherar7ordoya.chatgpt;
}