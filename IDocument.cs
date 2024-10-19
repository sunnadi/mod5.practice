using System;
public interface IDocument
{
    void Open();
}
public class Report : IDocument
{
    public void Open()
    {
        Console.WriteLine("Открытие документа: Отчет");
    }
}
public class Resume : IDocument
{
    public void Open()
    {
        Console.WriteLine("Открытие документа: Резюме");
    }
}
public class Letter : IDocument
{
    public void Open()
    {
        Console.WriteLine("Открытие документа: Письмо");
    }
}
public abstract class DocumentCreator
{
    public abstract IDocument CreateDocument();
}
public class ReportCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        return new Report();
    }
}
public class ResumeCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        return new Resume();
    }
}
public class LetterCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        return new Letter();
    }
}
public class Invoice : IDocument
{
    public void Open()
    {
        Console.WriteLine("Открытие документа: Счет");
    }
}

public class InvoiceCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        return new Invoice();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Выберите тип документа (Report, Resume, Letter, Invoice):");
        string documentType = Console.ReadLine();

        IDocument document = null;
        DocumentCreator creator = null;

        switch (documentType.ToLower())
        {
            case "report":
                creator = new ReportCreator();
                break;

            case "resume":
                creator = new ResumeCreator();
                break;

            case "letter":
                creator = new LetterCreator();
                break;

            case "invoice":
                creator = new InvoiceCreator();
                break;

            default:
                Console.WriteLine("Некорректный тип документа.");
                return;
        }

        document = creator.CreateDocument();
        document.Open();
    }
}
