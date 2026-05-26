namespace StudentsTable
{
    public partial class RegisterStudentForm : Form
    {
        public Student SavedValue { get; private set; } = null!;

        public RegisterStudentForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SavedValue = new Student(firstNameTextBox.Text, lastNameTextBox.Text, dateOfBirthDateTimePicker.Value.Date);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
