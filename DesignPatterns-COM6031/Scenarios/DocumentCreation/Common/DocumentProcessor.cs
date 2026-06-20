namespace DesignPatterns_COM6031.Scenarios.DocumentCreation.Common;

/// <summary>
/// Base processor that defines the common steps for processing a document.
/// </summary>
/// <typeparam name="TDocument">
/// The document type handled by this processor.
/// </typeparam>
public abstract class DocumentProcessor<TDocument> where TDocument : IDocument
{
    /// <summary>
    /// Processes the document using a fixed sequence of validation, saving, and printing.
    /// </summary>
    public void ProcessDocument(TDocument document)
    {
        Validate(document);
        Save(document);
        Print(document);
    }

    /// <summary>
    /// Validates the document before it is saved or printed.
    /// This must be implemented by each concrete processor because validation rules
    /// are specific to each document type.
    /// </summary>
    protected abstract void Validate(TDocument document);

    /// <summary>
    /// Saves the document. Concrete processors can override this when they need custom save behaviour.
    /// </summary>
    protected virtual void Save(TDocument document)
    {
        // Document Saved
    }

    /// <summary>
    /// Prints the document. Concrete processors can override this when they need custom print behaviour.
    /// </summary>
    protected virtual void Print(TDocument document)
    {
        // Document Printed
    }
}