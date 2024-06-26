using poc.core.api.net8.Abstractions;
using poc.core.api.net8.Events;

namespace poc.core.api.net8;

/// <summary>
/// Classe base que contém os comportamentos de uma entidade.
/// </summary>
public abstract class BaseEntity : IEntity<Guid>
{
    private readonly List<Event> _domainEvents = new();

    public Guid Id { get; private init; } = Guid.NewGuid();

    /// <summary>
    /// Eventos de domínio que ocorreram.
    /// </summary>
    public IEnumerable<Event> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Adicionar evento de domínio.
    /// </summary>
    /// <param name="domainEvent"></param>
    public void AddDomainEvent(Event domainEvent) => _domainEvents.Add(domainEvent);

    /// <summary>
    /// Limpa os eventos de domínio.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();
}

/// <summary>
/// Classe base que contém os comportamentos de uma entidade.
/// </summary>
public abstract class BaseEOraclentity
{
    private readonly List<Event> _domainEvents = new();

    /// <summary>
    /// Eventos de domínio que ocorreram.
    /// </summary>
    public IEnumerable<Event> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Adicionar evento de domínio.
    /// </summary>
    /// <param name="domainEvent"></param>
    public void AddDomainEvent(Event domainEvent) => _domainEvents.Add(domainEvent);

    /// <summary>
    /// Limpa os eventos de domínio.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();
}