namespace BlaisePascal.Esercitazione1.Domain
{
    public class Brano
    {
        public string Title { get; private set; }
        public Author Author { get; private set; }
        public int DurationInSec { get; private set; }

        public Brano(string title, Author author, int durationInSec)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            if (author == null)
                throw new ArgumentNullException(nameof(author), "Author cannot be null.");
            if (durationInSec <= 0)
                throw new ArgumentOutOfRangeException(nameof(durationInSec), "Duration must be greater than zero.");
            Title = title;
            Author = author;
            DurationInSec = durationInSec;
        }

        public string GetTitle() => Title;
        public Author GetAuthor() => Author;
        public int GetDurationInSec() => DurationInSec;


        public void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            Title = title;
        }
        public void SetAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author), "Author cannot be null.");
            Author = author;
        }
        public void SetDurationInSec(int durationInSec)
        {
            if (durationInSec <= 0)
                throw new ArgumentOutOfRangeException(nameof(durationInSec), "Duration must be greater than zero.");
            DurationInSec = durationInSec;
        }


        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Duration: {DurationInSec} seconds";
        }


        public bool ShortSong(int duration) => DurationInSec < duration;
    }
}
