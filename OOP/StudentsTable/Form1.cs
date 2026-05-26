namespace StudentsTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            List<Student> students = BuildStudentList();
            dataGridView1.DataSource = students;
        }

        private List<Student> BuildStudentList()
        {
            return new List<Student>
            {
                new Student(1, "Іван", "Петренко", new DateTime(2000, 5, 15)),
                new Student(2, "Олена", "Ковальчук", new DateTime(1999, 8, 22)),
                new Student(3, "Сергій", "Григоренко", new DateTime(2001, 3, 10)),
                new Student(4, "Марія", "Шевченко", new DateTime(2000, 12, 5)),
                new Student(5, "Андрій", "Мельник", new DateTime(1998, 11, 30))
            };
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
