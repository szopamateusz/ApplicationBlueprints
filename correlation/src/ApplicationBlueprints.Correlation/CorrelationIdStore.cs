using System;

namespace ApplicationBlueprints.Correlation
{
    public interface ICorrelationIdStore
    {
        void SetCorrelationId(Guid? correlationId);
        Guid? GetCorrelationId();
    }

    public class CorrelationIdStore : ICorrelationIdStore
    {
        private Guid? _correlationId;

        public void SetCorrelationId(Guid? correlationId)
        {
            _correlationId = correlationId;
        }

        public Guid? GetCorrelationId() => _correlationId;
    }
}
