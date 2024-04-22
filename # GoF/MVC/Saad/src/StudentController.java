public class StudentController {
    // Model Object
    // View Object
    private Student model;
    private StudentView view;

    // Constructor
    public StudentController(Student model, StudentView view) {
        this.model = model;
        this.view = view;
    }

    // Control Model Object
    public void setStudentName(String name) {
        model.setName(name);
    }

    public void setStudentRollNo(String rollNo) {
        model.setRollNo(rollNo);
    }

    public String getStudentName() {
        return model.getName();
    }

    public String getStudentRollNo() {
        return model.getRollNo();
    }

    // Control View Object
    public void updateView() {
        view.printStudentDetails(getStudentName(), getStudentRollNo());
    }
}
