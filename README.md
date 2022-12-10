# Entity Framework Change Tracker

Entity Framework database tracking helper library provides the extension methods to help you localize potential issues caused by multiple object tracking at the same time.

## Download NuGet package

```bash
dotnet add package DerDano.EntityFrameworkChangeTracker --version 0.1.0
```

## Helper methods usage

```csharp
using DerDano.EntityFrameworkChangeTracker;

namespace EntityFrameworkPlayground;

class EfChangeTrackerExample
{
    void DetermineTracking()
    {
        var myDbContext = new MyGreatDbContext();
        var myObject = new MyObject();

        // ...create and manipulate some objects and attach to the database context

        if (myDbContext.TrackedCount(myObject) != 0)
        {
            Console.WriteLine(myDbContext.TrackingDetails(myObject));
        }
    }
}
```
