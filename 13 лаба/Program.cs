using _13_лаба;

try
{

    if (Directory.Exists("inspect"))
    {
        Directory.Delete("inspect",true);
    }

    FileManagerNikawak.FirstTask(new DriveInfo("C:\\"));
    FileManagerNikawak.SecondTask(new DirectoryInfo("inspect"), ".txt");
    FileManagerNikawak.ThirdTask();

    LogNikawak.FindForHourAgo(1);

    Console.WriteLine("All operations were successfull");
    
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
