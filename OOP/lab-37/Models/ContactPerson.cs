namespace Models
{
    public class ContactPerson : Model
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"ContactPerson #{Id}: {Name}, тел. {PhoneNumber}, ел. пошта {Email}";
        }
    }
}
