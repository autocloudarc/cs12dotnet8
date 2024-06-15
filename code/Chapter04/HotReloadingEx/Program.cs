/* Visual Studio 2022: run the app, change the message, click Hot Reload.
 * Visual Studio Code: run the app using dotnet watch, changt he message, save the file. */

while (true)
{
    WriteLine("Goodbye, Hot Reload!");
    await Task.Delay(2000);
}