using ConsoleInterface;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;


internal class Program
{
    private static DataContext? _context;

    private static void PrintTeams(DataContext context)
    {
        Console.WriteLine("|Команда | кол-во очков");
        Console.WriteLine("+------------------------------------------------");
        var teams = context.Teams.Include(t => t.TeamStatistic)
            .OrderByDescending(t => t.TeamStatistic.Scores).ToList();
        foreach (var t in teams)
        {
            if(t.TeamStatistic == null)
            {
                t.TeamStatistic = new TeamStatistic();
                t.TeamStatistic.Scores = 0;
                context.SaveChangesAsync();
            }
        }

        teams = teams.OrderByDescending(t => t.TeamStatistic!.Scores).ToList();
        foreach (var t in teams)
            Console.WriteLine($"|{t.Name} | {t.TeamStatistic!.Scores}");
        Console.WriteLine("+------------------------------------------------");
    }   
   

    private static void AddTeam(DataContext context)
    {
        Console.WriteLine("Введите название команды");
        var team = new Team();
        var name = Console.ReadLine();
        if (name != null)
        {
            team.Name = name;
        }
        else
        {
            team.Name = "No Name";
        }

        var stat = new TeamStatistic();
        Console.WriteLine("Введите кол-во очков команды");
        var scores = Convert.ToInt32(Console.ReadLine());
        stat.Scores =scores;

        team.TeamStatistic = stat;

        context.Teams.Add(team);

        context.SaveChanges();
    }

    private static void Main(string[] args)
    {
        var conFactory = new ConsoleContext();
        _context = conFactory.CreateDbContext(args);
        PrintTeams(_context);
        AddTeam(_context);
        PrintTeams(_context);
    }
}