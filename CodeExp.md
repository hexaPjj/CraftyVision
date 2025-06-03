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
