using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Esercitazione1.Domain
{
    public class Author
    {
        public string ArtisticName { get; private set; }
        public string Name { get; init; }
        public string Surname { get; init; }

        public Author(string artisticName, string name, string surname)
        {
            if (string.IsNullOrEmpty(artisticName))
                throw new ArgumentException("Artistic name cannot be null or empty.", nameof(artisticName));
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            if (string.IsNullOrEmpty(surname))
                throw new ArgumentException("Surname cannot be null or empty.", nameof(surname));

            ArtisticName = artisticName;
            Name = name;
            Surname = surname;
        }

        public static Author Create(string artisticName, string name, string surname) => new Author(artisticName, name, surname);

        public override string ToString()
        {
            return $"Author:{ArtisticName}, ({Name} {Surname})";
        }
    }
}
