using System.ComponentModel;

namespace StudentsTable
{
    public partial class Form1 : Form
    {
        private readonly BindingList<Student> students;

        public Form1()
        {
            InitializeComponent();
            addToolStripButton.Image = CreateAddIcon();
            students = new BindingList<Student>(BuildStudentList());
            studentsBindingSource.DataSource = students;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = studentsBindingSource;
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

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            using RegisterStudentForm registerStudentForm = new RegisterStudentForm();

            if (registerStudentForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            Student student = registerStudentForm.SavedValue;
            student.Id = GetNextStudentId();
            students.Add(student);
        }

        private int GetNextStudentId()
        {
            return students.Count == 0 ? 1 : students.Max(student => student.Id) + 1;
        }

        private Bitmap CreateAddIcon()
        {
            Bitmap bitmap = new Bitmap(16, 16);

            using Graphics graphics = Graphics.FromImage(bitmap);
            using Pen pen = new Pen(Color.FromArgb(40, 130, 70), 2);

            graphics.Clear(Color.Transparent);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.DrawEllipse(pen, 2, 2, 12, 12);
            graphics.DrawLine(pen, 8, 5, 8, 11);
            graphics.DrawLine(pen, 5, 8, 11, 8);

            return bitmap;
        }
    }
}
