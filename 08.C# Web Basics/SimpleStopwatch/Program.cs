
using SimpleStopwatch;
using System.Text;

var chronometer = new Chronometer();

string input = string.Empty;

while ((input = Console.ReadLine()) != "exit")
{
    if (input == "start")
    {
        Task.Run(() =>
        {
            chronometer.Start();
        });
    } 
    else if (input == "stop")
    {
        chronometer.Stop();

    } 
    else if (input == "lap")
    {
        chronometer.Lap();
        Console.WriteLine(chronometer.GetTime);

    } 
    else if (input == "time")
    {
        Console.WriteLine(chronometer.GetTime);

    }
    else if (input == "reset")
    {
        chronometer.Reset();
    }
    else if (input == "laps")
    {
        var currentLaps = chronometer.Laps;

        var lapString = new StringBuilder();
        lapString.AppendLine("Laps:");

        for (int i = 0; i < currentLaps.Count; i++)
        {
            lapString.AppendLine($"{i}. {currentLaps[i]}");
        }

        Console.WriteLine(lapString.ToString().TrimEnd());
    }
}

chronometer.Stop();
