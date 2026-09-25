using System;
using System.Text;
using Models;
using Repositories;

namespace lab_37
{
    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            DemonstratePostings();
            Console.WriteLine();
            DemonstrateContactPersons();
        }

        private static void DemonstratePostings()
        {
            Console.WriteLine("=== GenericRepository<Posting> ===");

            var postings = new GenericRepository<Posting>();

            postings.Add(new Posting
            {
                Id = 1,
                TrackNumber = "UA100000001",
                Weight = 1.5,
                SenderAddress = "Київ, вул. Хрещатик, 1",
                ReceiverAddress = "Львів, пл. Ринок, 5",
                DeliveryStatus = "Прийнято"
            });

            postings.Add(new Posting
            {
                Id = 2,
                TrackNumber = "UA100000002",
                Weight = 0.75,
                SenderAddress = "Одеса, вул. Дерибасівська, 10",
                ReceiverAddress = "Харків, вул. Сумська, 20",
                DeliveryStatus = "В дорозі"
            });

            postings.Add(new Posting
            {
                Id = 3,
                TrackNumber = "UA100000003",
                Weight = 3.2,
                SenderAddress = "Дніпро, пр. Яворницького, 50",
                ReceiverAddress = "Полтава, вул. Соборності, 15",
                DeliveryStatus = "Прийнято"
            });

            // Отримання за ідентифікатором.
            Posting? found = postings.GetById(2);
            Console.WriteLine("Отримано за Id = 2: " + (found?.ToString() ?? "не знайдено"));

            // Оновлення однієї з доданих сутностей.
            postings.Update(new Posting
            {
                Id = 2,
                TrackNumber = "UA100000002",
                Weight = 0.75,
                SenderAddress = "Одеса, вул. Дерибасівська, 10",
                ReceiverAddress = "Харків, вул. Сумська, 20",
                DeliveryStatus = "Доставлено"
            });
            Console.WriteLine("Після оновлення Id = 2: " + postings.GetById(2));

            // Видалення однієї з доданих сутностей.
            postings.Delete(1);
            Console.WriteLine("Сутність з Id = 1 видалено.");

            Console.WriteLine("Повний перелік відправлень, що залишилися:");
            foreach (Posting posting in postings.GetAll())
            {
                Console.WriteLine("  " + posting);
            }
        }

        private static void DemonstrateContactPersons()
        {
            Console.WriteLine("=== GenericRepository<ContactPerson> ===");

            var contacts = new GenericRepository<ContactPerson>();

            contacts.Add(new ContactPerson
            {
                Id = 1,
                Name = "Іван Петренко",
                PhoneNumber = "+380501112233",
                Email = "ivan@example.com"
            });

            contacts.Add(new ContactPerson
            {
                Id = 2,
                Name = "Олена Коваль",
                PhoneNumber = "+380672223344",
                Email = "olena@example.com"
            });

            contacts.Add(new ContactPerson
            {
                Id = 3,
                Name = "Сергій Шевченко",
                PhoneNumber = "+380933334455",
                Email = "serhii@example.com"
            });

            // Отримання за ідентифікатором.
            ContactPerson? found = contacts.GetById(3);
            Console.WriteLine("Отримано за Id = 3: " + (found?.ToString() ?? "не знайдено"));

            // Оновлення однієї з доданих сутностей.
            contacts.Update(new ContactPerson
            {
                Id = 3,
                Name = "Сергій Шевченко",
                PhoneNumber = "+380933334455",
                Email = "serhii.new@example.com"
            });
            Console.WriteLine("Після оновлення Id = 3: " + contacts.GetById(3));

            // Видалення однієї з доданих сутностей.
            contacts.Delete(2);
            Console.WriteLine("Сутність з Id = 2 видалено.");

            Console.WriteLine("Повний перелік контактних осіб, що залишилися:");
            foreach (ContactPerson contact in contacts.GetAll())
            {
                Console.WriteLine("  " + contact);
            }

            // Перевірка, що дані двох репозиторіїв не перетнулися:
            // окремий статичний список існує для кожного закритого типу.
            var postingsCheck = new GenericRepository<Posting>();
            int postingCount = 0;
            foreach (Posting _ in postingsCheck.GetAll())
            {
                postingCount++;
            }

            int contactCount = 0;
            foreach (ContactPerson _ in contacts.GetAll())
            {
                contactCount++;
            }

            Console.WriteLine();
            Console.WriteLine("Перевірка ізоляції даних:");
            Console.WriteLine($"  У сховищі Posting залишилося сутностей: {postingCount}");
            Console.WriteLine($"  У сховищі ContactPerson залишилося сутностей: {contactCount}");
            Console.WriteLine("  Дані двох репозиторіїв не змішалися між собою.");
        }
    }
}
