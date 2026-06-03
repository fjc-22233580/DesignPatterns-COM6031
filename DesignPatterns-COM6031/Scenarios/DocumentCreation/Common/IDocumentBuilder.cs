namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

public interface IDocumentBuilder
{
    IDocumentBuilder AddTitle(string title);

    IDocumentBuilder AddBody(string body);

    IDocumentBuilder AddFooter(string footer);

    // void SetMetadata(DocumentMetadata metadata);

    IDocument Build();
}