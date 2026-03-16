var screen = new ScreenCapture.Screen();

var screens = screen.GetScreens();

screens.ToList().ForEach(s =>
{
    Console.WriteLine(s);
});

