using System;

/// <summary>
/// Represents a book with properties such as title, author, and cost.
/// </summary>
public class Book
{
    private string title;
    private string author;
    private double cost;

    /// <summary>
    /// Initializes a new instance of the <see cref="Book"/> class with the specified title, author, and cost.
    /// </summary>
    /// <param name="title">The title of the book.</param>
    /// <param name="author">The author of the book.</param>
    /// <param name="cost">The cost of the book.</param>
    public Book(string title, string author, double cost)
    {
        this.title = title;
        this.author = author;
        this.cost = cost;
    }

    /// <summary>
    /// Gets or sets the title of the book.
    /// </summary>
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    /// <summary>
    /// Gets or sets the author of the book.
    /// </summary>
    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    /// <summary>
    /// Gets or sets the cost of the book.
    /// </summary>
    public double Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    /// <summary>
    /// Prints information about the book, including title, author, and cost.
    /// </summary>
    public virtual void Print()
    {
        Console.WriteLine($"Title: {title}, Author: {author}, Cost: {cost:C}");
    }
}

/// <summary>
/// Represents a book with an additional genre property, inheriting from the <see cref="Book"/> class.
/// </summary>
public class BookGenre : Book
{
    private string genre;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookGenre"/> class with the specified title, author, cost, and genre.
    /// </summary>
    /// <param name="title">The title of the book.</param>
    /// <param name="author">The author of the book.</param>
    /// <param name="cost">The cost of the book.</param>
    /// <param name="genre">The genre of the book.</param>
    public BookGenre(string title, string author, double cost, string genre)
        : base(title, author, cost)
    {
        this.genre = genre;
    }

    /// <summary>
    /// Gets or sets the genre of the book.
    /// </summary>
    public string Genre
    {
        get { return genre; }
        set { genre = value; }
    }

    /// <summary>
    /// Prints information about the book, including title, author, cost, and genre.
    /// </summary>
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Genre: {genre}");
    }
}

/// <summary>
/// Represents a book with an additional publisher property, inheriting from the <see cref="BookGenre"/> class.
/// </summary>
public sealed class BookGenrePubl : BookGenre
{
    private string publisher;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookGenrePubl"/> class with the specified title, author, cost, genre, and publisher.
    /// </summary>
    /// <param name="title">The title of the book.</param>
    /// <param name="author">The author of the book.</param>
    /// <param name="cost">The cost of the book.</param>
    /// <param name="genre">The genre of the book.</param>
    /// <param name="publisher">The publisher of the book.</param>
    public BookGenrePubl(string title, string author, double cost, string genre, string publisher)
        : base(title, author, cost, genre)
    {
        this.publisher = publisher;
    }

    /// <summary>
    /// Gets or sets the publisher of the book.
    /// </summary>
    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }

    /// <summary>
    /// Prints information about the book, including title, author, cost, genre, and publisher.
    /// </summary>
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Publisher: {publisher}");
    }
}

/// <summary>
/// Contains the entry point for the application.
/// </summary>
public class BookClassHierarchy
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main()
    {
        BookGenrePubl book = new BookGenrePubl("The Book", "John Doe", 29.99, "Fiction", "ABC Publishers");
        book.Print();
    }
}
