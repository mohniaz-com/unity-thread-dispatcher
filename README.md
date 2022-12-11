# UnityThreadDispatcher

Utility library for Unity projects that exposes a simple API for enqueuing actions to be invoked on Unity's main thread.

# Installation

- Retrive the latest [release]("https://github.com/niazmsameer/UnityThreadDispatcher/releases").
- Download the attached `UnityThreadDispatcher.dll` file.
- Create a folder called "Plugins" in the "Assets" folder of your project if it does not exist.
- Copy the .dll file into the new folder.
- A Mono script by the name of `Dispatcher` should be made available to your project.

# Example

```csharp
using UnityEngine;
using UnityThreadDispatcher;

public class Example : MonoBehaviour
{
    private void Start()
    {
        Dispatcher.Instance.Enqueue(() =>
        {
            Debug.Log("Hello, world");
        });
    }
}
```

# API

The entire API exists under the `UnityThreadDispatcher` namespace.

---

```csharp
(property) static Dispatcher Dispatcher.Instance
```
Retrieve the Dispatcher singleton instance. A new one is created if it does not exist.

---

```csharp
void Dispatcher.Enqueue(System.Action action)
```
Enqueue the provided `action` to be executed on Unity's main thread.