using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace DerDano.EntityFrameworkChangeTracker
{
    internal class StateManagerHelper
    {
        public IStateManager StateManager { get; set; }

        public StateManagerHelper(IStateManager stateManager)
        {
            StateManager = stateManager;
        }

        internal IEnumerable<InternalEntityEntry> GetObjectOccurences(object trackedObject)
        {
            if (StateManager == null)
                throw new EntityChangeTrackerException($"Method {nameof(GetObjectOccurences)} received null argument(s) value");

            return StateManager.Entries.Where(x => x.Entity == trackedObject);
        }
    }
}