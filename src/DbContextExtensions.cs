using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace DerDano.EntityFrameworkChangeTracker
{
    internal static class DbContextExtensions
    {
        /// <summary>
        /// Gets the number of occurrences of an attached tracked object.
        /// </summary>
        /// <param name="dbContext">Database context to perform the search against</param>
        /// <param name="trackedObject">Object to find the occurrences for</param>
        /// <returns>The number of attached entity objects</returns>
        /// <exception cref="EntityChangeTrackerException">Reflection not working properly or method argument values mismatch</exception>
        public static int TrackedCount(this DbContext dbContext, object trackedObject)
        {
            if (dbContext == null || trackedObject == null)
                throw new EntityChangeTrackerException($"Method {nameof(TrackedCount)} received null argument(s) value");

            try
            {
                var stateManager = dbContext.ChangeTracker.GetFieldValue<IStateManager>("StateManager");
                if (stateManager == null)
                    throw new EntityChangeTrackerException($"StateManager could not be determined via reflection");

                var helper = new StateManagerHelper(stateManager);

                var trackedEntityObjects = helper.GetObjectOccurences(trackedObject);
                if (trackedEntityObjects.Count() == 0)
                    return 0;

                return trackedEntityObjects.Count(x => x.EntityState != EntityState.Detached);
            }
            catch (Exception ex)
            {
                throw new EntityChangeTrackerException($"Could not get the entity object tracking information", ex);
            }
        }

        /// <summary>
        /// Gets the internal entity tracking details
        /// </summary>
        /// <param name="dbContext">Database context to perform the search against</param>
        /// <param name="trackedObject">Object to find the occurrences for</param>
        /// <returns>Tracking details for an attached object</returns>
        /// <exception cref="EntityChangeTrackerException">Reflection not working properly or method argument values mismatch</exception>
        public static List<InternalEntityEntry> TrackingDetails(this DbContext dbContext, object trackedObject)
        {
            if (dbContext == null || trackedObject == null)
                throw new EntityChangeTrackerException($"Method {nameof(TrackingDetails)} received null argument(s) value");

            try
            {
                var stateManager = dbContext.ChangeTracker.GetFieldValue<IStateManager>("StateManager");
                if (stateManager == null)
                    throw new EntityChangeTrackerException($"StateManager could not be determined via reflection");

                var helper = new StateManagerHelper(stateManager);
                
                var trackedEntityObjects = helper.GetObjectOccurences(trackedObject);
                return trackedEntityObjects.ToList();
            }
            catch (Exception ex)
            {
                throw new EntityChangeTrackerException($"Could not get the entity object tracking information", ex);
            }
        }
    }
}