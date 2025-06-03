# 📌 What is CancellationTokenSource (CTS)?

`CancellationTokenSource` is used to cancel long-running operations in C#. For example, if an HTTP request takes too long or the user decides to cancel, CTS can stop the operation gracefully.

```csharp
CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken token = cts.Token;

try
{
    await SomeAsyncMethod(token);
}
catch (OperationCanceledException)
{
    Console.WriteLine("Operation was canceled.");
}

cts.Cancel(); // cancels the operation
```
---

```csharp
string mojangUrl = $"https://api.mojang.com/users/profiles/minecraft/{username}"; // its request to mojang/users api
HttpResponseMessage response = await client.GetAsync(mojangUrl); // get UUID
```

# 📌 How to use [Crafatar API](https://crafatar.com/)

*crafatar api* has document on their page you can look that but in short

- mojang stores characters and their names in uuid
- and APIs like craftar API create characters using this uuid
- /avatars/{uuid}
- /skins/{uuid}
- /head/{uuid}
- /body/{uuid}
- these are **can be change**
## And also what is **?size=512&overlay**
- ?size=512&overlay is
- **size** : **0 - 512 literally it set to png size**
- **overlay** : this for layers, i mean, **If the character has an extra layer(helm) it will show it**

---

```csharp
imageUrl = $"https://crafatar.com/avatars/{uuid}?size=512&overlay"; // 2D Head
imageUrl = $"https://crafatar.com/skins/{uuid}?size=512&overlay"; // 2D Texture Skim
imageUrl = $"https://crafatar.com/renders/head/{uuid}?size=512&overlay"; // 3D Head
imageUrl = $"https://crafatar.com/renders/body/{uuid}?size=512&overlay"; // 3D Full Body Render
```
---
